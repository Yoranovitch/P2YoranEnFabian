using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Plane : Primitive
{
    public Vector3 normal;
    public int origindistance;
    public Surface screen;

    public Plane(Vector3 pos, int distance, Vector3 norm, Vector3 col)
    {
        position = pos;
        origindistance = distance;
        normal = norm;
        color = col;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);
    }
}
