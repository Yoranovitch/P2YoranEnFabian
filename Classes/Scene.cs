using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raytracer;

class Scene
{
    public List<Primitive> primitives;
    List<Light> lights;

    public Scene()
    {
        primitives.Add(new Sphere(new Vector3(0, 0, 5), 2));
        primitives.Add(new Sphere(new Vector3(-2, 0, 5), 2));
        primitives.Add(new Sphere(new Vector3(2, 0, 5), 2));
    }

    public void Intersections(Ray ray)
    {

    }
}
