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
    partial class About
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
            linkLabel1 = new LinkLabel();
            back_button = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel1.Font = new Font("微软雅黑", 24F, FontStyle.Bold, GraphicsUnit.Point, 134);
            linkLabel1.Location = new Point(12, 78);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(776, 105);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "作者：郭屹城";
            linkLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // back_button
            // 
            back_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            back_button.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            back_button.Location = new Point(12, 381);
            back_button.Name = "back_button";
            back_button.Size = new Size(197, 60);
            back_button.TabIndex = 1;
            back_button.Text = "返回";
            back_button.Click += back_button_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(664, 399);
            label1.Name = "label1";
            label1.Size = new Size(124, 42);
            label1.TabIndex = 2;
            label1.Text = "V0.99";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(back_button);
            Controls.Add(linkLabel1);
            Name = "About";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private LinkLabel linkLabel1;
        private Label back_button;
        private Label label1;
    }
}