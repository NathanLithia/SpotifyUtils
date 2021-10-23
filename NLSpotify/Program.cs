using System;
using System.Diagnostics;

namespace NLSpotify
{
    public class Spotify
    {
        public string GetPlaying(int PID) 
        {
            Process Application = Process.GetProcessById(PID);
            // Advertisement -> Ad
            // Spotify       -> Ad
            // Spotify Free  -> 
            if (Application.MainWindowTitle == "Advertisement") 
            {
                return "Advertisement";
            }
            else if (Application.MainWindowTitle == "Spotify Free")
            {
                return "Paused";
            }
            else
            {
                return Application.MainWindowTitle;
            }
        }
        public int GetPID()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.ProcessName == "Spotify")
                    {
                        return process.Id;
                    }
                }
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Spotify client = new Spotify();
            int PID = client.GetPID();
            while (true)
            {
                Console.WriteLine(client.GetPlaying(PID));
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
