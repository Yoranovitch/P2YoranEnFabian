using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Primitive
{
    Vector3 color = new Vector3(0, 0, 0);

    public virtual Intersection Intersects(Vector3 rayOrigin, Vector3 rayDirection)
    {
        return null;
    }

    public virtual void DrawDebug(float sceneWidth, float sceneHeight)
    {

    }
}
