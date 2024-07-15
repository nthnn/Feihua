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

using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Feihua
{
    public partial class MainForm : Form
    {
        private UpdaterUtil Updater = new UpdaterUtil();

        public MainForm()
        {
            InitializeComponent();

            GraphicsPath CircularPath = new GraphicsPath();
            CircularPath.AddEllipse(0, 0, 15, 15);

            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.CloseButton.Region = new Region(CircularPath);

            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.MinimizeButton.Region = new Region(CircularPath);

            this.Banner.Cursor = Cursors.Arrow;
            this.LogTextBox.Cursor = Cursors.Arrow;
            this.UpdateDatabaseButton.Click += this.Updater.ButtonClickHandler;

            Win32GUIUtil.SendMessage(this.FileTextBox.Handle, Win32GUIUtil.EM_SETCUEBANNER, 0, "File/Folder to scan...");
        }

        public void CloseButtonEvent(object Sender, EventArgs Args)
        {
            Win32GUIUtil.AnimateWindow(this.Handle, 400, Win32GUIUtil.AW_VER_NEGATIVE | Win32GUIUtil.AW_SLIDE | Win32GUIUtil.AW_HIDE);
            Environment.Exit(0);
        }

        private void CloseButtonEnter(object sender, EventArgs e) =>
            this.CloseButton.BackgroundImage = ((Image)(Properties.Resources.close_active));

        private void CloseButtonExit(object sender, EventArgs e) =>
            this.CloseButton.BackgroundImage = ((Image)(Properties.Resources.close_inactive));

        public void MinimizeButtonEvent(object Sender, EventArgs Args)
        {
            Win32GUIUtil.AnimateWindow(this.Handle, 400, Win32GUIUtil.AW_VER_NEGATIVE | Win32GUIUtil.AW_SLIDE | Win32GUIUtil.AW_HIDE);
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButtonEnter(object sender, EventArgs e) =>
            this.MinimizeButton.BackgroundImage = ((Image)(Properties.Resources.minimize_active));

        private void MinimizeButtonExit(object sender, EventArgs e) =>
            this.MinimizeButton.BackgroundImage = ((Image)(Properties.Resources.minimize_inactive));

        private void BannerClick(object sender, EventArgs e) =>
            MainForm.OpenUrl("https://github.com/nthnn/Feihua");

        private void FormLoad(object sender, EventArgs e) =>
            Win32GUIUtil.AnimateWindow(this.Handle, 400, Win32GUIUtil.AW_VER_POSITIVE | Win32GUIUtil.AW_SLIDE);

        private void ClearLogsEvent(object sender, EventArgs e) =>
            this.LogTextBox.Text = "FeiHua Virus Scanner/Checker v1.0.0\r\n" +
                "Copyright 2024 (c) Nathanne Isip\r\n" +
                "-------------------------------------------------\r\n";

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                Win32GUIUtil.ReleaseCapture();
                Win32GUIUtil.SendMessage(this.Handle, Win32GUIUtil.WM_NCLBUTTONDOWN, Win32GUIUtil.HT_CAPTION, 0);
            }
        }

        private void BrowseFileFolderEvent(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select File or Folder";
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select folder or file";
                dialog.Filter = "All files (*.*)|*.*";

                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.FileTextBox.Text = dialog.FileName;
                }
            }
        }

        private static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
