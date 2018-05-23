using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using OpenTK.Graphics.OpenGL;

class Sphere : Primitive
{
    int radius;
    public Surface screen;

    public Sphere(Vector3 pos, int rad)
    {
        position = pos;
        radius = rad;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight, Surface sur)
    {
        base.DrawDebug(sceneWidth, sceneHeight, sur);
        GL.Color3(1.0f, 0.0f, 0.0f);
        GL.Begin(PrimitiveType.Triangles);
        GL.Vertex3(-0.5f, -0.5f, 0);
        GL.Vertex3(0.5f, -0.5f, 0);
        GL.Vertex3(-0.5f, 0.5f, 0);
        GL.End();
        for (double i = 0.0; i < 360; i++)
        {
            double angle = i * Math.PI / 180;
            int x = (int)(position.X + sceneWidth + radius * Math.Cos(angle));
            int y = (int)(position.Z + radius * Math.Sin(angle));
            int Location = x + y * (int)sceneWidth;
            sur.pixels[Location] = 255;
        }
    }
}