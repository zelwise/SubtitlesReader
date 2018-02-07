﻿using System.Windows.Forms;

namespace SubtitlesReader
{
    partial class Form1
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
            this.ChooseFile1Button = new System.Windows.Forms.Button();
            this.ChooseFile2Button = new System.Windows.Forms.Button();
            this.File1FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.File2FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.File2TextBox = new System.Windows.Forms.TextBox();
            this.File1TextBox = new System.Windows.Forms.TextBox();
            this.File1OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.File2OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.File1ContentTextBox = new System.Windows.Forms.TextBox();
            this.File2ContentTextBox = new System.Windows.Forms.TextBox();
            this.ContentVScrollBar = new System.Windows.Forms.VScrollBar();
            this.CorrectionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseFile1Button
            // 
            this.ChooseFile1Button.Location = new System.Drawing.Point(396, 10);
            this.ChooseFile1Button.Name = "ChooseFile1Button";
            this.ChooseFile1Button.Size = new System.Drawing.Size(88, 23);
            this.ChooseFile1Button.TabIndex = 0;
            this.ChooseFile1Button.Text = "Choose File 1";
            this.ChooseFile1Button.UseVisualStyleBackColor = true;
            this.ChooseFile1Button.Click += new System.EventHandler(this.ChooseFile1Button_Click);
            // 
            // ChooseFile2Button
            // 
            this.ChooseFile2Button.Location = new System.Drawing.Point(396, 39);
            this.ChooseFile2Button.Name = "ChooseFile2Button";
            this.ChooseFile2Button.Size = new System.Drawing.Size(88, 23);
            this.ChooseFile2Button.TabIndex = 1;
            this.ChooseFile2Button.Text = "Choose File 2";
            this.ChooseFile2Button.UseVisualStyleBackColor = true;
            this.ChooseFile2Button.Click += new System.EventHandler(this.ChooseFile2Button_Click);
            // 
            // File2TextBox
            // 
            this.File2TextBox.Location = new System.Drawing.Point(12, 38);
            this.File2TextBox.Name = "File2TextBox";
            this.File2TextBox.Size = new System.Drawing.Size(378, 20);
            this.File2TextBox.TabIndex = 2;
            // 
            // File1TextBox
            // 
            this.File1TextBox.Location = new System.Drawing.Point(12, 12);
            this.File1TextBox.Name = "File1TextBox";
            this.File1TextBox.Size = new System.Drawing.Size(378, 20);
            this.File1TextBox.TabIndex = 3;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(500, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(45, 46);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // File1ContentTextBox
            // 
            this.File1ContentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File1ContentTextBox.Location = new System.Drawing.Point(12, 83);
            this.File1ContentTextBox.Multiline = true;
            this.File1ContentTextBox.Name = "File1ContentTextBox";
            this.File1ContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.File1ContentTextBox.Size = new System.Drawing.Size(485, 145);
            this.File1ContentTextBox.TabIndex = 5;
            this.File1ContentTextBox.WordWrap = false;
            // File2ContentTextBox
            // 
            this.File2ContentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File2ContentTextBox.Location = new System.Drawing.Point(12, 231);
            this.File2ContentTextBox.Multiline = true;
            this.File2ContentTextBox.Name = "File2ContentTextBox";
            this.File2ContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.File2ContentTextBox.Size = new System.Drawing.Size(485, 145);
            this.File2ContentTextBox.TabIndex = 6;
            this.File2ContentTextBox.WordWrap = false;
            // ContentVScrollBar
            // 
            this.ContentVScrollBar.Location = new System.Drawing.Point(500, 109);
            this.ContentVScrollBar.Name = "ContentVScrollBar";
            this.ContentVScrollBar.Size = new System.Drawing.Size(45, 267);
            this.ContentVScrollBar.TabIndex = 7;
            this.ContentVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ContentVScrollBar_Scroll);
            // 
            // CorrectionNumericUpDown
            // 
            this.CorrectionNumericUpDown.Location = new System.Drawing.Point(500, 83);
            this.CorrectionNumericUpDown.Name = "CorrectionNumericUpDown";
            this.CorrectionNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.CorrectionNumericUpDown.TabIndex = 9;
            this.CorrectionNumericUpDown.ValueChanged += new System.EventHandler(this.CorrectionNumericUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 390);
            this.Controls.Add(this.CorrectionNumericUpDown);
            this.Controls.Add(this.ContentVScrollBar);
            this.Controls.Add(this.File2ContentTextBox);
            this.Controls.Add(this.File1ContentTextBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.File1TextBox);
            this.Controls.Add(this.File2TextBox);
            this.Controls.Add(this.ChooseFile2Button);
            this.Controls.Add(this.ChooseFile1Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseFile1Button;
        private System.Windows.Forms.Button ChooseFile2Button;
        private System.Windows.Forms.FolderBrowserDialog File1FolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog File2FolderBrowserDialog;
        private System.Windows.Forms.TextBox File2TextBox;
        private System.Windows.Forms.TextBox File1TextBox;
        private System.Windows.Forms.OpenFileDialog File1OpenFileDialog;
        private System.Windows.Forms.OpenFileDialog File2OpenFileDialog;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox File1ContentTextBox;
        private System.Windows.Forms.TextBox File2ContentTextBox;
        private VScrollBar ContentVScrollBar;
        private NumericUpDown CorrectionNumericUpDown;
    }
}

