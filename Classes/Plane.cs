using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Plane : Primitive
{
    Vector3 normal;
    int origindistance;
    public Surface screen;

    public Plane(Vector3 pos, int distance, Vector3 norm)
    {
        position = pos;
        origindistance = distance;
        normal = norm;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);

    }
}
