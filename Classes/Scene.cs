using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Scene
{
    public List<Primitive> primitives;
    List<Light> lights;

    public Scene()
    {
        primitives.Add(new Sphere());
        primitives.Add(new Sphere());
        primitives.Add(new Sphere());
    }
}
