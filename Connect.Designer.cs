namespace Instrument_Connect
{
    partial class Connect
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.peerTextBox = new System.Windows.Forms.TextBox();
            this.yourLabel = new System.Windows.Forms.Label();
            this.yourIP = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.clickToCopy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(128, 28);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(142, 20);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "Enter Peer\'s Code:";
            // 
            // peerTextBox
            // 
            this.peerTextBox.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.peerTextBox.Location = new System.Drawing.Point(18, 57);
            this.peerTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.peerTextBox.Name = "peerTextBox";
            this.peerTextBox.Size = new System.Drawing.Size(356, 27);
            this.peerTextBox.TabIndex = 1;
            this.peerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yourLabel
            // 
            this.yourLabel.AutoSize = true;
            this.yourLabel.Location = new System.Drawing.Point(152, 126);
            this.yourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yourLabel.Name = "yourLabel";
            this.yourLabel.Size = new System.Drawing.Size(89, 20);
            this.yourLabel.TabIndex = 2;
            this.yourLabel.Text = "Your Code:";
            // 
            // yourIP
            // 
            this.yourIP.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.yourIP.Location = new System.Drawing.Point(128, 146);
            this.yourIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yourIP.Name = "yourIP";
            this.yourIP.Size = new System.Drawing.Size(142, 37);
            this.yourIP.TabIndex = 3;
            this.yourIP.Text = "0000000000";
            this.yourIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.yourIP.Click += new System.EventHandler(this.yourIP_Click);
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(141, 192);
            this.done.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(112, 35);
            this.done.TabIndex = 4;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // clickToCopy
            // 
            this.clickToCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.clickToCopy.Location = new System.Drawing.Point(263, 146);
            this.clickToCopy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clickToCopy.Name = "clickToCopy";
            this.clickToCopy.Size = new System.Drawing.Size(116, 37);
            this.clickToCopy.TabIndex = 5;
            this.clickToCopy.Text = "(click to copy)";
            this.clickToCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clickToCopy.Click += new System.EventHandler(this.clickToCopy_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 246);
            this.Controls.Add(this.yourIP);
            this.Controls.Add(this.clickToCopy);
            this.Controls.Add(this.done);
            this.Controls.Add(this.yourLabel);
            this.Controls.Add(this.peerTextBox);
            this.Controls.Add(this.ipLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Connect";
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.Connect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox peerTextBox;
        private System.Windows.Forms.Label yourLabel;
        private System.Windows.Forms.Label yourIP;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Label clickToCopy;
    }
}