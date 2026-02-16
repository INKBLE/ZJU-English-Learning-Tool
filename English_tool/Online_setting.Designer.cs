using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace English_tool
{
    partial class Online_setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Online_setting));
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBook1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.back_button = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.score = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.Location = new System.Drawing.Point(264, 837);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(167, 80);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "创建房间";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoin.Location = new System.Drawing.Point(972, 837);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(167, 80);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "加入房间";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // IP
            // 
            this.IP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IP.Location = new System.Drawing.Point(463, 592);
            this.IP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(468, 30);
            this.IP.TabIndex = 2;
            this.IP.Text = "8.140.237.142";
            this.IP.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(303, 240);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(332, 301);
            this.checkedListBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(383, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "选择你的副本";
            // 
            // btnBook1
            // 
            this.btnBook1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBook1.AutoSize = true;
            this.btnBook1.Location = new System.Drawing.Point(303, 547);
            this.btnBook1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBook1.Name = "btnBook1";
            this.btnBook1.Size = new System.Drawing.Size(90, 28);
            this.btnBook1.TabIndex = 8;
            this.btnBook1.Text = "Book1";
            this.btnBook1.UseVisualStyleBackColor = true;
            this.btnBook1.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(398, 547);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 28);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Book2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.btnBook2_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(495, 547);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(90, 28);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Book3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Click += new System.EventHandler(this.btnBook3_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(902, 439);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(126, 28);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "首字母提示";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // back_button
            // 
            this.back_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.back_button.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.back_button.Location = new System.Drawing.Point(12, 884);
            this.back_button.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(117, 60);
            this.back_button.TabIndex = 14;
            this.back_button.Text = "返回";
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.IP);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRoomId);
            this.panel1.Controls.Add(this.score);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnJoin);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.btnBook1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1396, 953);
            this.panel1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(902, 548);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "定个房间号：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(902, 500);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "输入斩杀数：";
            // 
            // txtRoomId
            // 
            this.txtRoomId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoomId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRoomId.Location = new System.Drawing.Point(1025, 545);
            this.txtRoomId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(127, 31);
            this.txtRoomId.TabIndex = 12;
            // 
            // score
            // 
            this.score.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.score.Location = new System.Drawing.Point(1025, 497);
            this.score.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(127, 30);
            this.score.TabIndex = 11;
            this.score.Text = "10";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 1511);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 60);
            this.label2.TabIndex = 2;
            this.label2.Text = "返回";
            // 
            // Online_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 953);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Online_setting";
            this.Text = "大英默写器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCreate;
        private Button btnJoin;
        private TextBox IP;
        private CheckedListBox checkedListBox1;
        private Label label1;
        private CheckBox btnBook1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox5;
        private Label back_button;
        private Panel panel1;
        private Label label2;
        private TextBox score;
        private TextBox txtRoomId;
        private Label label4;
        private Label label3;
    }
}