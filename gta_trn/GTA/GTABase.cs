using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gta_trn.GTA
{
    abstract class GTABase
    {
        public string exe;
        public uint player;
        public uint player_addr;
        public Vector3 saved_pos;
        public static MemoryEdit.Memory mem;

        //Trainer modifiers
        public static float fly_speed;
        public static bool alt_noclip;

        Action[] cheats;

        public GTABase()
        {
            cheats = new Action[]
            {
                Cheat_FlyToggle,
                Cheat_FlyForward,
                Cheat_FlyUp,
                Cheat_FlyDown,
                Cheat_FlySpeedAdd,
                Cheat_FlySpeedSub,
                Cheat_Health,
                Cheat_Armor,
                Cheat_WantedAdd,
                Cheat_WantedClear,
                Cheat_WantedToggle,
                Cheat_Money,
                Cheat_SavePos,
                Cheat_LoadPos
            };
        }

        public abstract void Cheat_FlyToggle();
        public abstract void Cheat_FlyForward();
        public abstract void Cheat_FlyUp();
        public abstract void Cheat_FlyDown();
        public abstract void Cheat_FlySpeedAdd();
        public abstract void Cheat_FlySpeedSub();
        public abstract void Cheat_Health();
        public abstract void Cheat_Armor();
        public abstract void Cheat_WantedAdd();
        public abstract void Cheat_WantedClear();
        public abstract void Cheat_WantedToggle();
        public abstract void Cheat_Money();
        public abstract void Cheat_SavePos();
        public abstract void Cheat_LoadPos();

        public void CallCheat(int idx)
        {
            player_addr = mem.Read(player);
            cheats[idx]();
        }

        public Vector3 GetPosDiff(Vector3 p1, Vector3 p2)
        {
            p1.x -= p2.x;
            p1.y -= p2.y;
            p1.z -= p2.z;
            return p1;
        }

        public Vector3 GetPosAdd(Vector3 p1, Vector3 p2)
        {
            p1.x += p2.x;
            p1.y += p2.y;
            p1.z += p2.z;
            return p1;
        }

        public float GetAngle(float dx, float dy)
        {
            return (float)Math.Atan2(dy, dx);
        }
    }
}
