namespace SkypeInterface
{
	partial class Skype
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStart = new System.Windows.Forms.Button();
			this.label01 = new System.Windows.Forms.Label();
			this.txtAccountName = new System.Windows.Forms.TextBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.pbStatus = new System.Windows.Forms.ProgressBar();
			this.txtBalance = new System.Windows.Forms.TextBox();
			this.txtBalanceText = new System.Windows.Forms.TextBox();
			this.txtSMSNumbers = new System.Windows.Forms.TextBox();
			this.label02 = new System.Windows.Forms.Label();
			this.label03 = new System.Windows.Forms.Label();
			this.label04 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblActivity = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(525, 21);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label01
			// 
			this.label01.AutoSize = true;
			this.label01.Location = new System.Drawing.Point(19, 19);
			this.label01.Name = "label01";
			this.label01.Size = new System.Drawing.Size(81, 13);
			this.label01.TabIndex = 1;
			this.label01.Text = "Account Name:";
			// 
			// txtAccountName
			// 
			this.txtAccountName.Location = new System.Drawing.Point(107, 19);
			this.txtAccountName.Name = "txtAccountName";
			this.txtAccountName.ReadOnly = true;
			this.txtAccountName.Size = new System.Drawing.Size(181, 20);
			this.txtAccountName.TabIndex = 2;
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(525, 54);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			// 
			// pbStatus
			// 
			this.pbStatus.Location = new System.Drawing.Point(12, 148);
			this.pbStatus.Name = "pbStatus";
			this.pbStatus.Size = new System.Drawing.Size(588, 23);
			this.pbStatus.TabIndex = 4;
			this.pbStatus.Visible = false;
			// 
			// txtBalance
			// 
			this.txtBalance.Location = new System.Drawing.Point(107, 45);
			this.txtBalance.Name = "txtBalance";
			this.txtBalance.ReadOnly = true;
			this.txtBalance.Size = new System.Drawing.Size(181, 20);
			this.txtBalance.TabIndex = 5;
			// 
			// txtBalanceText
			// 
			this.txtBalanceText.Location = new System.Drawing.Point(107, 71);
			this.txtBalanceText.Name = "txtBalanceText";
			this.txtBalanceText.ReadOnly = true;
			this.txtBalanceText.Size = new System.Drawing.Size(181, 20);
			this.txtBalanceText.TabIndex = 6;
			// 
			// txtSMSNumbers
			// 
			this.txtSMSNumbers.Location = new System.Drawing.Point(107, 97);
			this.txtSMSNumbers.Name = "txtSMSNumbers";
			this.txtSMSNumbers.ReadOnly = true;
			this.txtSMSNumbers.Size = new System.Drawing.Size(181, 20);
			this.txtSMSNumbers.TabIndex = 7;
			// 
			// label02
			// 
			this.label02.AutoSize = true;
			this.label02.Location = new System.Drawing.Point(20, 45);
			this.label02.Name = "label02";
			this.label02.Size = new System.Drawing.Size(49, 13);
			this.label02.TabIndex = 8;
			this.label02.Text = "Balance:";
			// 
			// label03
			// 
			this.label03.AutoSize = true;
			this.label03.Location = new System.Drawing.Point(20, 71);
			this.label03.Name = "label03";
			this.label03.Size = new System.Drawing.Size(75, 13);
			this.label03.TabIndex = 9;
			this.label03.Text = "SMS Balance:";
			// 
			// label04
			// 
			this.label04.AutoSize = true;
			this.label04.Location = new System.Drawing.Point(20, 97);
			this.label04.Name = "label04";
			this.label04.Size = new System.Drawing.Size(78, 13);
			this.label04.TabIndex = 10;
			this.label04.Text = "SMS Numbers:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label04);
			this.groupBox1.Controls.Add(this.txtSMSNumbers);
			this.groupBox1.Controls.Add(this.label03);
			this.groupBox1.Controls.Add(this.label01);
			this.groupBox1.Controls.Add(this.label02);
			this.groupBox1.Controls.Add(this.txtAccountName);
			this.groupBox1.Controls.Add(this.txtBalance);
			this.groupBox1.Controls.Add(this.txtBalanceText);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(294, 131);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Skype Information";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(312, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(207, 131);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "SMSLib Information";
			// 
			// lblActivity
			// 
			this.lblActivity.AutoSize = true;
			this.lblActivity.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblActivity.Location = new System.Drawing.Point(539, 94);
			this.lblActivity.Name = "lblActivity";
			this.lblActivity.Size = new System.Drawing.Size(48, 18);
			this.lblActivity.TabIndex = 13;
			this.lblActivity.Text = "Busy";
			// 
			// Skype
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 176);
			this.Controls.Add(this.lblActivity);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.pbStatus);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.groupBox1);
			this.Name = "Skype";
			this.Text = "SMSLib - Skype Interface";
			this.Load += new System.EventHandler(this.Skype_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Skype_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label01;
		private System.Windows.Forms.TextBox txtAccountName;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.ProgressBar pbStatus;
		private System.Windows.Forms.TextBox txtBalance;
		private System.Windows.Forms.TextBox txtBalanceText;
		private System.Windows.Forms.TextBox txtSMSNumbers;
		private System.Windows.Forms.Label label02;
		private System.Windows.Forms.Label label03;
		private System.Windows.Forms.Label label04;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblActivity;
	}
}

