using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static English_tool.Offline_setting;

namespace English_tool
{
    public partial class Offline_Game : Form
    {
        List<Vocabulary> wordList;
        int currentIndex = 0;
        bool isAnswerChecked = false;
        bool isFirstLetterHint = false;
        Speaker speaker;
        bool isReviewMode = false; // 标记：是否为复习错题模式
        bool isProcessing = false;
        public Offline_Game(List<Vocabulary> incomingList, bool isFirstLetterHint, bool isReviewMode = false)
        {
            InitializeComponent();

            this.wordList = incomingList;
            this.isFirstLetterHint = isFirstLetterHint;
            this.speaker = new Speaker();
            this.isReviewMode = isReviewMode;
            // === 1. 隐形输入框初始化 ===
            // 移出屏幕
            this.txtInput.Location = new Point(-500, -500);

            // 绑定事件
            this.txtInput.TextChanged += TxtInput_TextChanged;
            this.txtInput.KeyDown += txtInput_KeyDown;   // 绑定回车判定、空格存错题逻辑
            this.txtInput.KeyPress += txtInput_KeyPress; // 绑定禁止空格输入逻辑

            // 点击界面任何文字都聚焦输入框
            this.labelHint.Click += (s, e) => { this.txtInput.Focus(); };
            this.Click += (s, e) => { this.txtInput.Focus(); };
            if (labelAnswer != null) this.labelAnswer.Click += (s, e) => { this.txtInput.Focus(); };

            // === 2. 加载第一个词 ===
            LoadCurrentWord();
        }

        // === 核心逻辑：切题 ===
        public void LoadCurrentWord()
        {
            // 检查是否学完
            if (currentIndex >= wordList.Count)
            {
                MessageBox.Show("恭喜！本组单词已全部复习完毕！");
                this.Close();
                return;
            }

            Vocabulary v = wordList[currentIndex];
            labelCN.Text = v.Chinese;

            // === 3. 预填首字母逻辑 ===
            if (isFirstLetterHint && !string.IsNullOrEmpty(v.English))
            {
                // 直接填入第一个字母
                txtInput.Text = v.English.Substring(0, 1);
                // 光标移到第1位后面，准备输入第2个字
                txtInput.SelectionStart = 1;
            }
            else
            {
                txtInput.Text = "";
            }

            // 强制聚焦
            txtInput.Focus();

            // 还原显示状态 (隐藏答案，显示输入行)
            if (labelAnswer != null) labelAnswer.Visible = false;
            labelHint.Visible = true;
            labelHint.ForeColor = Color.Black;

            // 更新显示
            UpdateLabelDisplay();

            // 重置状态
            labelResult.Text = "";
            isAnswerChecked = false;
        }

        // === 4. 实时显示逻辑 (影子输入法) ===
        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            if (wordList == null || currentIndex >= wordList.Count) return;
            string targetWord = wordList[currentIndex].English;

