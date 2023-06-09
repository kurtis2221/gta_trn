namespace gta_trn
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tmr_scan = new System.Windows.Forms.Timer(this.components);
            this.lb_hk = new System.Windows.Forms.Label();
            this.cb_game = new System.Windows.Forms.ComboBox();
            this.ch_altnoclip = new System.Windows.Forms.CheckBox();
            this.nm_interv = new System.Windows.Forms.NumericUpDown();
            this.lb_interv = new System.Windows.Forms.Label();
            this.lb_flyspeed = new System.Windows.Forms.Label();
            this.nm_flyspeed = new System.Windows.Forms.NumericUpDown();
            this.bt_about = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nm_interv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_flyspeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tmr_scan
            // 
            this.tmr_scan.Enabled = true;
            this.tmr_scan.Interval = 5000;
            this.tmr_scan.Tick += new System.EventHandler(this.tmr_scan_Tick);
            // 
            // lb_hk
            // 
            this.lb_hk.AutoSize = true;
            this.lb_hk.Location = new System.Drawing.Point(14, 73);
            this.lb_hk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_hk.Name = "lb_hk";
            this.lb_hk.Size = new System.Drawing.Size(78, 18);
            this.lb_hk.TabIndex = 0;
            this.lb_hk.Text = "Hotkeys\r\n";
            // 
            // cb_game
            // 
            this.cb_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_game.FormattingEnabled = true;
            this.cb_game.Items.AddRange(new object[] {
            "GTA 3",
            "GTA: Vice City",
            "GTA: San Andreas"});
            this.cb_game.Location = new System.Drawing.Point(13, 11);
            this.cb_game.Name = "cb_game";
            this.cb_game.Size = new System.Drawing.Size(213, 26);
            this.cb_game.TabIndex = 0;
            this.cb_game.SelectedIndexChanged += new System.EventHandler(this.cb_game_SelectedIndexChanged);
            // 
            // ch_altnoclip
            // 
            this.ch_altnoclip.AutoSize = true;
            this.ch_altnoclip.Location = new System.Drawing.Point(391, 11);
            this.ch_altnoclip.Name = "ch_altnoclip";
            this.ch_altnoclip.Size = new System.Drawing.Size(227, 22);
            this.ch_altnoclip.TabIndex = 1;
            this.ch_altnoclip.Text = "NoClip alt. fly mode";
            this.ch_altnoclip.UseVisualStyleBackColor = true;
            this.ch_altnoclip.CheckedChanged += new System.EventHandler(this.ch_altnoclip_CheckedChanged);
            // 
            // nm_interv
            // 
            this.nm_interv.Location = new System.Drawing.Point(543, 39);
            this.nm_interv.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_interv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_interv.Name = "nm_interv";
            this.nm_interv.Size = new System.Drawing.Size(75, 26);
            this.nm_interv.TabIndex = 2;
            this.nm_interv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nm_interv.ValueChanged += new System.EventHandler(this.nm_interv_ValueChanged);
            // 
            // lb_interv
            // 
            this.lb_interv.AutoSize = true;
            this.lb_interv.Location = new System.Drawing.Point(388, 41);
            this.lb_interv.Name = "lb_interv";
            this.lb_interv.Size = new System.Drawing.Size(148, 18);
            this.lb_interv.TabIndex = 5;
            this.lb_interv.Text = "Timer interval";
            // 
            // lb_flyspeed
            // 
            this.lb_flyspeed.AutoSize = true;
            this.lb_flyspeed.Location = new System.Drawing.Point(388, 73);
            this.lb_flyspeed.Name = "lb_flyspeed";
            this.lb_flyspeed.Size = new System.Drawing.Size(98, 18);
            this.lb_flyspeed.TabIndex = 6;
            this.lb_flyspeed.Text = "Fly Speed";
            // 
            // nm_flyspeed
            // 
            this.nm_flyspeed.Location = new System.Drawing.Point(543, 71);
            this.nm_flyspeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nm_flyspeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_flyspeed.Name = "nm_flyspeed";
            this.nm_flyspeed.Size = new System.Drawing.Size(75, 26);
            this.nm_flyspeed.TabIndex = 3;
            this.nm_flyspeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_flyspeed.ValueChanged += new System.EventHandler(this.nm_flyspeed_ValueChanged);
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(511, 399);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(107, 36);
            this.bt_about.TabIndex = 4;
            this.bt_about.Text = "About";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 447);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.nm_flyspeed);
            this.Controls.Add(this.lb_flyspeed);
            this.Controls.Add(this.lb_interv);
            this.Controls.Add(this.nm_interv);
            this.Controls.Add(this.ch_altnoclip);
            this.Controls.Add(this.cb_game);
            this.Controls.Add(this.lb_hk);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA Trainer by Kurtis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nm_interv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_flyspeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_scan;
        private System.Windows.Forms.Label lb_hk;
        private System.Windows.Forms.ComboBox cb_game;
        private System.Windows.Forms.CheckBox ch_altnoclip;
        private System.Windows.Forms.NumericUpDown nm_interv;
        private System.Windows.Forms.Label lb_interv;
        private System.Windows.Forms.Label lb_flyspeed;
        private System.Windows.Forms.NumericUpDown nm_flyspeed;
        private System.Windows.Forms.Button bt_about;
    }
}

