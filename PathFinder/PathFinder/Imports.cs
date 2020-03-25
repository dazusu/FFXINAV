using Microsoft.Win32.SafeHandles;
using PathFinder.Common;
using System;
using System.Runtime.InteropServices;

namespace PathFinder
{
    public partial class FFXINAV
    {
        private string oldString = string.Empty;

        [DllImport("FFXINAV.dll", EntryPoint = "unload", CallingConvention = CallingConvention.Cdecl)]
        public static extern void unload();

        [DllImport("FFXINAV.dll", EntryPoint = "Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initialize(int id);

        [DllImport("FFXINAV.dll", EntryPoint = "load", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool load(string path);

        [DllImport("FFXINAV.dll", EntryPoint = "GetErrorMessage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string getErrorMessage();

        [DllImport("FFXINAV.dll", EntryPoint = "FindPath_DSP_NAV_Files", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern void findPath_DSP_NAV_Files(position_t start, position_t end);

        [DllImport("FFXINAV.dll", EntryPoint = "FindPath", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern void findPath(position_t start, position_t end);

        [DllImport("FFXINAV.dll", EntryPoint = "isNavMeshEnabled", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool isNavMeshEnabled();

        [DllImport("FFXINAV.dll", EntryPoint = "Pathpoints", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int pathpoints();

        [DllImport("FFXINAV.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe bool Get_m_points_X(out ItemsSafeHandle itemsHandle,
            out double* items, out int itemCount);

        [DllImport("FFXINAV.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern bool ReleaseItems(IntPtr itemsHandle);

        [DllImport("FFXINAV.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe bool Get_m_points_Z(out ItemsSafeHandle itemsHandle,
    out double* items, out int itemCount);

        public static unsafe ItemsSafeHandle Get_m_points_XWrapper(out double* items, out int itemsCount)
        {
            ItemsSafeHandle itemsHandle;
            if (!Get_m_points_X(out itemsHandle, out items, out itemsCount))
            {
                throw new InvalidOperationException();
            }
            return itemsHandle;
        }

        public static unsafe ItemsSafeHandle Get_m_points_ZWrapper(out double* items, out int itemsCount)
        {
            ItemsSafeHandle itemsHandle;
            if (!Get_m_points_Z(out itemsHandle, out items, out itemsCount))
            {
                throw new InvalidOperationException();
            }
            return itemsHandle;
        }

        public class ItemsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public ItemsSafeHandle()
                : base(true)
            {
            }

            protected override bool ReleaseHandle()
            {
                return ReleaseItems(handle);
            }
        }
    }
}