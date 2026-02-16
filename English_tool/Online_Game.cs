using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static English_tool.Offline_setting;

namespace English_tool
{
    public partial class Online_Game : Form
    {
        NetworkManager net;
        List<Vocabulary> wordList;

        // === 游戏变量 ===
        int myTotalScore = 0;
        int opponentTotalScore = 0;
        int currentIndex = 0;
        bool isAnswerChecked = false;
        int sumWrong = 0;
        // === 配置变量 ===
        bool isFirstLetterHint = false;
        bool isRandom = true;
        int winThreshold = 10;
        bool isHost;
        string hostSelectedFiles;

        public Online_Game(List<Vocabulary> list, bool isHost, string ip, string roomId, int winScore, bool isHint, string fileNames)
        {
            InitializeComponent();
            this.FormClosing += Online_Game_FormClosing;
            this.isHost = isHost;
            this.hostSelectedFiles = fileNames;
            this.isFirstLetterHint = isHint;
            this.isRandom = true;

            // 保底逻辑
            this.winThreshold = winScore <= 0 ? 10 : winScore;
            this.wordList = list ?? new List<Vocabulary>();

            // === UI 初始化 ===
            // 1. 隐形输入框设置
            this.txtInput.Location = new Point(-500, -500);
            this.txtInput.TextChanged += TxtInput_TextChanged;
            this.txtInput.KeyDown += txtInput_KeyDown;

            // 2. 焦点保护：点击任何地方都聚焦输入框
            this.labelHint.Click += (s, e) => { this.txtInput.Focus(); };
            this.Click += (s, e) => { this.txtInput.Focus(); };
            if (panelRope != null) panelRope.Click += (s, e) => { this.txtInput.Focus(); };
            // 如果点击了答案标签，也聚焦
            if (labelAnswer != null) labelAnswer.Click += (s, e) => { this.txtInput.Focus(); };

            // 3. 拔河和布局初始化
            this.Resize += (s, e) => { UpdateRopePosition(); AlignAnswerLabel(); };
            InitRopeUI();
            CenterKnot();
            // === 网络初始化 ===
            net = new NetworkManager();
            BindNetworkEvents();

            string action = isHost ? "CREATE" : "JOIN";
            net.ConnectAndSetup(ip, 8888, action, roomId);
        }



        // === 1. 核心游戏逻辑：切题 ===
        public void LoadCurrentWord()
        {
            if (currentIndex >= wordList.Count)
            {
                if (this.isRandom) ShuffleWithSeed(this.wordList, new Random().Next());
                currentIndex = 0;
            }

            Vocabulary v = wordList[currentIndex];
            labelCN.Text = v.Chinese;

            // === 首字母预填逻辑 ===
            if (isFirstLetterHint && !string.IsNullOrEmpty(v.English))
            {
                txtInput.Text = v.English.Substring(0, 1);
                txtInput.SelectionStart = 1;
            }
            else
            {
                txtInput.Text = "";
            }

            txtInput.Focus();

            // 还原显示状态 (隐藏答案，显示输入行)
            if (labelAnswer != null) labelAnswer.Visible = false;
            labelHint.Visible = true;
            labelHint.ForeColor = Color.Black;

            // 更新“隐形输入”显示
            UpdateLabelDisplay();

            labelResult.Text = "";
            isAnswerChecked = false;
        }

