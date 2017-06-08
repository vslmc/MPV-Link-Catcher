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
        }

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
                        string s2 = match.Value;
                        URLTextbox.Text = text;
                        Process.Start("mpv.exe", URLTextbox.Text);
                    }
                }
            }
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (BootCheckbox.Checked)
            {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    registryKey.SetValue("ApplicationName", Application.ExecutablePath);

            }
            else if (!BootCheckbox.Checked)
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}
