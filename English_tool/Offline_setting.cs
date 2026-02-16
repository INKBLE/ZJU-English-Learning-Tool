using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static English_tool.Offline_Game;
using static English_tool.Offline_setting;
using System.IO;
namespace English_tool
{
    public partial class Offline_setting : Form
    {
        public List<Vocabulary> all_word_list = new List<Vocabulary>();
        string[] SelectedData = new string[40];
        int index = 0;
        public Offline_setting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string[] files = { "四级精选.csv", "b1u1.csv", "b1u2.csv", "b1u3.csv",
                       "b1u4.csv", "b1u5.csv", "b1u6.csv","b1u7.csv","b1u8.csv", "b2u1.csv", "b2u2.csv", "b2u3.csv",
                       "b2u4.csv", "b2u5.csv", "b2u6.csv","b2u7.csv","b2u8.csv","b3u1.csv", "b3u2.csv", "b3u3.csv",
                       "b3u4.csv", "b3u5.csv", "b3u6.csv","b3u7.csv","b3u8.csv",};
            checkedListBox1.Items.AddRange(files);
        }
        private void GetData()            //获取用户选择的单词范围                                                                          
        {                                                                 //已选数据存在Selected_Data，数据总量在index
            index = 0;
            foreach (object item in checkedListBox1.CheckedItems)
            {
                string filename = item.ToString();
                SelectedData[index] = filename;
                index++;
            }
        }
        public bool isRandom = false;
        public bool isFirstLetterHint = false;
        
        private void start_button_Click(object sender, EventArgs e)   //游戏初始化工作，包括生成总的词汇列表，分单元随机
        {
            this.index = 0;
            //清空之前的单词列表 (否则第二次玩的时候，单词会变双倍),目的是考虑背单词一半点back情况。
            if (this.all_word_list != null)
            {
                this.all_word_list.Clear();
            }
            else
            {
                this.all_word_list = new List<Vocabulary>();
            }
            this.SelectedData = new string[40];
            GetData();
            if (index == 0)
            {
                MessageBox.Show("你还没有选择你的副本 ");
                return;
            }
            for (int i = 0; i < index; i++)
            {
                string current_name = SelectedData[i];
                string current_path = Path.Combine(Application.StartupPath, "data", current_name);
                List<Vocabulary> current_vocabularies = LoadWordsFromCsv(current_path);
                if (isRandom)
                    Shuffle(current_vocabularies);
                foreach (var vocabulary in current_vocabularies)
                {
                    all_word_list.Add(vocabulary);
                }
            }
            Offline_Game offline = new Offline_Game(this.all_word_list, isFirstLetterHint);
            offline.TopLevel = false;
            offline.FormBorderStyle = FormBorderStyle.None;
            offline.Dock = DockStyle.Fill;
            this.panel1.Visible = true;
            offline.FormClosed += (s, args) =>
            {
                // 确保在主线程执行
                this.Invoke((MethodInvoker)delegate
                {
                    // 1. 先把 Panel 藏起来
                    this.panel1.Visible = false;

                    // 2. 把死掉的游戏窗体从 Panel 里移除
                    // 如果不移除，Panel 里会堆积一堆关闭了的窗体尸体，导致渲染异常
                    this.panel1.Controls.Clear();

                    // 3. 强制刷新主界面
                    // 这会让主界面重新画一遍所有的按钮和背景，解决“只加载一部分”的问题
                    this.Refresh();

                    // 4. 如果有些按钮还是不出来，强制把它们拉到最前
                    this.start_button.BringToFront();
                    this.back_button.BringToFront();
                });
            };
            this.panel1.Controls.Add(offline);
            this.panel1.BringToFront();
            offline.Show();
            offline.BringToFront();
        }