        // === 2. 核心游戏逻辑：判分 ===
        private void CheckAnswer()
        {
            Vocabulary v = wordList[currentIndex];
            string userAnswer = txtInput.Text.Trim();

            if (string.Equals(userAnswer, v.English, StringComparison.OrdinalIgnoreCase))
            {
                // ✅ 答对了
                labelResult.Text = "✅ 正确！";
                labelResult.ForeColor = Color.Green;

                // 显示完整单词（绿色）
                labelHint.Text = string.Join(" ", v.English.ToCharArray());
                labelHint.ForeColor = Color.Green;

                // 加分
                myTotalScore++;
                net.SendScore(myTotalScore);
                UpdateRopePosition();

                isAnswerChecked = true;
            }
            else
            {
                // ❌ 答错了
                labelResult.Text = "❌ 错误";
                labelResult.ForeColor = Color.Red;
                sumWrong++;
                if(sumWrong == 5)
                {
                    myTotalScore--;
                    sumWrong = 0;
                    net.SendScore(myTotalScore);
                    UpdateRopePosition();
                    labelResult.Text = "❌ 错误（你错五次了，扣你一分哦）";
                }
                // 【显示正确答案】
                if (labelAnswer != null)
                {
                    // 设置正确答案文本 (带空格对齐)
                    labelAnswer.Text = string.Join(" ", v.English.ToCharArray());
                    labelAnswer.ForeColor = Color.Blue;

                    // 隐藏输入提示，显示正确答案
                    labelHint.Visible = false;
                    labelAnswer.Visible = true;

                    // 确保位置重合
                    AlignAnswerLabel();
                }

                isAnswerChecked = true;
            }
        }

        private void NextWord()
        {
            currentIndex++;
            LoadCurrentWord();
        }

        // 监听回车键 & 防删保护
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            // 回车键
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (!isAnswerChecked)
                {
                    CheckAnswer();
                }
                else
                {
                    NextWord(); // 答对/答错后按回车，进入下一题
                }
                return;
            }

