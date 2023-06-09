using System;
using System.Windows.Forms;

namespace gta_trn
{
    class Constants
    {
        public static byte[] BYTES_VECTOR3_ZERO = new byte[12];
        public static byte[] BYTES_UINT_ZERO = new byte[4];
        public static byte[] BYTES_100 = { 0x00, 0x00, 0xC8, 0x42 };
    }

    class HotKey
    {
        public Keys mod;
        public Keys key;
        public bool active;
        public int idx;
        public string text;
        //
        public bool fly;
        public bool toggle;

        public HotKey(Keys mod, Keys key, int idx, string text)
        {
            this.key = key;
            this.mod = mod;
            this.idx = idx;
            this.text = text;
        }
    }

    struct Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}