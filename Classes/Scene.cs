using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Scene : Raytracer
    {
        List<Primitive> primitives;
        List<Light> lights;
        Intersection inter = new Intersection();
    }
}
