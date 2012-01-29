using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            int tries = 0;
    retry:
            if (tries > 4)
            {
                Console.WriteLine("I'm afraid I can't download the file for some reason!");
                Console.WriteLine("Go to http://mclawl.tk/MCLawl_.dll yourself and download it, please");
                Console.WriteLine("Place it inside my folder, near me, and restart me.");
                Console.WriteLine("Press any key to close me...");
                Console.ReadLine();
                goto exit;
            }

            if (File.Exists("MCLawl_.dll"))
            {
                openServer(args);
            }
            else
            {
                tries++;
                Console.WriteLine("This is try number " + tries);
                Console.WriteLine("You do not have the required DLL!");
                Console.WriteLine("I'll download it for you. Just wait.");
                Console.WriteLine("Downloading from http://mclawl.tk/MCLawl_.dll");

                WebClient Client = new WebClient();
                Client.DownloadFile("http://mclawl.tk/MCLawl_.dll", "MCLawl_.dll");
                Client.Dispose();

                Console.WriteLine("Finished downloading! Let's try this again, shall we.");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }
                Console.WriteLine("Go!");
                Console.WriteLine();

                goto retry;
            }
exit:   Console.WriteLine("Bye!");
        }

        static void openServer(string[] args)
        {
            MCLawl_.Gui.Program.Main(args);
        }
    }
}
