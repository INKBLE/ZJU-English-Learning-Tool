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
    partial class Online_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Online_Game));
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelCN = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.panelRope = new System.Windows.Forms.Panel();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblMe = new System.Windows.Forms.Label();
            this.lblKnot = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.panelRope.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 172);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1441, 47);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "重启下服务器呢";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHint
            // 
            this.labelHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHint.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelHint.Location = new System.Drawing.Point(13, 273);
            this.labelHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(1441, 99);
            this.labelHint.TabIndex = 2;
            this.labelHint.Text = "Loading";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCN
            // 
            this.labelCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCN.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.labelCN.Location = new System.Drawing.Point(12, 372);
            this.labelCN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(1441, 161);
            this.labelCN.TabIndex = 3;
            this.labelCN.Text = "Loading";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInput.Location = new System.Drawing.Point(486, 536);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(526, 30);
            this.txtInput.TabIndex = 4;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelResult.Location = new System.Drawing.Point(13, 536);
            this.labelResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(1441, 91);
            this.labelResult.TabIndex = 5;
            this.labelResult.Text = "Loading";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRope
            // 
            this.panelRope.BackColor = System.Drawing.Color.White;
            this.panelRope.Controls.Add(this.lblEnemy);
            this.panelRope.Controls.Add(this.lblMe);
            this.panelRope.Controls.Add(this.lblKnot);
            this.panelRope.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRope.Location = new System.Drawing.Point(0, 825);
            this.panelRope.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelRope.Name = "panelRope";
            this.panelRope.Size = new System.Drawing.Size(1465, 100);
            this.panelRope.TabIndex = 6;
            // 
            // lblEnemy
            // 
            this.lblEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEnemy.AutoSize = true;
            this.lblEnemy.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.lblEnemy.Location = new System.Drawing.Point(2, 39);
            this.lblEnemy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(70, 52);
            this.lblEnemy.TabIndex = 2;
            this.lblEnemy.Text = "🪮";
            // 
            // lblMe
            // 
            this.lblMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMe.AutoSize = true;
            this.lblMe.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.lblMe.Location = new System.Drawing.Point(1385, 39);
            this.lblMe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(70, 52);
            this.lblMe.TabIndex = 1;
            this.lblMe.Text = "🪮";
            // 
            // lblKnot
            // 
            this.lblKnot.AutoSize = true;
            this.lblKnot.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.lblKnot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKnot.Location = new System.Drawing.Point(306, 25);
            this.lblKnot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKnot.Name = "lblKnot";
            this.lblKnot.Size = new System.Drawing.Size(446, 52);
            this.lblKnot.TabIndex = 0;
            this.lblKnot.Text = "😫自己🫸 🚚 🫷对手😫";
            // 
            // labelAnswer
            // 
            this.labelAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAnswer.ForeColor = System.Drawing.Color.Green;
            this.labelAnswer.Location = new System.Drawing.Point(1, 228);
            this.labelAnswer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(1453, 85);
            this.labelAnswer.TabIndex = 7;
            this.labelAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Online_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 925);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.panelRope);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.labelCN);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Online_Game";
            this.Text = "大英默写器";
            this.panelRope.ResumeLayout(false);
            this.panelRope.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblStatus;
        private Label labelHint;
        private Label labelCN;
        private TextBox txtInput;
        private Label labelResult;
        private Panel panelRope;
        private Label lblEnemy;
        private Label lblMe;
        private Label lblKnot;
        private Label labelAnswer;
    }
}