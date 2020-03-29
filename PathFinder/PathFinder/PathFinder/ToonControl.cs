using EliteMMO.API;
using PathFinder.Characters;
using PathFinder.Common;
using PathFinder.Common.Servus_v2.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PathFinder
{
    public partial class ToonControl : UserControl
    {
        private string oldString;

        public Character Character { get; set; }
        public FFXINAV FFxiNAV { get; set; }

        public ToonControl(MainForm mf, Dictionary<string, EliteAPI> chars, EliteAPI api)
        {
            InitializeComponent();
            Character = new Character(mf.Logger, this, chars, api);
            TargetComboBox.SelectedIndex = 0;
            FFxiNAV = new FFXINAV();
            Waypoints = new List<position_t>();
            TestWorker = new BackgroundWorker();
            TestWorker.WorkerSupportsCancellation = true;
            TestWorker.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
            Ppoint = new PointsOfInterest();
            TestWorker.DoWork += TestWorker_DoWork;
            Posi = new position_t();
            KeepMovingStartPosi = new position_t();
        }

        private void ScantBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Character.Logger.AddDebugText(rtbDebug, "Scanning for Npcs");
                Character.Target.GetNpcNames();
                NpcLB.Items.Clear();
                foreach (string name in Character.Target.GetNpcNames())
                {
                    if (!NpcLB.Items.Contains(name))
                    {
                        NpcLB.Items.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                Character.Logger.LogFile(ex.Message, FindForm().Name);
            }
        }

        private void NpcLB_DoubleClick(object sender, EventArgs e)
        {
            if (!Character.Targets.Contains(NpcLB.SelectedItem.ToString()))
            {
                Character.Targets.Add(NpcLB.SelectedItem.ToString());
                TargetCountLb.Text = string.Format(@"Target count = {0}", Character.Targets.Count);
                TargetComboBox.Items.Add(NpcLB.SelectedItem.ToString());
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"Added {0} to kill list", NpcLB.SelectedItem)));
            }
            else if (Character.Targets.Contains(NpcLB.SelectedItem.ToString()))
            {
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"{0} Is already in kill list", NpcLB.SelectedItem)));
            }
        }

        private void AddTargetBtn_Click(object sender, EventArgs e)
        {
            if (!Character.Targets.Contains(NpcLB.SelectedItem.ToString()))
            {
                Character.Targets.Add(NpcLB.SelectedItem.ToString());
                TargetCountLb.Text = string.Format(@"Target count = {0}", Character.Targets.Count);
                TargetComboBox.Items.Add(NpcLB.SelectedItem.ToString());
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"Added {0} to kill list", NpcLB.SelectedItem.ToString())));
            }
            else if (Character.Targets.Contains(NpcLB.SelectedItem.ToString()))
            {
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"{0} Is already in kill list", NpcLB.SelectedItem.ToString())));
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (Character.Targets.Contains(TargetComboBox.SelectedItem.ToString()) && !TargetComboBox.SelectedItem.Equals("View Targets"))
            {
                Character.Targets.Remove(TargetComboBox.SelectedItem.ToString());
                TargetCountLb.Text = string.Format(@"Target count = {0}", Character.Targets.Count);
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"Removed {0} from kill list", TargetComboBox.SelectedItem)));
                TargetComboBox.Items.Remove(TargetComboBox.SelectedItem);
                TargetComboBox.SelectedIndex = 0;
            }
            else if (!Character.Targets.Contains(NpcLB.SelectedItem.ToString()) && !TargetComboBox.SelectedItem.Equals("View Targets"))
            {
                Character.Logger.AddDebugText(rtbDebug, (string.Format(@"{0} Was not in kill list, Unable to remove", TargetComboBox.SelectedItem)));
            }
        }

        private void ClearTargetsBtn_Click(object sender, EventArgs e)
        {
            Character.Targets.Clear();
            TargetCountLb.Text = string.Format(@"Target count = {0}", Character.Targets.Count);
            Character.Logger.AddDebugText(rtbDebug, (@"Cleared Targets"));
            TargetComboBox.Items.Clear();
            TargetComboBox.Items.Add("View Targets");
            TargetComboBox.SelectedIndex = 0;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (StartBtn.Text == "Start" && !TestWorker.IsBusy)
            {
                TestWorker.RunWorkerAsync();
                StartBtn.Text = "Stop";
            }
            else if (TestWorker.IsBusy)
            {
                Character.Navi.Reset();
                TestWorker.CancelAsync();
                StartBtn.Text = "Start";
                Character.Navi.Reset();
            }
        }

        private List<position_t> Waypoints { get; set; }
        public double dist { get; set; } = 0;

        public List<position_t> SmoothNodes(List<position_t> nodes)
        {
            List<position_t> SmoothLikeButter = new List<position_t>();
            int Index = 0;
            foreach (position_t node in nodes)
            {
                if (Index > 0 && Index != nodes.Count - 1)
                {
                    float nX = (nodes[Index - 1].X + nodes[Index].X + nodes[Index + 1].X) / 3;
                    float nZ = (nodes[Index - 1].Z + nodes[Index].Z + nodes[Index + 1].Z) / 3;
                    SmoothLikeButter.Add(new position_t { X = nX, Z = nZ });
                }
                if (Index == 0)
                {
                    float nX = (nodes[Index].X + nodes[Index + 1].X) / 2;
                    float nZ = (nodes[Index].Z + nodes[Index + 1].Z) / 2;
                    SmoothLikeButter.Add(new position_t { X = nX, Z = nZ });
                }
                if (Index == nodes.Count - 1)
                {
                    float nX = (nodes[Index - 1].X + nodes[Index].X) / 2;
                    float nZ = (nodes[Index - 1].Z + nodes[Index].Z) / 2;
                    SmoothLikeButter.Add(new position_t { X = nX, Z = nZ });
                }
                Index++;
            }
            return SmoothLikeButter;
        }

        public List<position_t> TempList { get; set; }

        private void TestWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!TestWorker.CancellationPending)
            {
                var start2 = new position_t { X = Character.Api.Player.X, Y = Character.Api.Player.Y, Z = Character.Api.Player.Z };

                var mob = Character.Api.Entity.GetEntity(Character.Target.FindBestTarget());
                var end = new position_t { X = mob.X, Z = mob.Z };
                var mobid = Character.Target.FindBestTarget();

                if (FFxiNAV.waypoints.Count > 0)
                {
                    foreach (var wp in FFxiNAV.waypoints)
                    {
                        dist = Character.Navi.DistanceTo(wp);
                        while (dist > 6 && !TestWorker.CancellationPending && mob.Distance > 6)
                        {
                            var start3 = new position_t { X = Character.Api.Player.X, Z = Character.Api.Player.Z };
                            dist = Character.Navi.DistanceTo(wp);
                            Character.Logger.AddDebugText(rtbDebug, string.Format(@"start x {0} target x {1} distance {2}", start3.X.ToString(), wp.X.ToString(), dist.ToString()));
                            Character.Navi.GoTo(wp.X, wp.Z);
                            Thread.Sleep(200);
                        }
                        if (mob.Distance < 5 && !TestWorker.CancellationPending)
                        {
                            Character.Navi.FaceHeading(end);
                            Character.Navi.Reset();
                            Character.Target.TargetNpc(mobid);
                            Thread.Sleep(100);
                            Character.Api.ThirdParty.SendString("/attack <t>");
                        }
                    }
                    if (mob.Distance > 2.5 && FFxiNAV.waypoints.Count > 0 && !TestWorker.CancellationPending)
                    {

                        var end1 = new position_t { X = mob.X, Z = mob.Z };
                        var mobid1 = Character.Target.FindBestTarget();
                        Character.Navi.FaceHeading(end1);
                        Character.Navi.MoveForwardTowardsPosition(end1, true);

                        Character.Navi.FaceHeading(end1);
                        Character.Navi.Reset();
                        Character.Target.TargetNpc(mobid1);
                        Thread.Sleep(100);
                        Character.Api.ThirdParty.SendString("/attack <t>");

                    }
                    if (mob.Distance < 3)
                    {
                        FFxiNAV.waypoints.Clear();
                        Character.Navi.Reset();
                        mob = null;
                        TestWorker.CancelAsync();
                        Character.Navi.Reset();
                    }
                }

                Thread.Sleep(200);
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialog = new OpenFileDialog();
                string PATH = (string.Format(Application.StartupPath));
                OpenDialog.InitialDirectory = PATH;
                OpenDialog.FilterIndex = 0;

                if (OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = OpenDialog.FileName;
                    FFxiNAV.Initialize(999999);
                    FFxiNAV.Load(path);
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh initialized, File Loaded = {0}", path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string newString = FFxiNAV.GetErrorMessage();
            if (oldString != newString)
            {
                Character.Logger.AddDebugText(rtbDebug, newString);
            }
            oldString = newString;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh is enabled = {0}", FFxiNAV.IsNavMeshEnabled().ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"Points in navmesh path = {0}", FFxiNAV.PathCount().ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var mob = Character.Target.FindBestTarget();

                var start = new position_t();
                var end = new position_t();
                start.X = (float)Character.Api.Player.X;
                start.Y = (float)Character.Api.Player.Y;
                start.Z = (float)Character.Api.Player.Z;
                start.Rotation = 0;
                start.Moving = 0;

                end.X = (float)Character.Api.Entity.GetEntity(mob).X;
                end.Y = (float)Character.Api.Entity.GetEntity(mob).Y;
                end.Z = (float)Character.Api.Entity.GetEntity(mob).Z;
                end.Rotation = 0;
                end.Moving = 0;

                if (mob != 0)
                {
                    var i = Character.Api.Entity.GetEntity(mob).Render0000;
                    var i2 = Character.Api.Entity.GetEntity(mob).Render0000 & 0x200;
                    var name = Character.Api.Entity.GetEntity(mob).Name;
                    var dist = Character.Navi.DistanceTo(mob);
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"render flags {0} {1}", i.ToString(), i2.ToString()));
                    Character.Logger.AddDebugText(rtbDebug, string.Format("Looking for path to {0} distance {1}y", name, dist.ToString()));
                    FFxiNAV.FindPath_DSP_NAV_Files(start, end);
                }
                if (mob == 0)
                {
                    Character.Logger.AddDebugText(rtbDebug, "Mob id = 0 so unable to find a path");
                }
            }
            catch (Exception ex)
            {
                Character.Logger.AddDebugText(rtbDebug, ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FFxiNAV.Unload();
        }

        public unsafe void Test()
        {
            FFxiNAV.TryGetWaypoints();
            // FFxiNAV.TryGetZWaypoints();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test();
            if (FFxiNAV.waypoints.Count > 0)
            {
                foreach (var item in FFxiNAV.waypoints)
                {
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"waypoint list x = {0} z = {1}", item.X.ToString(), item.Z.ToString()));
                }
            }
            else
                Character.Logger.AddDebugText(rtbDebug, "No Waypoints");
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                var mob = Character.Target.FindBestTarget();

                var start = new position_t();
                var end = new position_t();
                start.X = (float)Character.Api.Player.X;
                start.Y = (float)Character.Api.Player.Y;
                start.Z = (float)Character.Api.Player.Z;
                start.Rotation = 0;
                start.Moving = 0;

                end.X = (float)Character.Api.Entity.GetEntity(mob).X;
                end.Y = (float)Character.Api.Entity.GetEntity(mob).Y;
                end.Z = (float)Character.Api.Entity.GetEntity(mob).Z;
                end.Rotation = 0;
                end.Moving = 0;

                if (mob != 0)
                {
                    var i = Character.Api.Entity.GetEntity(mob).Render0000;
                    var i2 = Character.Api.Entity.GetEntity(mob).Render0000 & 0x200;
                    var name = Character.Api.Entity.GetEntity(mob).Name;
                    var dist = Character.Navi.DistanceTo(mob);
                    Character.Logger.AddDebugText(Character.Tc.rtbDebug, string.Format(@"render flags {0} {1}", i.ToString(), i2.ToString()));
                    Character.Logger.AddDebugText(rtbDebug, string.Format("Looking for path to {0} distance {1}y", name, dist.ToString()));
                    FFxiNAV.FindPath(start, end);
                }
                if (mob == 0)
                {
                    Character.Logger.AddDebugText(rtbDebug, "Mob id = 0 so unable to find a path");
                }
            }
            catch (Exception ex)
            {
                Character.Logger.AddDebugText(rtbDebug, ex.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialog = new OpenFileDialog();
                string PATH = (string.Format(Application.StartupPath));
                OpenDialog.InitialDirectory = PATH;
                OpenDialog.FilterIndex = 0;

                if (OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = OpenDialog.FileName;
                    FFxiNAV.Initialize(9999);
                    FFxiNAV.Load(path);
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh initialized, File Loaded = {0}", path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh is enabled = {0}", FFxiNAV.IsNavMeshEnabled().ToString()));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"Points in navmesh path = {0}", FFxiNAV.PathCount().ToString()));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Test();
            if (FFxiNAV.waypoints.Count > 0)
            {
                foreach (var item in FFxiNAV.waypoints)
                {
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"waypoint list x = {0} z = {1}", item.X.ToString(), item.Z.ToString()));
                }
            }
            else
                Character.Logger.AddDebugText(rtbDebug, "No Waypoints");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FFxiNAV.Unload();
        }

        private void rtbDebug_TextChanged(object sender, EventArgs e)
        {
            rtbDebug.SelectionStart = rtbDebug.Text.Length;
            rtbDebug.ScrollToCaret();
        }









        public position_t Posi = new position_t();
        public position_t KeepMovingStartPosi = new position_t();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (FFxiNAV.waypoints.Count > 0 && Character.Navi.DistanceTo(Posi) > 4 && !backgroundWorker1.CancellationPending)
            {
                foreach (var wp in FFxiNAV.waypoints)
                {
                    if (Character.Navi.DistanceTo(wp) > 3)
                    {
                        Character.Navi.GoTo(wp.X, wp.Z);
                        Character.Logger.AddDebugText(rtbDebug, string.Format(@"x {0} z {1} distance {2} Wp count = {3}", wp.X.ToString(), wp.Z, Character.Navi.DistanceTo(wp).ToString(),FFxiNAV.waypoints.Count.ToString()));

                    }
                }
                Character.Navi.Reset();
                FFxiNAV.waypoints.Clear();

            }
            if (Character.Navi.DistanceTo(Posi) > 4 && !backgroundWorker1.CancellationPending)
            {

                KeepMovingStartPosi.X = (float)Character.Api.Player.X;
                KeepMovingStartPosi.Y = (float)Character.Api.Player.Y;
                KeepMovingStartPosi.Z = (float)Character.Api.Player.Z;
                KeepMovingStartPosi.Rotation = 0;
                KeepMovingStartPosi.Moving = 0;
                backgroundWorker1.CancelAsync();


            }
            Thread.Sleep(10);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            FFxiNAV.FindPathToPosi(KeepMovingStartPosi, Posi);
            FFxiNAV.TryGetWaypoints();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (timer1.Enabled == true)
            {
                FFxiNAV.FindPathToPosi(KeepMovingStartPosi, Posi);
                if (Character.Navi.DistancetoWaypoint(KeepMovingStartPosi, Posi) > 4)
                {
                    FFxiNAV.TryGetWaypoints();
                }
                if (FFxiNAV.waypoints.Count > 0)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                    backgroundWorker1.CancelAsync();
                timer.Enabled = false;
            }
            else if (Character.Navi.DistancetoWaypoint(KeepMovingStartPosi, Posi) < 4)
            {
                Character.Logger.AddDebugText(rtbDebug, string.Format(@"here"));
                backgroundWorker1.CancelAsync();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Character.SearchDistance = Convert.ToInt32(numericUpDown1.Value);
        }
        public PointsOfInterest Ppoint { get; set; }


        private void button13_Click(object sender, EventArgs e)
        {
            Ppoint.ID = Character.Api.Player.ZoneId;
            Ppoint.Name = PointNametb.Text;
            Ppoint.X = Character.Api.Player.X;
            Ppoint.Y = Character.Api.Player.Y;
            Ppoint.Z = Character.Api.Player.Z;
            Character.Points.Add(Ppoint);
            PointsComboBox.Items.Add(Ppoint.Name);
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"{0} Added to Points of interest list", Ppoint.Name));

            PointsComboBox.SelectedIndex = 0;
        }


        private void saveHitPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Character.SavePointsOfInterest();
        }

        private void loadHitPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Character.LoadPointsOfInterest();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Character.Points.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Character.Points.Count > 0 && !backgroundWorker1.IsBusy)
                {
                    foreach (var item in Character.Points)
                    {
                        if (item.ID == Character.Api.Player.ZoneId && item.Name == PointsComboBox.SelectedItem.ToString())
                        {
                            Character.Logger.AddDebugText(rtbDebug, string.Format(@"Looking for a path to {0} x = {1} z = {2}", item.Name, item.X.ToString(), item.Z.ToString()));
                            KeepMovingStartPosi.X = Character.Api.Player.X;
                            KeepMovingStartPosi.Z = Character.Api.Player.Z;
                            Posi.X = item.X;
                            Posi.Y = item.Y;
                            Posi.Z = item.Z;
                        }
                    }
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Character.Logger.AddDebugText(rtbDebug, ex.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Start")
            {
                timer1.Start();
                timer1.Enabled = true;
                button12.Text = "Stop";
            }
         else if  (button12.Text == "Stop")
            {
               
                timer.Enabled = false;
                timer1.Stop();
                Character.Navi.Reset();
                backgroundWorker1.CancelAsync();
                button12.Text = "Start";
                Character.Navi.Reset();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDialog = new OpenFileDialog();
                string PATH = (string.Format(Application.StartupPath));
                OpenDialog.InitialDirectory = PATH;
                OpenDialog.FilterIndex = 0;

                if (OpenDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = OpenDialog.FileName;
                    FFxiNAV.Initialize(9999);
                    FFxiNAV.Load(path);
                    Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh initialized, File Loaded = {0}", path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"NavMesh is enabled = {0}", FFxiNAV.IsNavMeshEnabled().ToString()));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Character.Logger.AddDebugText(rtbDebug, string.Format(@"Points in navmesh path = {0}", FFxiNAV.PathCount().ToString()));
        }
    }
}