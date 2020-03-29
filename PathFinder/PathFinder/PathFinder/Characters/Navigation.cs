using PathFinder.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PathFinder.Characters
{
    public class Navigation
    {
        public static Random rnd = new Random();
        public int offset = 2000;
        public int PullDistance = 10;
        public int SearchDistance = 50;
        public List<position_t> Waypoints { get; set; }
        private const double TooCloseDistance = 1.5;

        public Position GetMemberPosition(int id)
        {
            Position p = new Position { X = Character.Api.Entity.GetEntity(id).X, Y = Character.Api.Entity.GetEntity(id).Y, Z = Character.Api.Entity.GetEntity(id).Z, H = Character.Api.Entity.GetEntity(id).H };

            return p;
        }

        public Navigation(Character chars)
        {
            Character = chars;
            Reset();
            Waypoints = new List<position_t>();
        }

        public Character Character { get; set; }
        public double DistanceTolerance { get; set; } = 3;
        public int FailedToPath { get; set; }
        public int GotoDelay { get; set; }
        public float StayRunningAmount { get; set; }

        public double DistanceTo(int mobid)
        {
            var start = new position_t { X = Character.Api.Player.X, Z = Character.Api.Player.Z };
            var dest = new position_t { X = Character.Api.Entity.GetEntity(mobid).X, Z = Character.Api.Entity.GetEntity(mobid).Z };
            return Math.Sqrt(Math.Pow(start.X - dest.X, 2) + Math.Pow(start.Z - dest.Z, 2));
        }

        public double DistancetoWaypoint(position_t start, position_t end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Z - end.Z, 2));
        }

        public void FaceHeading(position_t position)
        {
            var player = Character.Api.Entity.GetLocalPlayer();
            var angle = (byte)(Math.Atan((position.Z - player.Z) / (position.X - player.X)) * -(128.0f / Math.PI));
            if (player.X > position.X) angle += 128;
            var radian = (float)angle / 255 * 2 * Math.PI;
            Character.Api.Entity.SetEntityHPosition(Character.Api.Entity.LocalPlayerIndex, (float)radian);
        }

        public bool Desti(position_t End)
        {
            if (Character.Api.Player.X == End.X + -1 && Character.Api.Player.Z == End.Z + -1)
            {
                return true;
            }
            else return false;
        }

        public position_t GetWaypointClosestTo(float x, float z)
        {
            position_t ClosestWP = new position_t();
            double ClosestDistance = 9999;
            foreach (position_t wp in Waypoints)
            {
                position_t start = new position_t { X = x, Z = z };
                position_t end = new position_t { X = wp.X, Z = wp.Z };
                if (DistancetoWaypoint(start, end) < ClosestDistance)
                {
                    ClosestWP = wp;
                    ClosestDistance = DistancetoWaypoint(start, end);
                }
            }
            return ClosestWP;
        }

        public void GoTo(float x, float z)
        {
            var position = new position_t { X = x, Z = z };
            if (!(DistanceTo(position) > 5)) return;
            MoveForwardTowardsPosition(position, true);
        }

        public void GotoNPC(int ID)
        {
            var entity = Character.Api.Entity.GetEntity(ID);
            var position = new position_t { X = entity.X, Y = entity.Y, Z = entity.Z };

            Reset();
            FaceHeading(position);
            MoveForwardTowardsPosition(position, true);
        }

        public void LoadWaypoints()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Character.Logger.LogFile(ex.Message, "Nav");
            }
        }

        public void ClearWaypointsAndGrid()
        {
            Waypoints.Clear();
        }

        public void Reset()
        {
            Character.Api.AutoFollow.IsAutoFollowing = false;
            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD8);
            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD2);
            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD6);
            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD4);
        }

        public void SetViewMode(ViewMode viewMode)
        {
            if ((ViewMode)Character.Api.Player.ViewMode != viewMode)
            {
                Character.Api.Player.ViewMode = (int)viewMode;
            }
        }

        private void AvoidObstacles()
        {
            if (IsStuck())
            {
                if (Character.IsEngaged())
                    WiggleCharacter(attempts: 3);
            }
        }

        public double DistanceTo(position_t position)
        {
            var player = Character.Api.Entity.GetLocalPlayer();

            return Math.Sqrt(Math.Pow(player.X - position.X, 2) + Math.Pow(player.Z - position.Z, 2));
        }

        private bool IsStuck()
        {
            var firstX = Character.Api.Player.X;
            var firstZ = Character.Api.Player.Z;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var dchange = Math.Pow(firstX - Character.Api.Player.X, 2) + Math.Pow(firstZ - Character.Api.Player.Z, 2);
            return Math.Abs(dchange) < 1;
        }

        private void KeepOneYalmBack(position_t position)
        {
            if (DistanceTo(position) > TooCloseDistance) return;

            DateTime duration = DateTime.Now.AddSeconds(5);
            Character.Api.ThirdParty.KeyDown(EliteMMO.API.Keys.NUMPAD2);

            while (DistanceTo(position) <= TooCloseDistance && DateTime.Now < duration)
            {
                SetViewMode(ViewMode.FirstPerson);
                FaceHeading(position);
                Thread.Sleep(30);
            }

            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD2);
        }

        private void KeepRunningWithKeyboard()
        {
            Character.Api.ThirdParty.KeyDown(EliteMMO.API.Keys.NUMPAD8);
        }

        public void MoveForwardTowardsPosition(
                                position_t TargetPosition, bool useObjectAvoidance)
        {
            if (DistanceTo(TargetPosition) > 3)
            {
                var player = Character.Api.Player;
                var i = DistanceTo(TargetPosition);
                SetViewMode(ViewMode.FirstPerson);
                FaceHeading(TargetPosition);
                // KeepRunningWithKeyboard();
                Character.Api.AutoFollow.SetAutoFollowCoords(
                 TargetPosition.X - player.X,
                 TargetPosition.Y - player.Y,
                  TargetPosition.Z - player.Z);

                Character.Api.AutoFollow.IsAutoFollowing = true;

                if (useObjectAvoidance) AvoidObstacles();
            }

            Character.Api.AutoFollow.IsAutoFollowing = false;

        }

        private void WiggleCharacter(int attempts)
        {
            int count = 0;
            float dir = -45;
            while (IsStuck() && attempts-- > 0)
            {
                Character.Api.Entity.GetLocalPlayer().H = Character.Api.Player.H + (float)(Math.PI / 180 * dir);
                Character.Api.ThirdParty.KeyDown(EliteMMO.API.Keys.NUMPAD8);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD8);
                count++;
                if (count == 4)
                {
                    dir = (Math.Abs(dir - -45) < .001 ? 45 : -45);
                    count = 0;
                }
            }
            Character.Api.ThirdParty.KeyUp(EliteMMO.API.Keys.NUMPAD8);
        }

        public double GetPlayerPosHInDegrees()
        {
            return PosHToDegrees(Character.Api.Player.H);
        }

        public double PosHToDegrees(float PosH)
        {
            // Formula: d = (((PosH * 180) / Math.PI) + 90) % 360;
            double d;

            // Convert from Degrees to Radians
            d = ((PosH * 180.0) / Math.PI);

            // Translate to Degree(Start) from FFXIRadians(Start) (Add 90deg) and Normalize
            return MathMod((d + (double)90.0), (double)360.0000);
        }

        private double MathMod(double a, double b)
        {
            // 4 known ways to do it here (a - (b * Math.Floor(a / b))) (a - (b * (Math.Sign(b) *
            // Math.Floor(a / Math.Abs(b))))) (Math.Abs(a * b) + a) % b ((a % b) + b) % b // <- THIS
            // ONE IS THE FASTEST!
            return ((a % b) + b) % b;
        }
    }
}