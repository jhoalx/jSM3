using System.ComponentModel;

namespace jSM3.Panels
{
    partial class StreamerVsAudienceSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStreamerVsAudience = new System.Windows.Forms.Label();
            this.btnLaunchStreamerVsAudience = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStreamerVsAudience
            // 
            this.lblStreamerVsAudience.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamerVsAudience.ForeColor = System.Drawing.Color.Green;
            this.lblStreamerVsAudience.Location = new System.Drawing.Point(88, 162);
            this.lblStreamerVsAudience.Name = "lblStreamerVsAudience";
            this.lblStreamerVsAudience.Size = new System.Drawing.Size(338, 138);
            this.lblStreamerVsAudience.TabIndex = 0;
            this.lblStreamerVsAudience.Text = "Streamer Vs Audience";
            // 
            // btnLaunchStreamerVsAudience
            // 
            this.btnLaunchStreamerVsAudience.BackColor = System.Drawing.Color.Black;
            this.btnLaunchStreamerVsAudience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunchStreamerVsAudience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnLaunchStreamerVsAudience.Location = new System.Drawing.Point(403, 402);
            this.btnLaunchStreamerVsAudience.Name = "btnLaunchStreamerVsAudience";
            this.btnLaunchStreamerVsAudience.Size = new System.Drawing.Size(106, 43);
            this.btnLaunchStreamerVsAudience.TabIndex = 1;
            this.btnLaunchStreamerVsAudience.Text = "Launch";
            this.btnLaunchStreamerVsAudience.UseVisualStyleBackColor = false;
            this.btnLaunchStreamerVsAudience.Click += new System.EventHandler(this.btnLaunchStreamerVsAudience_Click);
            // 
            // StreamerVsAudienceSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnLaunchStreamerVsAudience);
            this.Controls.Add(this.lblStreamerVsAudience);
            this.Name = "StreamerVsAudienceSettingsPanel";
            this.Size = new System.Drawing.Size(512, 448);
            this.Load += new System.EventHandler(this.StreamerVsAudiencePanel_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLaunchStreamerVsAudience;

        private System.Windows.Forms.Button btnLaunchStreammerVsAudience;

        private System.Windows.Forms.Button btnLaunchAutotracker;

        private System.Windows.Forms.Label lblStreamerVsAudience;

        #endregion
    }
}