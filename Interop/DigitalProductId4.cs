using System.Runtime.InteropServices;

namespace Celones.MicrosoftKeyTool.Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct DigitalProductId4
    {
        public uint Size;
        public ushort MajorVersion;
        public ushort MinorVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string AdvancedPid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ActivationId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string OemId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string EditionType;
        [MarshalAs(UnmanagedType.U1)]
        public bool IsUpgrade;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        private byte[] Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] CdKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] CdKeyHash256;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] Hash256;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string EditionId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string KeyType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Eula;
    }
}
