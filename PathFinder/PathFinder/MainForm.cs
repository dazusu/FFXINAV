using PathFinder.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class MainForm : Form
    {
        public ffxiProcess ffxiprocess { get; set; }
        public Log Logger { get; set; }

        private WebClient Client { get; }

        public MainForm()
        {
            try
            {
                InitializeComponent();

                Logger = new Log();
                ffxiprocess = new ffxiProcess(this);
                Client = new WebClient();
                Check();
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(CheckedItemsRTB, ex.ToString());
                Logger.LogFile(ex.Message, FindForm().Name);
            }
        }

        public void Check()
        {
            try
            {
                if (DoWeHaveAllNeededFiles())
                {
                    ffxiprocess.GetProcess();
                }
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(CheckedItemsRTB, ex.ToString());
            }
        }

        public bool DoWeHaveAllNeededFiles()
        {
            try
            {
                string NetVersion = Environment.Version.ToString();
                Logger.AddDebugText(CheckedItemsRTB, string.Format(@".NetFramework v  = ({0})", NetVersion));
                if (!NetVersion.Contains("4."))
                {
                    Logger.AddDebugText(CheckedItemsRTB, "Please Update your .Net framework, https://www.microsoft.com/en-us/download/details.aspx?id=53344");
                    return false;
                }

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                Logger.AddDebugText(CheckedItemsRTB, string.Format(@"Servus Version ({0})", version));

                if (File.Exists("EliteAPI.dll"))
                {
                    FileVersionInfo EliteAPIVersion = FileVersionInfo.GetVersionInfo("EliteAPI.dll");
                    Logger.AddDebugText(CheckedItemsRTB, string.Format(@"EliteAPI Found: Version: ({0})", EliteAPIVersion.FileVersion));
                }
                if (!File.Exists("EliteAPI.dll"))
                {
                    Logger.AddDebugText(CheckedItemsRTB, string.Format(@"EliteAPI Missing"));
                    Logger.AddDebugText(CheckedItemsRTB, "Getting Latest EliteAPI.dll");
                    Client.DownloadFile("http://ext.elitemmonetwork.com/downloads/eliteapi/EliteAPI.dll", "EliteAPI.dll");
                }
                if (File.Exists("FFXINAV.dll"))
                {
                    Logger.AddDebugText(CheckedItemsRTB, string.Format(@"FFXINAV.dll Found"));
                }
                else if (!File.Exists("FFXINAV.dll"))
                {
                    Logger.AddDebugText(CheckedItemsRTB, @"FFXINAV.dll is missing");
                }

                if (File.Exists("EliteMMO.API.dll"))
                {
                    FileVersionInfo EliteAPIVersion = FileVersionInfo.GetVersionInfo("EliteMMO.API.dll");
                    Logger.AddDebugText(CheckedItemsRTB, string.Format(@"EliteMMO.API Found: Version: ({0})", EliteAPIVersion.FileVersion));
                }
                else if (!File.Exists("EliteMMO.API.dll"))
                {
                    Logger.AddDebugText(CheckedItemsRTB, "EliteMMO.API MISSING");
                    Logger.AddDebugText(CheckedItemsRTB, "Getting Latest EliteMMO.API.dll");
                    Client.DownloadFile("http://ext.elitemmonetwork.com/downloads/elitemmo_api/EliteMMO.API.dll", "EliteMMO.API.dll");
                }

                Logger.AddDebugText(CheckedItemsRTB, @"Finished checking files");
            }
            catch (Exception ex)
            {
                Logger.LogFile(ex.Message, "CheckNeededFiles");
                Logger.AddDebugText(CheckedItemsRTB, ex.ToString());
                return false;
            }
            Client.Dispose();
            return true;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ffxiprocess._CharacterDictionary.Count < 1 && NextBtn.Text == "Refresh")
                {
                    NextBtn.Text = "Next";
                    ffxiprocess.GetProcess();
                }
                if (ffxiprocess._CharacterDictionary.Count > 0 && NextBtn.Text == "Next")
                {
                    ffxiprocess.AddToons();
                    NextBtn.Visible = false;
                    CheckedItemsRTB.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogFile(ex.Message, FindForm().Name);
            }
        }
    }
}