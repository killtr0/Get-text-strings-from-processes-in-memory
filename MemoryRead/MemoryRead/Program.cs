using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
public class MemoryRead
{
    /*
    Para leer el valor de la dirección de memoria 0x0800A478
    importo 2 funciones del kernel32.dll.
    1.- OpenProcess ()
    2.- ReadProcessMemory ()
    */
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

    // Al abrir el proceso, especifico una constante de acceso de lectura de la memoria.
    const int ProcessRead = 0x0010;
    public static void Main()
    {
        string name = "code";
        int id = 8200;
        Process process = Process.GetProcessesByName(name)[0];
        IntPtr processHandle = OpenProcess(ProcessRead, false, id);
        int bytesRead = 0;
        byte[] buffer = new byte[44]; //'Alejandro was here 3:)' toma 22*2 bytes debido a Unicode
        /* 
           0x0800A478 es la dirección donde encontré la cadena
           Se reemplaza por la dirección que se encuentra en tiempo de ejecución
        */
        ReadProcessMemory((int)processHandle, 0x0800A478, buffer, buffer.Length, ref bytesRead);
        Console.WriteLine(" (" + bytesRead.ToString() + "bytes) - Lectura de memoria : " + Encoding.Unicode.GetString(buffer));
        Console.ReadKey();
    }
}