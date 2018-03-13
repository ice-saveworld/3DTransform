using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
namespace _3DTransform
{
    class Triangle3D
    {
        private Vector4 a, b, c;
        public Vector4 A, B, C;
        private double dot;
        private bool backCulling;
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
        public double CalculateLighting(Matrix4x4 _Object2World,Vector4 lightNormal)
        {
            this.Transform(_Object2World);
            Vector4 u = this.b - this.a;
            Vector4 v = this.c - this.a;

            Vector4 normal = u.Cross(v);
            dot = normal.Normalized.dot(lightNormal.Normalized);
            dot = Math.Max(0,dot);
            backCulling = normal.Normalized.dot(new Vector4(0, 0, -1, 0))<0;

            return normal.z;
        }
        public void Draw(Graphics g,bool isLine)
        {
            if (isLine)
            {
                g.DrawLines(new Pen(Color.Red, 2), Get2DPointFs());
            }
            else
            {
                if (!backCulling)
                {
                    int rgb = (int)(200 * dot) + 55;
                    Color color = Color.FromArgb(rgb, rgb, rgb);
                    Brush bruch = new SolidBrush(color);
                    GraphicsPath graphics = new GraphicsPath();
                    graphics.AddLines(Get2DPointFs());
                    g.FillPath(bruch, graphics);
                }
            }
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
            p.Y = -(float)(v.y/v.w);
            return p;
        }
    }
}
