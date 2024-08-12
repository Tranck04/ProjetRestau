namespace RestaurantManager.Vue
{
    partial class RestaurantDisplay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.txtBox_Inspection = new System.Windows.Forms.TextBox();
            this.btn_Config = new System.Windows.Forms.Button();
            this.txtBox_Console = new System.Windows.Forms.TextBox();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 444);
            this.panel1.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Start.Location = new System.Drawing.Point(12, 449);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(400, 50);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // txtBox_Inspection
            // 
            this.txtBox_Inspection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Inspection.Location = new System.Drawing.Point(986, 12);
            this.txtBox_Inspection.Multiline = true;
            this.txtBox_Inspection.Name = "txtBox_Inspection";
            this.txtBox_Inspection.ReadOnly = true;
            this.txtBox_Inspection.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_Inspection.Size = new System.Drawing.Size(289, 88);
            this.txtBox_Inspection.TabIndex = 2;
            // 
            // btn_Config
            // 
            this.btn_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Config.Location = new System.Drawing.Point(886, 449);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(389, 50);
            this.btn_Config.TabIndex = 3;
            this.btn_Config.Text = "Config.";
            this.btn_Config.UseVisualStyleBackColor = true;
            this.btn_Config.Click += new System.EventHandler(this.btn_Config_Click);
            // 
            // txtBox_Console
            // 
            this.txtBox_Console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Console.Location = new System.Drawing.Point(986, 106);
            this.txtBox_Console.Multiline = true;
            this.txtBox_Console.Name = "txtBox_Console";
            this.txtBox_Console.ReadOnly = true;
            this.txtBox_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_Console.Size = new System.Drawing.Size(289, 337);
            this.txtBox_Console.TabIndex = 6;
            // 
            // btn_Pause
            // 
            this.btn_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pause.Location = new System.Drawing.Point(418, 449);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(462, 50);
            this.btn_Pause.TabIndex = 7;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // RestaurantDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 511);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.txtBox_Console);
            this.Controls.Add(this.btn_Config);
            this.Controls.Add(this.txtBox_Inspection);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.panel1);
            this.Name = "RestaurantDisplay";
            this.Text = "Restaurant Manager 2018";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txtBox_Inspection;
        private System.Windows.Forms.Button btn_Config;
        private System.Windows.Forms.TextBox txtBox_Console;
        private System.Windows.Forms.Button btn_Pause;
    }
}