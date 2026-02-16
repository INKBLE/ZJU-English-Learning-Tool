using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static English_tool.Offline_setting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace English_tool
{
    public partial class Online_setting : Form
    {
        public List<Vocabulary> all_word_list = new List<Vocabulary>();
        string[] SelectedData = new string[40];
        int index = 0;

        public Online_setting()
        {
            InitializeComponent();
            InitBookList();
            CenterControl(IP);
            // 默认 IP (方便测试)
            if (string.IsNullOrEmpty(IP.Text)) IP.Text = "8.140.237.142";
        }

        // ==========================================
        // 按钮 1: 创建房间 (房主)
        // ==========================================
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!CheckInput(true)) return;

            LoadSelectedBooks();
            if (all_word_list.Count == 0)
            {
                MessageBox.Show("请至少选择一本单词书！");
                return;
            }

            // 生成文件名字符串
            List<string> fileNames = new List<string>();
            for (int i = 0; i < index; i++) fileNames.Add(SelectedData[i]);
            string fileNamesStr = string.Join(",", fileNames);

            // 获取规则
            int winScore = 10;
            if (!int.TryParse(score.Text, out winScore) || winScore <= 0) winScore = 10;

            bool isHint = checkBox5.Checked;
            string roomId = txtRoomId.Text.Trim();
            string serverIp = IP.Text.Trim();

            // 启动游戏 (isHost = true)
            LaunchGame(all_word_list, true, serverIp, roomId, winScore, isHint, fileNamesStr);
        }

        // ==========================================
        // 按钮 2: 加入房间 (加入者)
        // ==========================================
        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (!CheckInput(false)) return;

            string roomId = txtRoomId.Text.Trim();
            string serverIp = IP.Text.Trim();

  
            LaunchGame(null, false, serverIp, roomId, 10, false, "");
        }

        // 统一启动函数
        // 增加了 bool random 参数
        private void LaunchGame(List<Vocabulary> list, bool isHost, string ip, string roomId, int score, bool hint, string files)
        {
            Online_Game game = new Online_Game(list, isHost, ip, roomId, score, hint, files);

            this.Hide();
            game.Show();

            game.FormClosed += (s, args) =>
            {
                this.Close();
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "Home") { f.Show(); f.BringToFront(); break; }
                }
            };
        }

        private void LoadSelectedBooks()
        {
            index = 0;
            all_word_list = new List<Vocabulary>();
            SelectedData = new string[40];
            foreach (object item in checkedListBox1.CheckedItems)
            {
                string filename = item.ToString();
                SelectedData[index] = filename;
                index++;
                string path = Path.Combine(Application.StartupPath, "data", filename);
                if (File.Exists(path)) all_word_list.AddRange(ReadCsv(path));
            }
        }

        private List<Vocabulary> ReadCsv(string path)
        {
            List<Vocabulary> list = new List<Vocabulary>();

            // 读取所有行
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                // 如果整行是空的，跳过
                if (string.IsNullOrWhiteSpace(line)) continue;


                string[] parts = line.Split('|');


                // 检查 A: 分割出来的部分是否太少？(防止只有半截的脏数据)
                if (parts.Length < 2) continue;

                // 检查 B: 英文单词是不是空的？(防止 " ,中文意思" 这种数据)
                string english = parts[0].Trim();
                string chinese = parts[1].Trim();

                // 如果英文是空的，或者全是空格，直接跳过！
                if (string.IsNullOrEmpty(english)) continue;
                Vocabulary v = new Vocabulary();
                v.English = english;
                v.Chinese = chinese;
                list.Add(v);
            }

            return list;
        }

        private bool CheckInput(bool checkBooks)
        {
            if (string.IsNullOrWhiteSpace(IP.Text)) { MessageBox.Show("请输入IP"); return false; }
            if (string.IsNullOrWhiteSpace(txtRoomId.Text)) { MessageBox.Show("请输入房间号"); return false; }
            return true;
        }

        private void InitBookList()
        {
            checkedListBox1.Items.Clear();
            string dataPath = Path.Combine(Application.StartupPath, "data");
            if (Directory.Exists(dataPath))
            {
                foreach (var file in new DirectoryInfo(dataPath).GetFiles("*.csv"))
                    checkedListBox1.Items.Add(file.Name);
            }
        }
        private void CenterControl(Control c) { c.Left = (this.ClientSize.Width - c.Width) / 2; }
        private void ToggleBookSelection(string keyword)
        {
            bool isCurrentlyAllSelected = true;
            bool hasMatchingItems = false;
            int matchCount = 0; // 记录找到了几个文件

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string filename = checkedListBox1.Items[i].ToString();

                // 使用 IndexOf(..., OrdinalIgnoreCase) 来忽略大小写
                // 只要返回值 >= 0，说明找到了（不管 B1 还是 b1）
                if (filename.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    hasMatchingItems = true;
                    matchCount++;

                    // 只要有一个没打钩，那现在的状态就不是“全选”
                    if (checkedListBox1.GetItemChecked(i) == false)
                    {
                        isCurrentlyAllSelected = false;
                        // 这里不要 break，为了调试准确，我们继续循环看看
                    }
                }
            }

            

            // 第二遍：执行反选
            // 逻辑：如果现在全是钩，就全取消；如果有一个没钩，就全打钩
            bool targetState = !isCurrentlyAllSelected;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string filename = checkedListBox1.Items[i].ToString();

                // 同样忽略大小写
                if (filename.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    checkedListBox1.SetItemChecked(i, targetState);
                }
            }
        }
        private void btnBook1_Click(object sender, EventArgs e)
        {
            ToggleBookSelection("b1");
        }
        // 按钮 2：选择 Book 2 
        private void btnBook2_Click(object sender, EventArgs e)
        {
            ToggleBookSelection("b2");
        }

        // 按钮 3：选择 Book 3 
        private void btnBook3_Click(object sender, EventArgs e)
        {
            ToggleBookSelection("b3");
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


