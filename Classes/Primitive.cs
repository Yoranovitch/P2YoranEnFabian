using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Primitive
{
    public Vector3 color = new Vector3(1.0f, 1.0f, 0.5f);
    public Vector3 position;

    public virtual Intersection Intersects(Vector3 rayOrigin, Vector3 rayDirection)
    {
        return null;
    }

    public virtual void DrawDebug(float sceneWidth, float sceneHeight)
    {
    }
}
