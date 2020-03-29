using PathFinder.Characters;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PathFinder.Common
{
    public class Log
    {
        public Character character { get; set; }
        public float FontSize = 9;

        public void AddDebugText(RichTextBox tb, string text)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new Action<RichTextBox, string>(AddDebugText), tb, text);
            }
            else
            {
                tb.SelectionStart = tb.Text.Length;
                tb.SelectionFont = new Font("Tahoma", FontSize, FontStyle.Regular); //delete if not letting user set font
                tb.SelectionColor = System.Drawing.Color.DarkMagenta;
                tb.SelectedText += DateTime.Now;
                tb.SelectionStart = tb.Text.Length;
                tb.SelectionColor = System.Drawing.Color.White;
                tb.SelectedText += " ";
                tb.SelectedText += text;
                tb.SelectedText += Environment.NewLine;
                tb.SelectionStart = tb.Text.Length - 1;
                tb.ScrollToCaret();
            }
        }

        public void ClearLog()
        {
            try
            {
                if (File.Exists("Log.txt"))
                {
                    FileInfo fi = new FileInfo("Log.txt");
                    if (fi.LastAccessTime < DateTime.Now.AddDays(-7))
                    {
                        using (new StreamWriter(fi.Open(FileMode.Truncate)))
                        {
                        }
                    }
                }
                else if (!File.Exists("Log.txt"))
                {
                    using (File.CreateText("Log.txt"))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                using (TextWriter writer = File.CreateText("Log.txt"))
                    writer.Write(ex);
            }
        }

        public void LogFile(string sExceptionName, string sFormName, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            try
            {
                if (File.Exists("Log.txt"))
                {
                    using (TextWriter tw = File.AppendText("Log.txt"))
                    {
                        tw.WriteLine(string.Format(@"{0}, {1}, at line {2},({3}) ,{4}", DateTime.Now.ToString(), sExceptionName, lineNumber, caller, sFormName));
                        tw.Close();
                    }
                }
                else if (!File.Exists("Log.txt"))
                {
                    using (File.CreateText("Log.txt"))
                    {
                    }

                    using (TextWriter tw = File.AppendText("Log.txt"))
                    {
                        tw.WriteLine(string.Format(@"{0}, {1}, at line {2},({3}) ,{4}", DateTime.Now.ToString(), sExceptionName, lineNumber, caller, sFormName));
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                using (TextWriter tw = File.CreateText("Log.txt"))
                {
                    tw.WriteLine(@"{0}, {1}, at line {2},({3}) ,{4}", DateTime.Now, ex, lineNumber, caller, sFormName);
                    tw.Close();
                }
            }
        }

        public void SaveChatLogs(RichTextBox rtb, string name)
        {
            try
            {
                using (SaveFileDialog diaLog = new SaveFileDialog())
                {
                    diaLog.InitialDirectory = (string.Format(Application.StartupPath + "\\Documents\\{0}\\ChatLog\\", name));
                    diaLog.RestoreDirectory = true;
                    diaLog.DefaultExt = "*.txt";
                    diaLog.Filter = "TXT Files|*.txt";
                    if ((diaLog.ShowDialog() == DialogResult.OK) && (diaLog.FileName.Length > 0))
                    {
                        rtb.SaveFile(diaLog.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile(ex.Message, "Log");
            }
        }
    }
}