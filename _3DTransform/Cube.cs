﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace _3DTransform
{
    class Cube
    {
        Vector4 a = new Vector4(-0.5,0.5,0.5,1);
        Vector4 b = new Vector4(0.5,0.5,0.5,1);
        Vector4 c = new Vector4(0.5,0.5,-0.5,1);
        Vector4 d = new Vector4(-0.5,0.5,-0.5,1);

        Vector4 e = new Vector4(-0.5, -0.5, 0.5, 1);
        Vector4 f = new Vector4(0.5, -0.5, 0.5, 1);
        Vector4 g = new Vector4(0.5, -0.5, -0.5, 1);
        Vector4 h = new Vector4(-0.5, -0.5, -0.5, 1);

        private Triangle3D[] triangles = new Triangle3D[12];
        public Cube()
        {
            //top
            triangles[0] = new Triangle3D(a,b,c);
            triangles[1] = new Triangle3D(a,c,d);
            //bottom
            triangles[2] = new Triangle3D(e,h,f);
            triangles[3] = new Triangle3D(f,h,g);
            //front
            triangles[4] = new Triangle3D(d,c,g);
            triangles[5] = new Triangle3D(d,g,h);
            //back
            triangles[6] = new Triangle3D(a,e,b);
            triangles[7] = new Triangle3D(b,e,f);
            //left
            triangles[8] = new Triangle3D(a,d,h);
            triangles[9] = new Triangle3D(a,h,e);
            //right
            triangles[10] = new Triangle3D(b,f,c);
            triangles[11] = new Triangle3D(c,f,g);
        }
        public void Transform(Matrix4x4 m)
        {
            foreach (var t in triangles)
            {
                t.Transform(m);
            }
        }
        public void CalculateLighting(Matrix4x4 _Object2World,Vector4 lightNormal)
        {
            foreach (var t in triangles)
            {
                t.CalculateLighting(_Object2World,lightNormal);
            }
        }
        public void Draw(Graphics g,bool isLine)
        {
            foreach (var t in triangles)
            {
                t.Draw(g, isLine);
            }
        }
    }
}