            // 限制输入长度
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
                    // 显示用户输入的 (哪怕是错的也显示，让用户知道自己打的啥)
                    displayChars.Add(userInput[i]);
                }
                else
                {
                    // 还没输入的地方显示下划线
                    displayChars.Add('_');
                }
            }

            // 加空格美化 (A P P L E)
            labelHint.Text = string.Join(" ", displayChars);
        }

        // === 5. 按键逻辑 (包含防删保护) ===
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (isProcessing)
            {
                e.SuppressKeyPress = true;
                return;
            }
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
            //空格键
            if (e.KeyCode == Keys.Space)
            {
                if (!isAnswerChecked)
                {
                    return;
                }
                e.SuppressKeyPress = true;

                // 只有在“已判分”且“答错”的情况下
                if (wordList != null && currentIndex < wordList.Count)
                {
                    Vocabulary v = wordList[currentIndex];

                    // 1. 保存到文件
                    SaveToMistakeBook(v);

                    // 2. 界面反馈一下
                    labelResult.Text = "已加入错题本！";
                    labelResult.ForeColor = Color.Orange;
                    // 3. 稍微停顿一下再跳
                    // 强制刷新一下界面让用户看到反馈(如果需要)，然后跳
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300); // 稍微停0.3秒让用户感觉存上了
                    NextWord(); // 进入下一题
                }
                isProcessing = false;
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

        // === 6. 判分逻辑 (含正确答案显示) ===
        private void CheckAnswer()
        {
            Vocabulary v = wordList[currentIndex];
            string userAnswer = txtInput.Text.Trim();
            labelResult.Visible = true;
            if (string.Equals(userAnswer, v.English, StringComparison.OrdinalIgnoreCase))
            {
                // ✅ 答对了
                if (isReviewMode)
                {
                    RemoveFromMistakeBook(v.English);
                    labelResult.Text = "✅ 正确！(已从错题本移除)";
                }
                else
                {
                    labelResult.Text = "✅ 正确！";
                }
                labelResult.ForeColor = Color.Green;

                // 显示完整单词（绿色）
                labelHint.Text = string.Join(" ", v.English.ToCharArray());
                labelHint.ForeColor = Color.Green;

                isAnswerChecked = true;
            }
            else
            {
                // ❌ 答错了
                labelResult.Text = "❌ 错误";
                labelResult.ForeColor = Color.Red;

                // 【显示正确答案】
                if (labelAnswer != null)
                {
                    // 设置正确答案文本 (带空格对齐)
                    labelAnswer.Text = string.Join(" ", v.English.ToCharArray());
                    labelAnswer.ForeColor = Color.Blue;
                    labelAnswer.Visible = true;
                }

                isAnswerChecked = true;
            }
        }

        // 按钮事件绑定
        private void NextWord()
        {
            currentIndex++;
            LoadCurrentWord();
        }

        private void PreviousWord()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadCurrentWord();
            }
        }
        private void back_button_Click(object sender, EventArgs e) { this.Close(); }
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (speaker != null && wordList != null && currentIndex < wordList.Count)
            {
                speaker.Speak(wordList[currentIndex].English);
                txtInput.Focus();
            }
        }
        private void pre_button_Click(object sender, EventArgs e) { PreviousWord(); }
        // 保存错题到本地文件
        private void SaveToMistakeBook(Vocabulary v)
        {
            try
            {
                // 1. 确定错题本路径 (放在 data 文件夹下)
                string path = System.IO.Path.Combine(Application.StartupPath, "data", "mistakes.csv");
                string folder = System.IO.Path.Combine(Application.StartupPath, "data");
                // 2. 准备要写入的内容 (格式: 英文|中文)
                string line = $"{v.English}|{v.Chinese}";
                // 如果没有错题本
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                // 3. 查重 (防止同一个词被存好几次)
                if (System.IO.File.Exists(path))
                {
                    string[] existingLines = System.IO.File.ReadAllLines(path);
                    foreach (string l in existingLines)
                    {
                        // 如果已经有了，就不存了，直接返回
                        if (l.Contains(v.English)) return;
                    }
                }

                // 4. 追加写入 (AppendAllText 会自动创建文件如果不存在)
                // Environment.NewLine 是换行符
                System.IO.File.AppendAllText(path, line + Environment.NewLine);

                // 稍微提示一下用户
                // MessageBox.Show("已加入错题本！"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存错题失败: " + ex.Message);
            }
        }
        // 从错题本文件中移除指定单词
        private void RemoveFromMistakeBook(string wordToRemove)
        {
            try
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "data", "mistakes.csv");
                if (!System.IO.File.Exists(path)) return;

                // 1. 读取所有行
                string[] lines = System.IO.File.ReadAllLines(path);
                List<string> newLines = new List<string>();

                // 2. 筛选：把不等于当前单词的行留下来
                foreach (string line in lines)
                {
                    // 假设格式是 "apple|苹果"，我们匹配 "apple|" 开头，防止误删 "applepie"
                    if (!line.StartsWith(wordToRemove + "|"))
                    {
                        newLines.Add(line);
                    }
                }

                // 3. 覆盖写回文件
                System.IO.File.WriteAllLines(path, newLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("移除错题失败: " + ex.Message);
            }
        }
        // 窗口关闭时停止发音
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (speaker != null) speaker.Stop();
            base.OnFormClosing(e);
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 如果当前正在“处理中” 或者 “已经判分结束”
            // 此时按下的空格键，绝对不允许变成字符显示在框里！
            if (isProcessing || isAnswerChecked)
            {
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
            }
        }
    }
}
