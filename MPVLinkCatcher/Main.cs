using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MPVLinkCatcher
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ClipboardListener = SetClipboardViewer(this.Handle);

            RegistryKey AutoStartPath = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string valueName = "MPV-LC";

            if (AutoStartPath.GetValue(valueName) == null)
            { BootCheckbox.Checked = false; }

            else
            { BootCheckbox.Checked = true; }
        }

        RegistryKey AutoStartPath = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private IntPtr ClipboardListener;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                IDataObject iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);

                    Regex regx = new Regex(@"((https?|ftp|rtmp|rtmpt|rtmpts|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);
                    MatchCollection URL = regx.Matches(text);

                    foreach (Match match in URL)
                    {
                        URLTextbox.Text = text;
                        Process.Start("mpv.exe", text);
                    }
                }
            }
        }


        string valueName = "MPV-LC";
        private void BootCheckboxClick(object sender, EventArgs e)
        {
            if (BootCheckbox.Checked)
            { AutoStartPath.SetValue(valueName, Application.ExecutablePath); }

            else
            { AutoStartPath.DeleteValue(valueName, false); }
        }

        private void HideButton(object sender, EventArgs e)
        {
            this.Hide();
            TrayIcon.Visible = true;
        }

        private void TrayIconClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        public void OKButton(object sender, EventArgs e)
        {
           Process.Start("mpv.exe", URLTextbox.Text);
        }
    }
}