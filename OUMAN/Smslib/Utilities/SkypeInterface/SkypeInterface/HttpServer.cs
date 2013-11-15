using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Net;
using System.Threading;

namespace SkypeInterface
{
	class HttpServer
	{
		static readonly int ERR_NO_ERROR = 0;
		static readonly int ERR_INVALID_PASSWORD = -1;
		static readonly int ERR_INVALID_PARAMETERS = -2;
		static readonly int ERR_INTERNAL_ERROR = -9;
		static readonly int ERR_INVALID_COMMAND = -10;

		static Object LOCK = new Object();

		HttpListener httpServer;
		Skype skype;
		bool enabled = true;

		public HttpServer(Skype skype)
		{
			LOCK = new Object();
			this.skype = skype;
			httpServer = new HttpListener();
			httpServer.Prefixes.Add("http://" + Properties.Settings.Default.BindIP + ":" + Properties.Settings.Default.BindPort + "/");
			httpServer.Start();
		}

		public void Run()
		{
			int updateDetailsCounter = 0;

			while (enabled)
			{
				try
				{
					HttpListenerContext context = httpServer.GetContext();
					new Thread(new Worker(skype, context).Process).Start();
				}
				catch
				{
				}
				if (++updateDetailsCounter == 5)
				{
					skype.GetAccountDetails(false);
					updateDetailsCounter = 0;
				}
			}
		}

		public void Stop()
		{
			enabled = false;
			httpServer.Stop();
		}

		class Worker
		{
			Skype skype;
			HttpListenerContext context;

			public Worker(Skype skype, HttpListenerContext context)
			{
				this.skype = skype;
				skype.SkypeClient.SmsMessageStatusChanged += new SKYPE4COMLib._ISkypeEvents_SmsMessageStatusChangedEventHandler(SkypeClient_SmsMessageStatusChanged);
				skype.SkypeClient.SmsTargetStatusChanged += new SKYPE4COMLib._ISkypeEvents_SmsTargetStatusChangedEventHandler(SkypeClient_SmsTargetStatusChanged);
				this.context = context;
			}

			void SkypeClient_SmsTargetStatusChanged(SKYPE4COMLib.SmsTarget pTarget, SKYPE4COMLib.TSmsTargetStatus Status)
			{
				//throw new NotImplementedException();
			}

			void SkypeClient_SmsMessageStatusChanged(SKYPE4COMLib.SmsMessage pMessage, SKYPE4COMLib.TSmsMessageStatus Status)
			{
				//throw new NotImplementedException();
			}

			public void Process()
			{
				lock (LOCK)
				{
					int error;

					skype.SetBusyIndicator(true);
					HttpListenerRequest request = context.Request;
					if (request.RawUrl.StartsWith("/send"))
					{
						try
						{
							error = SendMessage(request.QueryString["to"], request.QueryString["text"], request.QueryString["reply"], request.QueryString["password"]);
							//error = SendMessage(request.Headers["to"], request.Headers["text"], request.Headers["reply"], request.Headers["password"]);
						}
						catch (Exception e)
						{
							error = ERR_INTERNAL_ERROR;
						}
					}
					else error = ERR_INVALID_COMMAND;
					StringBuilder sb = new StringBuilder();
					sb.Append(error);
					byte[] b = Encoding.ASCII.GetBytes(sb.ToString());
					context.Response.ContentLength64 = b.Length;
					context.Response.OutputStream.Write(b, 0, b.Length);
					context.Response.OutputStream.Close();
					skype.SetBusyIndicator(false);
				}
			}

			int SendMessage(string recipient, string text, string reply, string password)
			{
				if (String.IsNullOrEmpty(recipient)) return ERR_INVALID_PARAMETERS;
				if (String.IsNullOrEmpty(text)) return ERR_INVALID_PARAMETERS;
				if (String.IsNullOrEmpty(reply)) return ERR_INVALID_PARAMETERS;
				if (String.IsNullOrEmpty(password)) return ERR_INVALID_PARAMETERS;
				if (password != Properties.Settings.Default.Password) return ERR_INVALID_PASSWORD;
				if (recipient[0] != '+') recipient = "+" + recipient.Trim();
				if (reply[0] != '+') reply = "+" + reply.Trim();
				skype.SkypeClient.SendSms(recipient, text, reply);
				return ERR_NO_ERROR;
			}
		}
	}
}
