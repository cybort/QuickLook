﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace QuickLook.NativeMethods
{
    internal class User32
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance,
            uint threadId);

        [DllImport("user32.dll")]
        internal static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        internal static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref KeyboardHookStruct lParam);

        internal delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal struct KeyboardHookStruct
        {
            internal int vkCode;
            internal int scanCode;
            internal int flags;
            internal int time;
            internal int dwExtraInfo;
        }

        // ReSharper disable InconsistentNaming
        internal const int WH_KEYBOARD_LL = 13;
        internal const int WM_KEYDOWN = 0x100;
        internal const int WM_KEYUP = 0x101;
        internal const int WM_SYSKEYDOWN = 0x104;
        internal const int WM_SYSKEYUP = 0x105;
        // ReSharper restore InconsistentNaming
    }
}