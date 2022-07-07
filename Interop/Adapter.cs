using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Celones.MicrosoftKeyTool.Interop
{
    internal static class Adapter
    {
        public static KeyStatus DecodeKey(string productKey, string pKeyPath, string family, out string pid, out DigitalProductId digPid, out DigitalProductId4 digPid4)
        {
            digPid = new DigitalProductId()
            {
                Size = (uint)Marshal.SizeOf(typeof(DigitalProductId))
            };

            digPid4 = new DigitalProductId4()
            {
                Size = (uint)Marshal.SizeOf(typeof(DigitalProductId4))
            };

            var pidBuffer = new byte[50];
            pidBuffer[0] = (byte)pidBuffer.Length;
            var pidPinned = GCHandle.Alloc(pidBuffer, GCHandleType.Pinned);

            var result = NativeMethods.PidGenX(productKey, pKeyPath, family, IntPtr.Zero, pidPinned.AddrOfPinnedObject(), ref digPid, ref digPid4);                        

            pidPinned.Free();
            pid = Encoding.Unicode.GetString(pidBuffer).TrimEnd('\0');

            switch (result)
            {
                case NativeMethods.HResult.PKEYMISSING:
                    return KeyStatus.MissingConfiguration;

                case NativeMethods.HResult.MALFORMEDKEY:
                    return KeyStatus.Malformed;

                case NativeMethods.HResult.INVALIDKEY:
                    return KeyStatus.Invalid;

                case NativeMethods.HResult.BLACKLISTEDKEY:
                    return KeyStatus.Blacklisted;
            }

            return KeyStatus.Valid;
        }
    }
}
