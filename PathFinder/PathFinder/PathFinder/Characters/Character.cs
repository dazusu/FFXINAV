using EliteMMO.API;
using PathFinder.Common;
using PathFinder.Common.Servus_v2.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PathFinder.Characters
{
    public class Character
    {
        public List<string> Targets { get; set; }
        public Dictionary<string, EliteAPI> _CharacterDictionary;
        public EntityStatus Status { get; private set; }
        public EliteAPI MonitoredAPI { get; set; }
        public Navigation Navi { get; set; }
        public int SearchDistance { get; set; } = 50;
        public List<PointsOfInterest> Points { get; set; }
        public Character(Log Log, ToonControl tc, Dictionary<string, EliteAPI> chars, EliteAPI api)
        {
            Logger = Log;
            Tc = tc;
            _CharacterDictionary = chars;
            Api = api;
            Targets = new List<string>();
            Navi = new Navigation(this);
            Target = new Target(this);
            Points = new List<PointsOfInterest>();
            CreateFolders();
        }

        public event EventHandler<NavigationEventArgs> Moved = delegate { };

        public EliteAPI Api { get; set; }

        public bool IsMoving { get; set; }
        public EliteAPI Leader { get; set; }
        public Log Logger { get; set; }
        public ToonControl Tc { get; set; }
        public Target Target { get; set; }
        public int PullDistance { get; set; } = 12;

        public void CreateFolders()
        {
            if (!System.IO.Directory.Exists(string.Format(@"Documents\NavMeshes")))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"Documents\NavMeshes"));
            }
            if (!System.IO.Directory.Exists(string.Format(@"Documents\{0}\ChatLog", Api.Player.Name)))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"Documents\{0}\ChatLog", Api.Player.Name));
            }
            if (!System.IO.Directory.Exists(string.Format(@"Documents\{0}\Nav", Api.Player.Name)))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"Documents\{0}\Nav", Api.Player.Name));
            }
            if (!System.IO.Directory.Exists(string.Format(@"Documents\{0}\Config", Api.Player.Name)))
            {
                System.IO.Directory.CreateDirectory(string.Format(@"Documents\{0}\Config", Api.Player.Name));
            }
        }

        public bool IsEngaged()
        {
            return Api.Player.Status == (ulong)EntityStatus.Engaged;
        }

        public bool IsTargetLocked()
        {
            var _Target = Api.Target.GetTargetInfo();
            if (_Target.TargetIndex == (uint)Target.FindBestTarget() && _Target.LockedOn)
            {
                return true;
            }
            return false;
        }

        protected virtual void OnMoved(NavigationEventArgs e)
        {
            Moved(this, e);
        }

        public Position OldPosition { get; set; }
        public Position CurrentPosition => new Position { X = Api.Player.X, Y = Api.Player.Y, Z = Api.Player.Z, H = Api.Player.H };

        public void SavePointsOfInterest()
        {
            try
            {
                string PATH = (string.Format(Application.StartupPath + "\\Documents\\Points of intrest"));

                SaveFileDialog SaveDialog = new SaveFileDialog
                {
                    InitialDirectory = PATH,
                    Filter = "xml |*.xml",
                    FilterIndex = 1
                };
                string Filename;
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (SaveDialog.FileName.Contains(".xml"))
                        Filename = SaveDialog.FileName;
                    else
                        Filename = SaveDialog.FileName + ".xml";
                    XmlSerializationHelper.Serialize(Filename, Points);
                }
                SaveDialog.Dispose();
            }
            catch (Exception ex)
            {
                Logger.AddDebugText(Tc.rtbDebug, string.Format(@"Error Saving {0}", ex));
            }
        }

        public void LoadPointsOfInterest()
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            Tc.PointsComboBox.Items.Clear();
            string PATH = (string.Format(Application.StartupPath + "\\Documents\\Points of intrest"));
            OpenDialog.InitialDirectory = PATH;
            OpenDialog.FilterIndex = 0;

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                Navi.Reset();
                Points.Clear();

                string PointsFilename = OpenDialog.FileName;
                Logger.AddDebugText(Tc.rtbDebug, string.Format(@"Nav file loaded = {0}", PointsFilename));
                try
                {
                    Points = XmlSerializationHelper.Deserialize<List<PointsOfInterest>>(PointsFilename) ?? new List<PointsOfInterest>();
        
                    OpenDialog.Dispose();
                   foreach( var item in Points)
                    {
                        Tc.PointsComboBox.Items.Add(item.Name);
                        
                    }
                    Logger.AddDebugText(Tc.rtbDebug,string.Format(@"Added {0} Points of interest", Points.Count.ToString()));
                    Tc.PointsComboBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    Logger.AddDebugText(Tc.rtbDebug, string.Format(@"LoadWaypoints error {0}", ex.ToString()));
                 
                }
            }
        }
    }
}
