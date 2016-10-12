/*
# Title: GetProcessId (POC)
# Date: 19/07/2016
# Author: José Alejandro Gago
# Tested on: Windows 7 x64 SP1
*/
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace GetProcessId
{
    class ProcessID{
        void Runningprocesses(){
            // Obteniendo todos los procesos e IDs del Sistema.
            try {
                Process[] localAll = Process.GetProcesses();
                foreach (Process mp in localAll){
                    Console.WriteLine("Process Name : {0}", mp.ProcessName);
                    Console.WriteLine("Process ID   : {0}", mp.Id);
                    Console.WriteLine("Windows Title: {0}\n", mp.MainWindowTitle);
                }
            }
            catch (Exception ex){
                Console.Write("{0}", ex);
            }
            finally {
                Console.ReadKey();
            }
        }
        static void Main(){
            ProcessID myProcess = new ProcessID();
            myProcess.Runningprocesses();
        }
    }
}
