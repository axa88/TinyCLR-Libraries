﻿using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices {
    internal static class InternalCall {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Register(IntPtr address);
    }
}