        private void ToggleBookSelection(string keyword)
        {
            // 假设它已经是“全选”状态，然后去列表里找反例
            bool isCurrentlyAllSelected = true;
            bool hasMatchingItems = false; // 用来防止列表为空或没找到对应书时出bug

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string filename = checkedListBox1.Items[i].ToString();
                if (filename.Contains(keyword))
                {
                    hasMatchingItems = true;
                    // 只要发现这组书里有一个没打钩，那它就肯定不是“全选”
                    if (checkedListBox1.GetItemChecked(i) == false)
                    {
                        isCurrentlyAllSelected = false;
                        break; // 只要找到一个没选的，后面就不用看了，结果已定
                    }
                }
            }

            // 如果没找到任何这本书的文件，直接退出，防止误操作
            if (!hasMatchingItems) return;
            // 反选
            bool targetState = !isCurrentlyAllSelected;
            // 执行操作
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string filename = checkedListBox1.Items[i].ToString();
                if (filename.Contains(keyword))
                {
                    checkedListBox1.SetItemChecked(i, targetState);
                }
            }
        }
        // 按钮 1：选择 Book 1 
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

        // 按钮 4；是否随机 
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            isRandom = checkBox4.Checked;
        }
        // 按钮 5；是否首字母提示
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            isFirstLetterHint = checkBox5.Checked;
        }

        public class Vocabulary
        {
            public string English { get; set; }    // 写 { get; set; }
            public string Chinese { get; set; }
            public string Example { get; set; }
        }
        public List<Vocabulary> LoadWordsFromCsv(string filePath) //从.CSV读取单词,输出class为vocabulary的列表
        {
            // 1. 初始化一个空列表

            List<Vocabulary> vocabularies = new List<Vocabulary>();
            // 2. 检查文件是否存在，防止报错
            if (!File.Exists(filePath))
            {
                MessageBox.Show("文件未找到！");
                return vocabularies;
            }

            try
            {
                // 3. 读取所有行
                string[] lines = File.ReadAllLines(filePath);

                // 4. 遍历每一行进行处理
                foreach (string line in lines)
                {
                    Vocabulary vocabulary = new Vocabulary();
                    // 如果行是空的，跳过
                    if ((string.IsNullOrWhiteSpace(line))) continue;

                    // 分隔
                    string[] parts = line.Split('|');

                    if (parts.Length < 2) continue;

                    // 取第一部分，并去掉前后空格
                    if (parts.Length > 0)
                    {
                        vocabulary.Chinese = parts[1].Trim().Trim('"');
                        vocabulary.English = parts[0].Trim();
                        //vocabulary.Example = parts[2].Trim();
                        if (string.IsNullOrEmpty(vocabulary.English)) continue;
                        vocabularies.Add(vocabulary);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取文件出错: " + ex.Message);
            }

            // 5. 返回列表
            return vocabularies;
        }


        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReviewMistakes_Click(object sender, EventArgs e)
        {
            // 1. 找到错题本路径
            string path = System.IO.Path.Combine(Application.StartupPath, "data", "mistakes.csv");

            // 2. 检查有没有错题
            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("你还没有错题本哦！");
                return;
            }

            // 3. 读取错题
            // 复用你之前写的 LoadWordsFromCsv 或者 ReadCsv 函数
            // 注意：如果是 Offline_setting 里的 ReadCsv 是私有的，你可能要复制一份过来或者改成 public
            List<Vocabulary> mistakeList = ReadCsv(path);

            if (mistakeList.Count == 0)
            {
                MessageBox.Show("错题本是空的！太棒了！");
                return;
            }

            // 4. 启动游戏 (复用 Offline_Game)
            // 这里的参数：错题列表, 开启首字母提示(可自己定)
            Offline_Game game = new Offline_Game(mistakeList, isFirstLetterHint, true);

            this.Hide();
            game.Show();

            // 监听关闭，回到设置界面
            game.FormClosed += (s, args) => this.Show();
        }
        public List<Vocabulary> ReadCsv(string path)
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


        // 随机模块
        private void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;

            // 从最后一个元素开始，随机跟前面的交换
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                // 经典的交换两个变量的值
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}