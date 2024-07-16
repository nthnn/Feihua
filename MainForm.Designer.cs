/*
 * Copyright 2024 Nathanne Isip
 * 
 * Permission is hereby granted, free of charge,
 * to any person obtaining a copy of this software
 * and associated documentation files (the “Software”),
 * to deal in the Software without restriction,
 * including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions
 * of the Software.
 */

namespace Feihua
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Banner = new PictureBox();
            CloseButton = new Button();
            FileFolderLabel = new Label();
            FileTextBox = new TextBox();
            BrowseButton = new Button();
            LogTextBox = new TextBox();
            UpdateDatabaseButton = new Button();
            MinimizeButton = new Button();
            ScanFileButton = new Button();
            ClearLogsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Banner).BeginInit();
            SuspendLayout();
            // 
            // Banner
            // 
            Banner.BackColor = Color.Transparent;
            Banner.BackgroundImageLayout = ImageLayout.None;
            Banner.Image = Properties.Resources.banner;
            Banner.Location = new Point(216, 12);
            Banner.Name = "Banner";
            Banner.Size = new Size(102, 15);
            Banner.SizeMode = PictureBoxSizeMode.Zoom;
            Banner.TabIndex = 0;
            Banner.TabStop = false;
            Banner.Click += BannerClick;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Transparent;
            CloseButton.BackgroundImage = Properties.Resources.close_active;
            CloseButton.BackgroundImageLayout = ImageLayout.Stretch;
            CloseButton.Cursor = Cursors.Hand;
            CloseButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Location = new Point(506, 12);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(15, 15);
            CloseButton.TabIndex = 1;
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButtonEvent;
            CloseButton.MouseEnter += CloseButtonEnter;
            CloseButton.MouseLeave += CloseButtonExit;
            // 
            // FileFolderLabel
            // 
            FileFolderLabel.AutoSize = true;
            FileFolderLabel.BackColor = Color.Transparent;
            FileFolderLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FileFolderLabel.ForeColor = Color.Gainsboro;
            FileFolderLabel.Location = new Point(12, 38);
            FileFolderLabel.Name = "FileFolderLabel";
            FileFolderLabel.Size = new Size(77, 20);
            FileFolderLabel.TabIndex = 2;
            FileFolderLabel.Text = "Input File: ";
            FileFolderLabel.MouseDown += WindowMove;
            // 
            // FileTextBox
            // 
            FileTextBox.BackColor = Color.FromArgb(30, 30, 30);
            FileTextBox.BorderStyle = BorderStyle.FixedSingle;
            FileTextBox.Font = new Font("Consolas", 9.75F);
            FileTextBox.ForeColor = Color.FromArgb(0, 192, 0);
            FileTextBox.Location = new Point(98, 37);
            FileTextBox.Name = "FileTextBox";
            FileTextBox.Size = new Size(342, 23);
            FileTextBox.TabIndex = 3;
            FileTextBox.MouseDown += WindowMove;
            // 
            // BrowseButton
            // 
            BrowseButton.BackColor = Color.Transparent;
            BrowseButton.FlatAppearance.BorderColor = Color.DimGray;
            BrowseButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            BrowseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.ForeColor = Color.Gainsboro;
            BrowseButton.Location = new Point(446, 37);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(75, 23);
            BrowseButton.TabIndex = 4;
            BrowseButton.TabStop = false;
            BrowseButton.Text = "Browse";
            BrowseButton.TextAlign = ContentAlignment.TopCenter;
            BrowseButton.UseVisualStyleBackColor = false;
            BrowseButton.Click += BrowseFileFolderEvent;
            // 
            // LogTextBox
            // 
            LogTextBox.BackColor = Color.FromArgb(30, 30, 30);
            LogTextBox.BorderStyle = BorderStyle.FixedSingle;
            LogTextBox.Font = new Font("Consolas", 9.75F);
            LogTextBox.ForeColor = Color.FromArgb(0, 192, 0);
            LogTextBox.Location = new Point(12, 68);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(509, 162);
            LogTextBox.TabIndex = 5;
            LogTextBox.Text = "FeiHua Virus Scanner/Checker v1.0.0\r\nCopyright 2024 (c) Nathanne Isip\r\n-------------------------------------------------";
            LogTextBox.MouseDown += WindowMove;
            // 
            // UpdateDatabaseButton
            // 
            UpdateDatabaseButton.BackColor = Color.Transparent;
            UpdateDatabaseButton.FlatAppearance.BorderColor = Color.DimGray;
            UpdateDatabaseButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            UpdateDatabaseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            UpdateDatabaseButton.FlatStyle = FlatStyle.Flat;
            UpdateDatabaseButton.ForeColor = Color.Gainsboro;
            UpdateDatabaseButton.Location = new Point(184, 236);
            UpdateDatabaseButton.Name = "UpdateDatabaseButton";
            UpdateDatabaseButton.Size = new Size(166, 25);
            UpdateDatabaseButton.TabIndex = 6;
            UpdateDatabaseButton.TabStop = false;
            UpdateDatabaseButton.Text = "Update Database";
            UpdateDatabaseButton.UseVisualStyleBackColor = false;
            // 
            // MinimizeButton
            // 
            MinimizeButton.BackColor = Color.Transparent;
            MinimizeButton.BackgroundImage = Properties.Resources.minimize_inactive;
            MinimizeButton.BackgroundImageLayout = ImageLayout.Stretch;
            MinimizeButton.Cursor = Cursors.Hand;
            MinimizeButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.FlatStyle = FlatStyle.Flat;
            MinimizeButton.Location = new Point(485, 12);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.Size = new Size(15, 15);
            MinimizeButton.TabIndex = 7;
            MinimizeButton.UseVisualStyleBackColor = false;
            MinimizeButton.Click += MinimizeButtonEvent;
            MinimizeButton.MouseEnter += MinimizeButtonEnter;
            MinimizeButton.MouseLeave += MinimizeButtonExit;
            // 
            // ScanFileButton
            // 
            ScanFileButton.BackColor = Color.Transparent;
            ScanFileButton.FlatAppearance.BorderColor = Color.DimGray;
            ScanFileButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            ScanFileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            ScanFileButton.FlatStyle = FlatStyle.Flat;
            ScanFileButton.ForeColor = Color.Gainsboro;
            ScanFileButton.Location = new Point(12, 236);
            ScanFileButton.Name = "ScanFileButton";
            ScanFileButton.Size = new Size(166, 25);
            ScanFileButton.TabIndex = 8;
            ScanFileButton.TabStop = false;
            ScanFileButton.Text = "Scan File";
            ScanFileButton.UseVisualStyleBackColor = false;
            ScanFileButton.Click += ScanFileEvent;
            // 
            // ClearLogsButton
            // 
            ClearLogsButton.BackColor = Color.Transparent;
            ClearLogsButton.FlatAppearance.BorderColor = Color.DimGray;
            ClearLogsButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
            ClearLogsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
            ClearLogsButton.FlatStyle = FlatStyle.Flat;
            ClearLogsButton.ForeColor = Color.Gainsboro;
            ClearLogsButton.Location = new Point(356, 236);
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Size = new Size(166, 25);
            ClearLogsButton.TabIndex = 9;
            ClearLogsButton.TabStop = false;
            ClearLogsButton.Text = "Clear Logs";
            ClearLogsButton.UseVisualStyleBackColor = false;
            ClearLogsButton.Click += ClearLogsEvent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = Properties.Resources.feihua_bg;
            ClientSize = new Size(533, 273);
            Controls.Add(ClearLogsButton);
            Controls.Add(ScanFileButton);
            Controls.Add(MinimizeButton);
            Controls.Add(UpdateDatabaseButton);
            Controls.Add(LogTextBox);
            Controls.Add(BrowseButton);
            Controls.Add(FileTextBox);
            Controls.Add(FileFolderLabel);
            Controls.Add(CloseButton);
            Controls.Add(Banner);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FeiHua";
            Activated += FormLoad;
            Load += FormLoad;
            Shown += FormLoad;
            MouseDown += WindowMove;
            ((System.ComponentModel.ISupportInitialize)Banner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Banner;
        private Button CloseButton;
        private Label FileFolderLabel;
        private TextBox FileTextBox;
        private Button BrowseButton;
        private TextBox LogTextBox;
        private Button UpdateDatabaseButton;
        private Button MinimizeButton;
        private Button ScanFileButton;
        private Button ClearLogsButton;
    }
}
