using EliteMMO.API;
using PathFinder.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PathFinder.Common
{
    public class ffxiProcess
    {
        public Dictionary<string, EliteAPI> _CharacterDictionary = new Dictionary<string, EliteAPI>();

        private int id;

        public ffxiProcess(MainForm mainform)
        {
            MF = mainform;
        }

        public EliteAPI Api { get; set; }
        public Character Character { get; set; }
        public MainForm MF { get; set; }
        public Process[] processes { get; set; }
        public ToonControl tc { get; set; }
        private System.Windows.Forms.TabControl _TabControl = new System.Windows.Forms.TabControl();

        public void AddToons()
        {
            try
            {
                foreach (var api in _CharacterDictionary.Values)
                {
                    tc = new ToonControl(MF, _CharacterDictionary, api);

                    TabPage tp = new TabPage() { Text = api.Player.Name };
                    tp.Controls.Add(tc);
                    tc.Dock = DockStyle.Fill;
                    _TabControl.Controls.Add(tp);
                    _TabControl.Dock = DockStyle.Fill;
                    _TabControl.Padding = new System.Drawing.Point(10, 10);
                }
                MF.ToonPanel.Controls.Add(_TabControl);

                MF.ToonPanel.BringToFront();
                MF.ToonPanel.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MF.Logger.LogFile(ex.Message, "ffxiProcess");
            }
        }

        public void GetProcess()
        {
            try
            {
                _CharacterDictionary.Clear();
                processes = Process.GetProcesses();
                var query = from p
                            in processes
                            where IsProcessFullyLoggedIn(p)
                            select p;
                if (query.Count() > 0)
                {
                    foreach (var process in query)
                    {
                        Api = new EliteAPI(process.Id);
                        _CharacterDictionary.Add(Api.Player.Name, Api);
                        MF.Logger.AddDebugText(MF.CheckedItemsRTB, string.Format(@"FFxi process found :- {0}", Api.Player.Name));
                        id = process.Id;
                        MF.NextBtn.Text = "Next";
                    }
                }
                else if (query.Count() < 1)
                {
                    MF.Logger.AddDebugText(MF.CheckedItemsRTB, "Failed to find Pol Process, Checking for Boot Process..");
                    _CharacterDictionary.Clear();
                    processes = Process.GetProcesses();
                    var query2 = from p
                                in processes
                                 where IsBootProcessFullyLoggedIn(p)
                                 select p;
                    if (query2.Count() > 0)
                    {
                        foreach (var process in query2)
                        {
                            Api = new EliteAPI(process.Id);
                            _CharacterDictionary.Add(Api.Player.Name, Api);
                            MF.Logger.AddDebugText(MF.CheckedItemsRTB, string.Format(@"FFxi process found :- {0}", Api.Player.Name));
                            id = process.Id;
                            MF.NextBtn.Text = "Next";
                        }
                    }
                    else if (query2.Count() < 1)
                    {
                        MF.Logger.AddDebugText(MF.CheckedItemsRTB, "Please make sure you are fully Logged into ffxi");
                        MF.NextBtn.Text = "Refresh";
                    }
                }
            }
            catch (Exception ex)
            {
                MF.Logger.LogFile(ex.Message, "ffxiProcess");
            }
        }

        private static bool IsProcessFullyLoggedIn(Process p)
        {
            return p.ProcessName.Contains("pol") &&
                !string.IsNullOrEmpty(p.MainWindowTitle)
                   && p.MainWindowTitle.Length > 2
                   && !p.MainWindowTitle.Contains("pol.exe")
                   && !p.MainWindowTitle.Contains("FINAL FANTASY XI")
                   && string.Compare(p.MainWindowTitle, "Final Fantasy XI", StringComparison.OrdinalIgnoreCase) != 0
                   && p.MainWindowTitle.IndexOf("PlayOnline", StringComparison.Ordinal) <= -1
                   && p.MainWindowTitle.IndexOf("Final Fantasy XI", StringComparison.Ordinal) <= -1;
        }

        private static bool IsBootProcessFullyLoggedIn(Process p)
        {
            return p.ProcessName.Contains("boot") &&
                !string.IsNullOrEmpty(p.MainWindowTitle)
                   && p.MainWindowTitle.Length > 2
                   && !p.MainWindowTitle.Contains("pol.exe")
                   && !p.MainWindowTitle.Contains("FINAL FANTASY XI")
                   && string.Compare(p.MainWindowTitle, "Final Fantasy XI", StringComparison.OrdinalIgnoreCase) != 0
                   && p.MainWindowTitle.IndexOf("PlayOnline", StringComparison.Ordinal) <= -1
                   && p.MainWindowTitle.IndexOf("Final Fantasy XI", StringComparison.Ordinal) <= -1;
        }
    }
}