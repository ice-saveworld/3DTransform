using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Vector4
    {
        public double x, y, z, w;
        public Vector4() { }
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Vector4(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public Vector4 Cross(Vector4 v)
        {
            return new Vector4(this.y * v.z - this.z * v.y, this.z * v.x - this.x * v.z, this.x * v.y - this.y * v.x, 0);
        }
        public Vector4 Normalized
        {
            get {
                double mod = Math.Sqrt(x * x + y * y + z * z + w * w);
                return new Vector4(x / mod, y / mod, z / mod, w / mod);
            }
        }
        public double dot(Vector4 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }
    }
}
