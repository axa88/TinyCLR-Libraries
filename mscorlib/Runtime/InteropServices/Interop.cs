﻿using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices {
    public sealed class Interop {
        private Interop() { }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Add(IntPtr address);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Remove(IntPtr address);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [CLSCompliant(false)]
        public static extern void RaiseEvent(string eventDispatcherName, string providerName, uint controllerIndex, ulong data0, ulong data1, IntPtr data2);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Interop[] FindAll();

        public string Name { get; }
        [CLSCompliant(false)]
        public uint Checksum { get; }
        public IntPtr Methods { get; }
    }
}