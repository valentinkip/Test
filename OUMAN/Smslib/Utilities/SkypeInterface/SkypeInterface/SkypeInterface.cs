using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SkypeInterface
{
	public partial class Skype : Form
	{
		public SKYPE4COMLib.Skype SkypeClient
		{
			get
			{
				return skypeClient;
			}
		}
		SKYPE4COMLib.Skype skypeClient;
		HttpServer httpServer = null;
		Thread httpListener;

		public Skype()
		{
			InitializeComponent();
		}

		private void Skype_Load(object sender, EventArgs e)
		{
			SetStarted(false);
		}

		private void Skype_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopHttpListener();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			const int DELAY = 10;
			skypeClient = new SKYPE4COMLib.Skype();
			if (!skypeClient.Client.IsRunning) skypeClient.Client.Start(false, false);
			pbStatus.Visible = true;
			pbStatus.Minimum = 1;
			pbStatus.Maximum = DELAY;
			pbStatus.Value = 1;
			pbStatus.Step = 1;
			for (int i = 0; i < DELAY; i++)
			{
				pbStatus.PerformStep();
				Thread.Sleep(1000);
			}
			pbStatus.Visible = false;
			StartHttpListener();
			SetStarted(true);
		}

		protected internal void GetAccountDetails(bool clearAll)
		{
			txtAccountName.Text = (clearAll ? "" : skypeClient.CurrentUserProfile.FullName);
			txtBalance.Text = (clearAll ? "" : (skypeClient.CurrentUserProfile.Balance / 100) + " " + skypeClient.CurrentUserProfile.BalanceCurrency);
			txtBalanceText.Text = (clearAll ? "" : skypeClient.CurrentUserProfile.BalanceToText.ToString());
			txtSMSNumbers.Text = (clearAll ? "" : skypeClient.CurrentUserProfile.ValidatedSmsNumbers);

		}

		private void StartHttpListener()
		{
			httpServer = new HttpServer(this);
			httpListener = new Thread(new ThreadStart(httpServer.Run));
			httpListener.Start();
		}

		private void StopHttpListener()
		{
			if (httpServer != null)
			{
				httpServer.Stop();
				httpListener.Interrupt();
				httpListener.Join();
				httpServer = null;
			}
		}

		private void SetStarted(bool started)
		{
			btnStart.Enabled = !started;
			btnStop.Enabled = started;
			GetAccountDetails(!started);
		}

		public void SetBusyIndicator(bool on)
		{
			lblActivity.ForeColor = (on ? Color.MediumBlue : Color.LightGray);
		}
	}
}
