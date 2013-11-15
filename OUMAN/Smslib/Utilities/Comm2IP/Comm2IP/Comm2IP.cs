using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Comm2IP
{
	public class Comm2IP
	{
		byte[] localHost;
		int port;
		string comPort;
		int baudRate;
		TcpListener tcpListener;
		bool shouldListen;

		public Comm2IP(byte[] localHost, int port, string comPort, int baudRate)
		{
			this.localHost = localHost;
			this.port = port;
			this.comPort = comPort;
			this.baudRate = baudRate;
			tcpListener = new TcpListener(new IPAddress(localHost), port);
			shouldListen = true;
		}

		public void Run()
		{
			tcpListener.Start();
			while (shouldListen)
			{
				try
				{
					Socket socket = tcpListener.AcceptSocket();
					SocketManager m = new SocketManager(socket, comPort, baudRate);
					Thread t = new Thread(new ThreadStart(m.Run));
					t.Start();
				}
				catch
				{
				}
			}
		}

		public void Start()
		{
			shouldListen = true;
		}

		public void Stop()
		{
			shouldListen = false;
			tcpListener.Stop();
		}
	}
}
