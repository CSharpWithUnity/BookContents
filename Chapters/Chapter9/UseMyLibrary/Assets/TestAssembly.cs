using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine;

public class TestAssembly : MonoBehaviour
{
    [SuppressUnmanagedCodeSecurity] // disable security checks for better performance
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] // cdecl - let caller (.NET CLR) clean the stack
    private delegate int AssemblyAddFunction(int x, int y);
    [DllImport("kernel32.dll")]
    private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

    private void OMG()
    {

        // Without FASM.Net I strongly suggest you to comment each instruction (e.g. "0 push ebp")
        byte[] assembledCode =
        {
        0x55,               // 0 push ebp            ; init stack frame
        0x8B, 0x45, 0x08,   // 1 mov  eax, [ebp+8]   ; set eax to second param (remember, in cdecl calling convention, params are pushed right-to-left)
        0x8B, 0x55, 0x0C,   // 4 mov  edx, [ebp+12]  ; set edx to first param
        0x01, 0xD0,         // 7 add  eax, edx       ; add edx (first param) to eax (second param) 
        0x5D,               // 9 pop  ebp            ; leave stack frame
        0xC3                // A ret                 ; in cdecl calling convention, return value is stored in eax; so this will return both params added up
    };
        int returnValue;
        var process = System.Diagnostics.Process.GetCurrentProcess();
        //You can use any x86 assembler
        //For this example I have used https://defuse.ca/online-x86-assembler.htm
        unsafe
        {
            fixed (byte* ptr = assembledCode)
            {
                var memoryAddress = (IntPtr)ptr;

                // Mark memory as EXECUTE_READWRITE to prevent DEP exceptions
                if (!VirtualProtectEx(process.Handle, memoryAddress,
                (UIntPtr)assembledCode.Length, 0x40 /* EXECUTE_READWRITE */, out uint _))
                {
                    throw new Win32Exception();
                }

                var myAssemblyFunction = Marshal.GetDelegateForFunctionPointer<AssemblyAddFunction>(memoryAddress);
                returnValue = myAssemblyFunction(10, -15);
            }
        }
        // Note: We do not have to dispose memory ourself; the CLR will handle this.  
        Debug.Log($"Example3 (no dependencies) return value: {returnValue}, expected: -5"); // Prints -5
    }

    // Start is called before the first frame update
    void Start()
    {
        OMG();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
