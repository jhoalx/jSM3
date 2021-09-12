
namespace jSM3.Panels
{
    partial class AutotrackerSettingsPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLaunchAutotracker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLaunchAutotracker
            // 
            this.btnLaunchAutotracker.BackColor = System.Drawing.Color.Black;
            this.btnLaunchAutotracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunchAutotracker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(168)))), ((int)(((byte)(72)))));
            this.btnLaunchAutotracker.Location = new System.Drawing.Point(403, 402);
            this.btnLaunchAutotracker.Name = "btnLaunchAutotracker";
            this.btnLaunchAutotracker.Size = new System.Drawing.Size(106, 43);
            this.btnLaunchAutotracker.TabIndex = 0;
            this.btnLaunchAutotracker.Text = "Launch";
            this.btnLaunchAutotracker.UseVisualStyleBackColor = false;
            this.btnLaunchAutotracker.Click += new System.EventHandler(this.btnLaunchAutotracker_Click);
            // 
            // AutotrackerSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnLaunchAutotracker);
            this.Name = "AutotrackerSettingsPanel";
            this.Size = new System.Drawing.Size(512, 448);
            this.Load += new System.EventHandler(this.AutotrackerSettingsPanel_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnLaunchAutotracker;
    }
}
