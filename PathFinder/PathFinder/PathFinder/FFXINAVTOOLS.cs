using PathFinder.Common;
using System.Collections.Generic;

namespace PathFinder
{
    public partial class FFXINAV
    {
        public List<position_t> waypoints { get; set; }

        public FFXINAV()
        {
            waypoints = new List<position_t>();
            WPz = new List<float>();
            WPx = new List<float>();
        }

        public void Unload()
        {
            unload();
        }

        public void Initialize(int pathsize)
        {
            initialize(pathsize);
        }

        public void Load(string file)
        {
            load(file);
        }

        public string GetErrorMessage()
        {
            return getErrorMessage().ToString();
        }

        public void FindPath_DSP_NAV_Files(position_t start, position_t end)
        {
            findPath_DSP_NAV_Files(start, end);
        }

        public void FindPath(position_t start, position_t end)
        {
            findPath(start, end);
        }

        public void FindPathToPosi(position_t start, position_t end)
        {
            findPathToPosi(start, end);
        }

        public bool IsNavMeshEnabled()
        {
            return isNavMeshEnabled();
        }

        public int PathCount()
        {
            return pathpoints();
        }

        public List<float> WPx { get; set; }
        public List<float> WPz { get; set; }

        public unsafe void TryGetWaypoints()
        {
            waypoints.Clear();
            WPz.Clear();
            WPx.Clear();
            if (pathpoints() > 0)
            {
                double* items;
                int itemsCount;

                using (FFXINAV.Get_m_points_XWrapper(out items, out itemsCount))
                {
                    for (int i = 0; i < itemsCount; i++)
                    {
                        WPx.Add(ToSingle(items[i]));
                    }
                }
            }
            if (pathpoints() > 0)
            {
                double* items2;
                int itemsCount2;

                using (FFXINAV.Get_m_points_ZWrapper(out items2, out itemsCount2))
                {
                    for (int i = 0; i < itemsCount2; i++)
                    {
                        WPz.Add(ToSingle(items2[i]));
                    }
                }
            }

            if (WPx.Count > 0 && WPz.Count > 0)
            {
                for (var i = 0; i < pathpoints(); i++)
                {
                    x = WPx[i]; z = WPz[i];
                    var position = new position_t { X = x, Z = z };
                    waypoints.Add(position);
                }
            }
        }

        private float x { get; set; }
        private float z { get; set; }
        //public unsafe void TryGetZWaypoints()
        //{
        //    if (pathpoints() > 0)
        //    {
        //        double* items;
        //        int itemsCount;

        //        using (FFXINAV.Get_m_points_ZWrapper(out items, out itemsCount))
        //        {
        //            for (int i = 0; i < itemsCount; i++)
        //            {
        //                WPz.Add(ToSingle(items[i]));
        //            }
        //        }
        //    }
        //}
        public static float ToSingle(double value)
        {
            return (float)value;
        }
    }
}