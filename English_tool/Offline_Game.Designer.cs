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
    partial class Offline_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Offline_Game));
            this.labelCN = new System.Windows.Forms.Label();
            this.labelHint = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.pre_button = new System.Windows.Forms.Label();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCN
            // 
            this.labelCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCN.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.labelCN.Location = new System.Drawing.Point(12, 281);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(1284, 153);
            this.labelCN.TabIndex = 0;
            this.labelCN.Text = "label1";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHint
            // 
            this.labelHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHint.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelHint.Location = new System.Drawing.Point(12, 178);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(1284, 103);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "label1";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInput.Location = new System.Drawing.Point(385, 527);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(526, 30);
            this.txtInput.TabIndex = 2;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelResult.Location = new System.Drawing.Point(317, 434);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(660, 90);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "label1";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.labelAnswer);
            this.panel1.Controls.Add(this.labelResult);
            this.panel1.Controls.Add(this.pre_button);
            this.panel1.Controls.Add(this.btnSpeak);
            this.panel1.Controls.Add(this.back_button);
            this.panel1.Controls.Add(this.labelCN);
            this.panel1.Controls.Add(this.labelHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 727);
            this.panel1.TabIndex = 4;
            this.panel1.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAnswer.ForeColor = System.Drawing.Color.Green;
            this.labelAnswer.Location = new System.Drawing.Point(12, 93);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(1284, 85);
            this.labelAnswer.TabIndex = 5;
            this.labelAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pre_button
            // 
            this.pre_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pre_button.AutoSize = true;
            this.pre_button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.pre_button.Location = new System.Drawing.Point(12, 599);
            this.pre_button.Name = "pre_button";
            this.pre_button.Size = new System.Drawing.Size(278, 31);
            this.pre_button.TabIndex = 4;
            this.pre_button.Text = "手滑了，点我返回上一词";
            this.pre_button.Click += new System.EventHandler(this.pre_button_Click);
            // 
            // btnSpeak
            // 
            this.btnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeak.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.btnSpeak.Location = new System.Drawing.Point(1161, 640);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(116, 65);
            this.btnSpeak.TabIndex = 3;
            this.btnSpeak.TabStop = false;
            this.btnSpeak.Text = "🔊";
            this.btnSpeak.UseVisualStyleBackColor = true;
            // 
            // back_button
            // 
            this.back_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.back_button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.back_button.Location = new System.Drawing.Point(12, 672);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(225, 46);
            this.back_button.TabIndex = 2;
            this.back_button.Text = "点我返回首页(慎点)";
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Offline_Game
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1308, 727);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Offline_Game";
            this.Text = "大英默写器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelCN;
        private Label labelHint;
        private TextBox txtInput;
        private Label labelResult;
        private Panel panel1;
        private Label back_button;
        private Button btnSpeak;
        private Label pre_button;
        private Label labelAnswer;
    }
}