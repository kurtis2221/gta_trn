using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Media;
using gta_trn.GTA;
using System.IO;

namespace gta_trn
{
    public partial class Form1 : Form
    {
        private const string trn_snd = "gta_trn.wav";
        public static Form1 inst;
        internal static MemoryEdit.Memory mem;

        GTABase[] game_list =
        {
            new GTA3(),
            new GTAVC(),
            new GTASA()
        };
        GTABase curr_game;

        KeyHook.GlobalKeyboardHook gkh;
        Thread thd;

        Process game;
        HotKey[] hotkeys;
        bool running = true;
        bool block_events = false;

        int tmr_interv;
        SoundPlayer snd;

        public Form1()
        {
            InitializeComponent();
            inst = this;
            //Hotkeys
            hotkeys = new HotKey[]
            {
                new HotKey(Keys.Shift, Keys.I, 0, "Toggle NoClip"),
                new HotKey(Keys.Shift, Keys.P, 1, "NoClip Forward") { fly = true },
                new HotKey(Keys.Shift, Keys.O, 2, "NoClip Up") { fly = true },
                new HotKey(Keys.Shift, Keys.L, 3, "NoClip Down") { fly = true },
                new HotKey(Keys.Shift, Keys.U, 4, "Increase NoClip Speed"),
                new HotKey(Keys.Shift, Keys.J, 5, "Decrease NoClip Speed"),
                new HotKey(Keys.Alt, Keys.D1, 11, "Add $100,000"),
                new HotKey(Keys.Alt, Keys.D4, 7, "Full Armor"),
                new HotKey(Keys.Alt, Keys.D5, 6, "Full Health"),
                new HotKey(Keys.Alt, Keys.D6, 8, "Increase Wanted Level"),
                new HotKey(Keys.Alt, Keys.D7, 9, "Clear Wanted Level"),
                new HotKey(Keys.Alt, Keys.D0, 10, "Disable Wanted Levels"),
                new HotKey(Keys.Alt, Keys.D8, 6, "Infinite Health") { toggle = true },
                new HotKey(Keys.Alt, Keys.D9, 7, "Infinite Armor") { toggle = true },
                new HotKey(Keys.Shift, Keys.D1, 12, "Save Position"),
                new HotKey(Keys.Shift, Keys.D2, 13, "Load Position")
            };
            //Generate text
            foreach (HotKey h in hotkeys)
            {
                lb_hk.Text += "\n" + h.text.PadRight(24, ' ') + " - " + h.mod + " + " + h.key;
            }
            //Init hooks
            mem = new MemoryEdit.Memory();
            gkh = new KeyHook.GlobalKeyboardHook();
            gkh.KeyDown += gkh_KeyDown;
            gkh.KeyUp += gkh_KeyUp;
            gkh.Hook();
            //Set window controls
            cb_game.SelectedIndex = 0;
            tmr_interv = (int)nm_interv.Value;
            GTABase.alt_noclip = ch_altnoclip.Checked;
            GTABase.fly_speed = (int)nm_flyspeed.Value;
            //Start helper thread
            thd = new Thread(HelperThread);
            thd.Start();
            //Scan
            ScanForGame();
            try
            {
                if (File.Exists(trn_snd))
                {
                    snd = new SoundPlayer(trn_snd);
                    snd.Load();
                }
            }
            catch
            {
                snd = null;
            }
        }

        public void ChangeFlySpeed(float fly_speed)
        {
            block_events = true;
            nm_flyspeed.Value = (decimal)fly_speed;
            block_events = false;
        }

        private void PlaySnd()
        {
            if (snd != null) snd.Play();
        }

        private void ScanForGame()
        {
            Process[] procs = Process.GetProcessesByName(curr_game.exe);
            if (procs.Length > 0)
            {
                game = procs[0];
                mem.Attach((uint)game.Id, MemoryEdit.Memory.ProcessAccessFlags.All);
            }
        }

        private void HelperThread()
        {
            while (running)
            {
                foreach (HotKey h in hotkeys)
                {
                    if (h.fly && h.active)
                    {
                        curr_game.CallCheat(h.idx);
                    }
                    if (h.toggle && h.active)
                    {
                        curr_game.CallCheat(h.idx);
                    }
                }
                Thread.Sleep(tmr_interv);
            }
        }

        private void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (!mem.IsFocused()) return;
            foreach (HotKey h in hotkeys)
            {
                if (e.Modifiers != h.mod || e.KeyCode != h.key) continue;
                if (h.active && !h.toggle) h.active = false;
            }
        }

        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mem.IsFocused()) return;
            foreach (HotKey h in hotkeys)
            {
                if (e.Modifiers != h.mod || e.KeyCode != h.key) continue;
                if (h.toggle)
                {
                    h.active = !h.active;
                    PlaySnd();
                }
                else if (!h.active)
                {
                    h.active = true;
                    if (!h.fly)
                    {
                        curr_game.CallCheat(h.idx);
                        PlaySnd();
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            running = false;
            bool thd_closed = false;
            try
            {
                thd_closed = thd.Join(2000);
            }
            catch { }
            if (!thd_closed) Environment.Exit(0);
        }

        private void tmr_scan_Tick(object sender, EventArgs e)
        {
            if (game == null || game.HasExited) ScanForGame();
        }

        private void cb_game_SelectedIndexChanged(object sender, EventArgs e)
        {
            curr_game = game_list[cb_game.SelectedIndex];
            GTABase.mem = mem;
            mem.Detach();
            game = null;
        }

        private void ch_altnoclip_CheckedChanged(object sender, EventArgs e)
        {
            GTABase.alt_noclip = ch_altnoclip.Checked;
        }

        private void nm_interv_ValueChanged(object sender, EventArgs e)
        {
            tmr_interv = (int)nm_interv.Value;
        }

        private void nm_flyspeed_ValueChanged(object sender, EventArgs e)
        {
            if (block_events) return;
            GTABase.fly_speed = (int)nm_flyspeed.Value;
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program written by Kurtis (2022)\nWritten in Visual C# 2008 Express Edition (.NET 3.5)", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}