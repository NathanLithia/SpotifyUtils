using System;
using System.Diagnostics;


// Todo:
//
// ✓ Detect and ID Spotify process.
// ✗ Settings file.
// ✗ Volume control Spotify process on events.
// ✗ Send keys to Spotify on events.
// ✓ Offline song Detection.
// ✗ Online song detection.
// ✗ Offline song length detection.
// ✗ Online song length detection & cache.
// ✗ Advertisement length detection.


// Window titles and their usual meanings:
//
// Advertisement -> Most likely an Advertisement.
// Spotify       -> Sometimes an Advertisement.
// Spotify Free  -> Usually the window title when the client is on pause.


namespace NLSpotify
{
    public class Spotify
    {
        public string GetPlaying(int PID) //Get the Window Title and convert it into a useable status.
        {
            Process Application = Process.GetProcessById(PID);
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
        public int GetPID() //Find the Process ID of the running Windowed Spotify Process.
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