            // 首字母防删
            if (isFirstLetterHint && e.KeyCode == Keys.Back)
            {
                if (txtInput.SelectionStart <= 1 && txtInput.Text.Length > 0)
                {
                    e.SuppressKeyPress = true; // 禁止删除第一个字母
                }
            }
        }

        // === 辅助显示逻辑 ===
        private void AlignAnswerLabel()
        {
            if (labelAnswer != null && labelHint != null)
            {
                labelAnswer.Location = labelHint.Location;
                labelAnswer.BringToFront();
            }
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            if (wordList == null || currentIndex >= wordList.Count) return;
            string targetWord = wordList[currentIndex].English;

            if (txtInput.Text.Length > targetWord.Length)
            {
                txtInput.Text = txtInput.Text.Substring(0, targetWord.Length);
                txtInput.SelectionStart = txtInput.Text.Length;
            }
            UpdateLabelDisplay();
        }

        private void UpdateLabelDisplay()
        {
            if (wordList == null || currentIndex >= wordList.Count) return;
            string targetWord = wordList[currentIndex].English;
            string userInput = txtInput.Text;

            List<char> displayChars = new List<char>();
            for (int i = 0; i < targetWord.Length; i++)
            {
                if (i < userInput.Length)
                {
                    displayChars.Add(userInput[i]);
                }
                else
                {
                    // 还没输入的地方显示下划线
                    displayChars.Add('_');
                }
            }
            labelHint.Text = string.Join(" ", displayChars);
        }

        // === 拔河视觉逻辑 ===
        private void UpdateRopePosition()
        {
            if (panelRope == null) return;

            int balance = myTotalScore - opponentTotalScore;

            if (balance >= winThreshold)
            {
                net.SendWin();
                MessageBox.Show("【完胜】你赢了hhh！");
                this.Close();
                return;
            }
            if (balance <= -winThreshold)
            {
                MessageBox.Show("【失败】你输了...");
                this.Close();
                return;
            }

            int centerX = (panelRope.Width - lblKnot.Width) / 2;
            int maxDistance = (panelRope.Width / 2) - lblMe.Width - (lblKnot.Width / 2);
            float step = (float)maxDistance / winThreshold;
            int targetX = (panelRope.Width - lblKnot.Width) / 2 + (int)(balance * step);

            lblKnot.Left = targetX;

            lblEnemy.Left = 0;
            lblMe.Left = panelRope.Width - lblMe.Width;

            this.Text = $"净胜: {balance} (目标: {winThreshold})";
        }

        // === 网络事件绑定 ===
        private void BindNetworkEvents()
        {
            net.OnWaiting = () => InvokeUI(() => {
                this.Text = "等待对手...";
                if (lblStatus != null) lblStatus.Text = "房间创建成功，等待对手加入...";
            });
            net.OnError = (err) => InvokeUI(() => { MessageBox.Show("错误: " + err); this.Close(); });
            net.OnConnected = () => InvokeUI(() =>
            {
                if (isHost)
                {
                    if (lblStatus != null) lblStatus.Text = "配对成功！正在发送配置...";
                    int seed = new Random().Next();
                    net.SendGameConfig(seed, this.isFirstLetterHint, this.winThreshold, this.hostSelectedFiles);
                    LoadFilesLocally(this.hostSelectedFiles);
                    StartGame(seed);
                }
                else { if (lblStatus != null) lblStatus.Text = "配对成功！正在同步配置..."; }
            });
            net.OnConfigReceived = (seed, hint, score, fileNames) => InvokeUI(() =>
            {
                this.isFirstLetterHint = hint; this.winThreshold = score;
                if (LoadFilesLocally(fileNames)) StartGame(seed);
                else { MessageBox.Show($"错误：本地缺少书本 ({fileNames})"); this.Close(); }
            });
            net.OnOpponentScore = (score) => InvokeUI(() => { opponentTotalScore = score; UpdateRopePosition(); });
            net.OnOpponentQuit = () => InvokeUI(() => { MessageBox.Show("对手逃跑了！你赢了！"); this.FormClosing -= Online_Game_FormClosing; Close(); });
            net.OnOpponentWin = () => InvokeUI(() => { MessageBox.Show("你输了！"); this.FormClosing -= Online_Game_FormClosing; Close(); });
        }

        private void StartGame(int seed)
        {
            if (lblStatus != null) lblStatus.Text = "开始拔河！";
            if (this.wordList != null && this.wordList.Count > 0)
            {
                this.wordList.Sort((x, y) => string.Compare(x.English, y.English, StringComparison.Ordinal));
            }
            ShuffleWithSeed(this.wordList, seed);
            currentIndex = 0; myTotalScore = 0; opponentTotalScore = 0;
            this.Text = $"Online Game - [种子:{seed}] [数量:{wordList.Count}]";
            UpdateRopePosition();
            LoadCurrentWord();
        }

        // === 辅助函数 ===
        private bool LoadFilesLocally(string fileNamesStr)
        {
            this.wordList = new List<Vocabulary>();
            string[] files = fileNamesStr.Split(',');
            foreach (string fileName in files)
            {
                if (string.IsNullOrWhiteSpace(fileName)) continue;
                string path = Path.Combine(Application.StartupPath, "data", fileName);
                if (!File.Exists(path)) return false;
                this.wordList.AddRange(ReadCsv(path));
            }
            return this.wordList.Count > 0;
        }

        private List<Vocabulary> ReadCsv(string path)
        {
            var list = new List<Vocabulary>();
            try
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 2) list.Add(new Vocabulary { English = parts[0].Trim(), Chinese = parts[1].Trim().Trim('"') });
                }
            }
            catch { }
            return list;
        }

        private void InitRopeUI()
        {
            if (lblEnemy != null) lblEnemy.Location = new Point(0, (panelRope.Height - lblEnemy.Height) / 2);
            if (lblMe != null) lblMe.Location = new Point(panelRope.Width - lblMe.Width, (panelRope.Height - lblMe.Height) / 2);
            if (labelAnswer != null) labelAnswer.Visible = false; // 初始隐藏
        }
        private void CenterKnot()
        {
            if (panelRope != null && lblKnot != null)
            {
                lblKnot.Left = (panelRope.Width - lblKnot.Width) / 2;
                lblKnot.Top = (panelRope.Height - lblKnot.Height) / 2;
            }
        }
        private void ShuffleWithSeed(List<Vocabulary> list, int seed)
        {
            Random rng = new Random(seed);
            int n = list.Count;
            while (n > 1) { n--; int k = rng.Next(n + 1); var val = list[k]; list[k] = list[n]; list[n] = val; }
        }
        private void Online_Game_FormClosing(object sender, FormClosingEventArgs e) { if (net != null && net.IsConnected) net.SendQuit(); }
        private void InvokeUI(Action action) { if (this.InvokeRequired) this.Invoke(action); else action(); }
    }
}