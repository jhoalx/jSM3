
namespace jSM3
{
    partial class ToolMainForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnStreamerVsAudience = new System.Windows.Forms.Button();
            this.btnAutotracker = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnClose.Location = new System.Drawing.Point(591, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✖ ";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnMinimize.Location = new System.Drawing.Point(564, 22);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 23);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "🗕";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.btnStreamerVsAudience);
            this.panelMenu.Controls.Add(this.btnAutotracker);
            this.panelMenu.Location = new System.Drawing.Point(16, 16);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(96, 448);
            this.panelMenu.TabIndex = 6;
            // 
            // btnStreamerVsAudience
            // 
            this.btnStreamerVsAudience.BackColor = System.Drawing.Color.Black;
            this.btnStreamerVsAudience.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStreamerVsAudience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStreamerVsAudience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnStreamerVsAudience.Location = new System.Drawing.Point(0, 80);
            this.btnStreamerVsAudience.Name = "btnStreamerVsAudience";
            this.btnStreamerVsAudience.Size = new System.Drawing.Size(96, 80);
            this.btnStreamerVsAudience.TabIndex = 2;
            this.btnStreamerVsAudience.Text = "Streamer vs Audience";
            this.btnStreamerVsAudience.UseVisualStyleBackColor = false;
            this.btnStreamerVsAudience.Click += new System.EventHandler(this.btnStreamerVsAudience_Click);
            // 
            // btnAutotracker
            // 
            this.btnAutotracker.BackColor = System.Drawing.Color.Black;
            this.btnAutotracker.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAutotracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutotracker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnAutotracker.Location = new System.Drawing.Point(0, 0);
            this.btnAutotracker.Name = "btnAutotracker";
            this.btnAutotracker.Size = new System.Drawing.Size(96, 80);
            this.btnAutotracker.TabIndex = 1;
            this.btnAutotracker.Text = "Tracker";
            this.btnAutotracker.UseVisualStyleBackColor = false;
            this.btnAutotracker.Click += new System.EventHandler(this.btnAutotracker_Click);
            // 
            // ToolMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::jSM3.Properties.Resources.toolbg;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ToolMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolMainForm_FormClosing);
            this.Load += new System.EventHandler(this.ToolMainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolMainForm_MouseDown);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Button btnMinimize;

        private System.Windows.Forms.Panel panelMenu;

        private System.Windows.Forms.Button btnAutotracker;

        private System.Windows.Forms.Button btnStreamerVsAudience;
        
        #endregion

    }
}