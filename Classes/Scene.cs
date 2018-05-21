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
    public List<Light> lights;
    public List<Intersection> intersections;
    float finalresult;

    public Scene()
    {
        primitives = new List<Primitive>();
        lights = new List<Light>();
        intersections = new List<Intersection>();
        primitives.Add(new Sphere(new Vector3(5, 5, 5), 2, new Vector3(1.0f, 1.0f, 1.0f)));
    }

    public void Intersections(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;
        Intersection i1 = null;

        foreach(Sphere p in primitives)
        {
            diff = ray.start - p.position;
            a = Vector3.Dot(ray.direction, ray.direction);
            b = 2 * Vector3.Dot(diff, ray.direction);
            c = Vector3.Dot(diff, diff) - (p.radius * p.radius);
            dis = (b * b) - (4 * a * c);

            if(dis > 0)
            {
                result1 = (float)((-b + Math.Sqrt(dis)) / (2 * a));
                result2 = (float)((-b - Math.Sqrt(dis)) / (2 * a));

                if (result1 > 0 && result2 > 0)
                    finalresult = Math.Min(result1, result2);
                else
                    finalresult = Math.Max(result1, result2);

                i1 = new Intersection(p, finalresult, ray);

                i1.x = ray.X;
                i1.y = ray.Y;

                intersections.Add(i1);
                break; 
            }
        } 
    }
}
