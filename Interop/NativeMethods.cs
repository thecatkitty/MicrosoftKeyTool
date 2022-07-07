using System;
using System.Runtime.InteropServices;

namespace Celones.MicrosoftKeyTool.Interop
{
    internal static class NativeMethods
    {
        public enum HResult : uint
        {
            OK = 0x00000000,
            PKEYMISSING = 0x80070002,
            MALFORMEDKEY = 0x80070057,
            INVALIDKEY = 0x8A010101,
            BLACKLISTEDKEY = 0x0000000F
        }

       [DllImport("pidgenx.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public extern static HResult PidGenX(
            string productKey,
            string pKeyPath,
            string pid,
            IntPtr oemId,
            IntPtr productId,
            ref DigitalProductId digPid,
            ref DigitalProductId4 digPid4);
    }
}
