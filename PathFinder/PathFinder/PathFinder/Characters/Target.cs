using EliteMMO.API;
using PathFinder.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PathFinder.Characters
{
    public class Target
    {
        public int _Distance = 50;
        public List<int> BlockedTargets = new List<int>();

        public Target(Character Api)
        {
            Character = Api;
            Targets = new List<string>();
        }

        public int TargetMobId { get; set; }
        public Log log { get; set; }
        public Character Character { get; set; }
        public List<string> Targets { get; set; }

        private int BestTarget { get; set; }

        public int FindBestTarget()
        {
            if (Character.Targets.Count > 0)
            {
                var index = Enumerable.Range(0, 768)
                                 .Where(i => IsRendered(i) && IsAttackable(Character.Targets, i, Character.SearchDistance))
                                 .OrderBy(i => Character.Api.Entity.GetEntity(i).Distance)
                                 .Select(i => i).FirstOrDefault();

                return index;
            }
            else return 0;
        }

        public List<string> GetNpcNames()
        {
            var list = new List<string>();
            for (var i = 0; i < 768; i++)
            {
                if (!string.IsNullOrEmpty(Character.Api.Entity.GetEntity(i).Name))

                    list.Add(Character.Api.Entity.GetEntity(i).Name);
            }
            return list;
        }

        public List<int> GetNpcIDs()
        {
            var list = new List<int>();
            for (var i = 0; i < 768; i++)
            {
                if (!string.IsNullOrEmpty(Character.Api.Entity.GetEntity(i).Name))

                    list.Add(i);
            }
            return list;
        }

        public bool HasAggro()
        {
            if (Character.Status != EntityStatus.Engaged)
            {
                for (var i = 0; i < 768; i++)
                {
                    if (Character.Api.Entity.GetEntity(i).Distance < 21 &&
                    Character.Api.Entity.GetEntity(i).Status == (uint)EntityStatus.Engaged &&
                    Character.Api.Entity.GetEntity(i).ClaimID == 0)
                    {
                        Character.Logger.AddDebugText(Character.Tc.rtbDebug, "Possible Aggro");
                        return true;
                    }
                    if (Character.Api.Entity.GetEntity(i).Distance < 21 &&
                  Character.Api.Entity.GetEntity(i).Status == (uint)EntityStatus.Engaged &&
                  Character.Api.Entity.GetEntity(i).ClaimID == Character.Api.Player.ServerId)
                    {
                        Character.Logger.AddDebugText(Character.Tc.rtbDebug, "Possible Aggro");
                        return true;
                    }
                    if (Character.Api.Entity.GetEntity(i).Distance < 21 &&
           Character.Api.Entity.GetEntity(i).Status == (uint)EntityStatus.Engaged &&
           Character.Api.Entity.GetEntity(i).ClaimID == Character.Api.Player.ServerID)
                    {
                        Character.Logger.AddDebugText(Character.Tc.rtbDebug, "Possible Aggro");
                        return true;
                    }
                    if (Character.Api.Entity.GetEntity(i).Distance < 21 &&
           Character.Api.Entity.GetEntity(i).Status == (uint)EntityStatus.Engaged &&
           Character.Api.Entity.GetEntity(i).ClaimID == Character.Api.Party.GetPartyMember(0).ID)
                    {
                        Character.Logger.AddDebugText(Character.Tc.rtbDebug, "Possible Aggro");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsAggro(int mobIndex)
        {
            return false;
        }

        public bool IsAttackable(ICollection<string> Targets, int mobIndex, int distance)
        {
            if (Targets.Count == 0 || Targets.Contains(Character.Api.Entity.GetEntity(mobIndex).Name, StringComparer.InvariantCultureIgnoreCase))
            {
                return

                    Test(mobIndex)
                    &&
                       Character.Api.Entity.GetEntity(mobIndex).HealthPercent == 100
                       && (Character.Api.Entity.GetEntity(mobIndex).HealthPercent < 100 || IsPartyClaim(mobIndex))
                       && IsAggro(mobIndex)
                       && !IsClaimedBySomeoneElse(mobIndex)
                       && Character.Api.Entity.GetEntity(mobIndex).Status != (uint)EntityStatus.Dead || Character.Api.Entity.GetEntity(mobIndex).Status != (uint)EntityStatus.DeadEngaged
                       && Character.Api.Entity.GetEntity(mobIndex).Distance < Character.SearchDistance
                       && Character.Api.Entity.GetEntity(mobIndex).HealthPercent != 0;
            }

            return false;
        }

        public bool Test(int mobIndex)
        {
            var moby = Character.Api.Entity.GetEntity(mobIndex).Y;
            var Ydif = (Math.Abs(moby - Character.Api.Player.Y));
            if (Ydif < 3)
            {
                return true;
            }
            if (Ydif > 3)
            {
                return false;
            }
            else return false;
        }

        public bool IsClaimedBySomeoneElse(int mobIndex)
        {
            var mob = Character.Api.Entity.GetEntity(mobIndex);
            if (mob.ClaimID != 0 && !IsPartyClaim(mobIndex))
            {
                return true;
            }
            return false;
        }

        public bool IsPartyClaim(int mobIndex)
        {
            var mob = Character.Api.Entity.GetEntity(mobIndex);
            for (byte i = 0; i < Character.Api.Party.GetPartyMembers().Count; i++)
            {
                if (Convert.ToBoolean(Character.Api.Party.GetPartyMember(i).Active) && mob.ClaimID == Character.Api.Party.GetPartyMember(i).ID && mob.HealthPercent > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // public bool IsPartyClaim(int mobIndex) { for (byte i = 0; i < 16; i++) { var ClaimedID =
        // Character.Api.Entity.GetEntity(mobIndex).ClaimID; var MemberID =
        // Character.Api.Party.GetPartyMember(i).ID; { if (ClaimedID == MemberID &&
        // Character.Api.Entity.GetEntity(mobIndex).HealthPercent > 0) { return true; } }

        // var playerid = Character.Api.Player.ServerID; { if (ClaimedID == playerid) { return true;
        // } } } return false; }

        public bool IsRendered(int id)
        {
            var i = Character.Api.Entity.GetEntity(id).Render0000;
            var i2 = Character.Api.Entity.GetEntity(id).Render0000 & 0x200;
            if (i2 == 512)
            {
                return true;
            }
            else

                return false;
        }

        public bool TargetNpc(int id)
        {
            var Target = Character.Api.Target.GetTargetInfo();
            if (Target.TargetIndex != id)
            {
                Character.Api.Target.SetTarget(id);
                Character.Api.ThirdParty.SendString("/Target <t>");
                Thread.Sleep(10);
                Character.Api.ThirdParty.SendString("/lockon <t>");
                return true;
            }
            else return false;
        }
    }
}