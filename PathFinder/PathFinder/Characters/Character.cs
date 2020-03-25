using EliteMMO.API;
using PathFinder.Common;
using System;
using System.Collections.Generic;

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

        public Character(Log Log, ToonControl tc, Dictionary<string, EliteAPI> chars, EliteAPI api)
        {
            Logger = Log;
            Tc = tc;
            _CharacterDictionary = chars;
            Api = api;
            Targets = new List<string>();
            Navi = new Navigation(this);
            Target = new Target(this);
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
    }
}