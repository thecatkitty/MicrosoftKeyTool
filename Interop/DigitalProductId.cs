using System.Runtime.InteropServices;

namespace Celones.MicrosoftKeyTool.Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DigitalProductId
    {
        public uint Size;
        public ushort MajorVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string ProductId;
        public uint KeyIdx;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string EditionId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] CdKey;
        public uint CloneStatus;
        public uint Time;
        public uint Random;
        public uint Lt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] LicenseData;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string OemId;
        public uint BundleId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string HardwareIdStatic;
        public uint HardwareIdTypeStatic;
        public uint BiosChecksumStatic;
        public uint VolSerStatic;
        public uint TotalRamStatic;
        public uint VideoBiosChecksumStatic;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string HardwareIdDynamic;
        public uint HardwareIdTypeDynamic;
        public uint BiosChecksumDynamic;
        public uint VolSerDynamic;
        public uint TotalRamDynamic;
        public uint VideoBiosChecksumDynamic;
        public uint Crc32;
    }
}
