using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Sphere : Primitive
{
    public int radius;

    public Sphere(Vector3 pos, int rad, Vector3 col)
    {
        position = pos;
        radius = rad;
        color = col;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);

        //for (double i = 0.0; i < 360; i++)
        //{
        //    double angle = i * Math.PI / 180;
        //    int x = (int)(p.position.X + Sur.width + p.radius * Math.Cos(angle));
        //    int y = (int)(p.position.Z + 1 + p.radius * Math.Sin(angle));
        //    //int Location = x + y * (int)sceneWidth;
        //    //sur.pixels[Location] = 255;
        //}
    }
}