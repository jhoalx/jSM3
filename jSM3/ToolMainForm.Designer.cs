
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
            this.btnGrantVariaSuit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtEnergy = new System.Windows.Forms.TextBox();
            this.lblReserveSupplyMode = new System.Windows.Forms.Label();
            this.btnLaunchTracker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGrantVariaSuit
            // 
            this.btnGrantVariaSuit.Location = new System.Drawing.Point(12, 57);
            this.btnGrantVariaSuit.Name = "btnGrantVariaSuit";
            this.btnGrantVariaSuit.Size = new System.Drawing.Size(138, 50);
            this.btnGrantVariaSuit.TabIndex = 0;
            this.btnGrantVariaSuit.Text = "Grant Varia Suit";
            this.btnGrantVariaSuit.UseVisualStyleBackColor = true;
            this.btnGrantVariaSuit.Click += new System.EventHandler(this.btnGrant_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Grant Varia Suit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mensaje Chimbo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtEnergy
            // 
            this.txtEnergy.Location = new System.Drawing.Point(12, 9);
            this.txtEnergy.Name = "txtEnergy";
            this.txtEnergy.Size = new System.Drawing.Size(100, 20);
            this.txtEnergy.TabIndex = 3;
            // 
            // lblReserveSupplyMode
            // 
            this.lblReserveSupplyMode.Location = new System.Drawing.Point(118, 12);
            this.lblReserveSupplyMode.Name = "lblReserveSupplyMode";
            this.lblReserveSupplyMode.Size = new System.Drawing.Size(88, 22);
            this.lblReserveSupplyMode.TabIndex = 4;
            this.lblReserveSupplyMode.Text = "label1";
            // 
            // btnLaunchTracker
            // 
            this.btnLaunchTracker.Location = new System.Drawing.Point(12, 253);
            this.btnLaunchTracker.Name = "btnLaunchTracker";
            this.btnLaunchTracker.Size = new System.Drawing.Size(138, 20);
            this.btnLaunchTracker.TabIndex = 5;
            this.btnLaunchTracker.Text = "Tracker";
            this.btnLaunchTracker.UseVisualStyleBackColor = true;
            this.btnLaunchTracker.Click += new System.EventHandler(this.btnLaunchTracker_Click);
            // 
            // ToolMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 285);
            this.Controls.Add(this.btnLaunchTracker);
            this.Controls.Add(this.lblReserveSupplyMode);
            this.Controls.Add(this.txtEnergy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGrantVariaSuit);
            this.Name = "ToolMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolMainForm_FormClosing);
            this.Load += new System.EventHandler(this.ToolMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnLaunchTracker;

        private System.Windows.Forms.Label lblReserveSupplyMode;

        private System.Windows.Forms.TextBox txtEnergy;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button btnGrantVariaSuit;

        #endregion

    }
}