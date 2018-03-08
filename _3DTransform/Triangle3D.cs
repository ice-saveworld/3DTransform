using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Triangle3D
    {
        private Vector4 a, b, c;
        public Vector4 A, B, C;
        public Triangle3D() { }
        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            this.A = this.a = new Vector4(a);
            this.B = this.b = new Vector4(b);
            this.C = this.c = new Vector4(c);
        }
        public void Transform(Matrix4x4 m)
        {
            a = m.Mul(A);
            b = m.Mul(B);
            c = m.Mul(C);
        }
        public void Draw(Graphics g)
        {
            g.DrawLines(new Pen(Color.Red,2),Get2DPointFs());
        }
        private PointF[] Get2DPointFs()
        {
            PointF[] pointFs = new PointF[4];
            pointFs[0] = Get2DPointF(a);
            pointFs[1] = Get2DPointF(b);
            pointFs[2] = Get2DPointF(c);
            pointFs[3] = pointFs[0];
            return pointFs;
        }
        public PointF Get2DPointF(Vector4 v)
        {
            PointF p = new PointF();
            p.X = (float)(v.x/v.w);
            p.Y = (float)(v.y/v.w);
            return p;
        }
    }
}
