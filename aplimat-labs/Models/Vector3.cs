using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Models
{
    class Vector3
    {
        public float x, y, z;
        private double v1;
        private int v2;

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(double v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Vector3(double _x, double _y, double _z)
        {
            this.x = (float)_x;
            this.y = (float)_y;
            this.z = (float)_z;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x,
            left.y + right.y,
            left.y + right.y);
         }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x,
            left.y - right.y,
            left.z - right.z);
        }
        public static Vector3 operator *(Vector3 left, float scalar)
        {
            return new Vector3(left.x * scalar,
                left.y * scalar,
                left.z * scalar);
        }

        public static Vector3 operator /(Vector3 left, float scalar)
        {
            return new Vector3(left.x / scalar,
                left.y / scalar,
                left.z / scalar);
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }
    }
}
