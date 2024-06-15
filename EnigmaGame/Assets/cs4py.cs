// Unity C# script
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class PythonIntegration : MonoBehaviour
{
    Process pythonProcess;
    StreamWriter pythonStreamWriter;
    StreamReader pythonStreamReader;

    void Start()
    {
        StartPythonProcess();
    }

    void StartPythonProcess()
    {
        pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = "python";
        pythonProcess.StartInfo.Arguments = "logic.py";
        pythonProcess.StartInfo.UseShellExecute = false;
        pythonProcess.StartInfo.RedirectStandardOutput = true;
        pythonProcess.StartInfo.RedirectStandardInput = true;
        pythonProcess.Start();
        
        pythonStreamWriter = pythonProcess.StandardInput;
        pythonStreamReader = pythonProcess.StandardOutput;
    }

    void SendToPython(string message)
    {
        pythonStreamWriter.WriteLine(message);
        string response = pythonStreamReader.ReadLine();
        UnityEngine.Debug.Log("Python response: " + response);
    }

    void OnApplicationQuit()
    {
        if (pythonProcess != null && !pythonProcess.HasExited)
        {
            pythonProcess.Kill();
        }
    }
}
