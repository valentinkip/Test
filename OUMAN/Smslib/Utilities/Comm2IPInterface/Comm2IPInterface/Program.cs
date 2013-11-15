using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Comm2IPInterface
{
	class Comm2IPInterface
	{
		public int ipPort = -1;
		public byte[] ipAddress = new byte[4] { 0, 0, 0, 0 };
		public int commRate = -1;
		public string commPort = "";

		public void ParseParameters(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "-p") ipPort = Int32.Parse(args[++i]);
				else if (args[i] == "-a")
				{
					string address = args[++i];
					string[] addr = address.Split(new char[] { '.' });
					for (int j = 0; j < 4; j++) ipAddress[j] = (byte) Int32.Parse(addr[j]);
				}
				else if (args[i] == "-c") commPort = args[++i];
				else if (args[i] == "-b") commRate = Int32.Parse(args[++i]);
			}
		}

		public bool CheckParameters()
		{
			if ((commRate == -1) || (commPort == "") || (ipAddress[0] == 0) || (ipPort == -1))
			{
				Console.WriteLine("Comm2IP command line interface.");
				Console.WriteLine("Refer to http://www.smslib.org for documentation.");
				Console.WriteLine();
				Console.WriteLine("Parameters:");
				Console.WriteLine("  comm2ipinterface -a <bind address> -p <bind-port> -c <comm port name> -b <comm baud rate>");
				Console.WriteLine();
				Console.WriteLine("Example:");
				Console.WriteLine("  comm2ipinterface -a 127.0.0.1 -p 12000 -c com1 -b 19200");
				return false;
			}
			return true;
		}

		public void RunDaemon()
		{
			Comm2IP.Comm2IP com1 = new Comm2IP.Comm2IP(ipAddress, ipPort, commPort, commRate);
			try
			{
				Console.WriteLine("Listening...");
				Thread listener = new Thread(new ThreadStart(com1.Run));
				listener.Start();
				listener.Join();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}
		}

		static void Main(string[] args)
		{
			try
			{
				Comm2IPInterface app = new Comm2IPInterface();
				app.ParseParameters(args);
				if (app.CheckParameters())
					while (true)
					{
						app.RunDaemon();
					}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error:");
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}
	}
}
