using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gta_trn.GTA
{
    class GTA3 : GTABase
    {
        uint[] chaos =
        {
            0,
            40,
            200,
            400,
            800,
            1600,
            3200 
        };

        //Assembly codes
        //cmp eax,00000C80
        byte[] wanted_on_asm = { 0x3D, 0x80, 0x0C, 0x00, 0x00 };
        //jmp 004AD9E8
        byte[] wanted_off_asm = { 0xE9, 0xD0, 0x00, 0x00, 0x00 };

        uint camera = 0x628988;
        uint position = 0x34;
        uint accel = 0x78;
        uint freeze = 0x51;
        byte freeze_bit = 0x1;
        uint health = 0x2C0;
        uint armor = 0x2C4;
        uint money = 0x94139C;
        uint wanted = 0x53C;
        uint wanted2 = 0x0;
        uint wanted2_lvl = 0x18;
        //Assembly code addresses
        uint wanted_code = 0x4AD913;

        public GTA3()
        {
            exe = "gta3";
            player = 0x6FB1C8;
        }

        private Vector3 GetPlayerPos()
        {
            uint pos_ptr = player_addr + position;
            return new Vector3
            (
                mem.ReadFloat(pos_ptr),
                mem.ReadFloat(pos_ptr + 0x4),
                mem.ReadFloat(pos_ptr + 0x8)
            );
        }

        private float GetPlayerZ()
        {
            uint pos_ptr = player_addr + position;
            return mem.ReadFloat(pos_ptr + 0x8);
        }

        private Vector3 GetCameraPos()
        {
            return new Vector3
            (
                mem.ReadFloat(camera),
                mem.ReadFloat(camera + 0x4),
                mem.ReadFloat(camera + 0x8)
            );
        }

        private void SetPlayerPos(Vector3 pos)
        {
            uint pos_ptr = player_addr + position;
            mem.WriteBytes(pos_ptr, BitConverter.GetBytes(pos.x), 4);
            mem.WriteBytes(pos_ptr + 0x4, BitConverter.GetBytes(pos.y), 4);
            mem.WriteBytes(pos_ptr + 0x8, BitConverter.GetBytes(pos.z), 4);
            mem.WriteBytes(player_addr + accel, Constants.BYTES_VECTOR3_ZERO, 0xC);
        }

        private void SetPlayerZ(float z)
        {
            uint pos_ptr = player_addr + position;
            mem.WriteBytes(pos_ptr + 0x8, BitConverter.GetBytes(z), 4);
            mem.WriteBytes(player_addr + accel, Constants.BYTES_VECTOR3_ZERO, 0xC);
        }

        public override void Cheat_FlyToggle()
        {
            byte state = mem.ReadByte(player_addr + freeze);
            state ^= freeze_bit;
            mem.WriteBytes(player_addr + freeze, BitConverter.GetBytes(state), 4);
            mem.WriteBytes(player_addr + accel, Constants.BYTES_VECTOR3_ZERO, 0xC);
        }

        public override void Cheat_FlyForward()
        {
            Vector3 pl = GetPlayerPos();
            Vector3 cam = GetCameraPos();
            //Compensation for Z fly angle
            cam.z -= 0.5f;
            Vector3 diff = GetPosDiff(pl, cam);
            float angle = GetAngle(diff.x, diff.y);
            float dist = fly_speed;
            diff.x = (float)(dist * Math.Cos(angle));
            diff.y = (float)(dist * Math.Sin(angle));
            if (alt_noclip)
            {
                float zdist = (float)Math.Sqrt(diff.x * diff.x + diff.y * diff.y);
                float angle2 = (float)Math.Atan2(zdist, diff.z);
                diff.z = (float)(dist * (Math.Cos(angle2) / 2));
            }
            else diff.z = 0;
            SetPlayerPos(GetPosAdd(pl, diff));
        }

        public override void Cheat_FlyUp()
        {
            float pz = GetPlayerZ();
            SetPlayerZ(pz + fly_speed);
        }

        public override void Cheat_FlyDown()
        {
            float pz = GetPlayerZ();
            SetPlayerZ(pz - fly_speed);
        }

        public override void Cheat_FlySpeedAdd()
        {
            if (fly_speed >= 20) return;
            fly_speed++;
            Form1.inst.ChangeFlySpeed(fly_speed);
        }

        public override void Cheat_FlySpeedSub()
        {
            if (fly_speed <= 1) return;
            fly_speed--;
            Form1.inst.ChangeFlySpeed(fly_speed);
        }

        public override void Cheat_Health()
        {
            mem.WriteBytes(player_addr + health, Constants.BYTES_100, 0x4);
        }

        public override void Cheat_Armor()
        {
            mem.WriteBytes(player_addr + armor, Constants.BYTES_100, 0x4);
        }

        public override void Cheat_WantedAdd()
        {
            uint wanted_ptr = mem.Read(player_addr + wanted);
            uint tmp = 0;
            uint lvl = mem.Read(wanted_ptr + wanted2_lvl);
            if (lvl < 6)
                tmp = chaos[lvl++];
            byte[] buffer = BitConverter.GetBytes(tmp);
            mem.WriteBytes(wanted_ptr + wanted2, buffer, 4);
            buffer = BitConverter.GetBytes(lvl);
            mem.WriteBytes(wanted_ptr + wanted2_lvl, buffer, 4);
        }

        public override void Cheat_WantedClear()
        {
            uint wanted_ptr = mem.Read(player_addr + wanted);
            mem.WriteBytes(wanted_ptr + wanted2, Constants.BYTES_UINT_ZERO, 4);
            mem.WriteBytes(wanted_ptr + wanted2_lvl, Constants.BYTES_UINT_ZERO, 4);
        }

        public override void Cheat_WantedToggle()
        {
            Cheat_WantedClear();
            byte tmp = mem.ReadByte(wanted_code);
            mem.WriteBytes(wanted_code, tmp == wanted_on_asm[0] ? wanted_off_asm : wanted_on_asm, wanted_on_asm.Length);
        }

        public override void Cheat_Money()
        {
            uint tmp = mem.Read(money);
            tmp += 100000;
            byte[] buffer = BitConverter.GetBytes(tmp);
            mem.WriteBytes(money, buffer, 4);
        }

        public override void Cheat_SavePos()
        {
            saved_pos = GetPlayerPos();
        }

        public override void Cheat_LoadPos()
        {
            SetPlayerPos(saved_pos);
        }
    }
}