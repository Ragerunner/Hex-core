using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public struct cubeCords
    {
        public int x, y, z;
        public cubeCords(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is cubeCords))
            {
                return false;
            }

            var cords = (cubeCords)obj;
            return x == cords.x &&
                   y == cords.y &&
                   z == cords.z;
        }
    }
    public struct offSetCords
    {
        public int x, y;
        public offSetCords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is offSetCords))
            {
                return false;
            }

            var cords = (offSetCords)obj;
            return x == cords.x &&
                   y == cords.y;
        }
    }
}
