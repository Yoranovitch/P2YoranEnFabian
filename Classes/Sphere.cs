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
    public bool reflexive;

    public Sphere(Vector3 pos, int rad, Vector3 col, bool refl)
    {
        position = pos;
        radius = rad;
        color = col;
        reflexive = refl;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);
    }
}