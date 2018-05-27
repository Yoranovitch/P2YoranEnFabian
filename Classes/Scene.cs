using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raytracer;

class Scene
{
    public List<Sphere> spheres;
    public List<Plane> planes;
    public List<Light> lights;
    public List<Intersection> intersections;
    public float finalresult, distance;

    public Scene()
    {
        spheres = new List<Sphere>();
        planes = new List<Plane>();
        lights = new List<Light>();
        intersections = new List<Intersection>();
        spheres.Add(new Sphere(new Vector3(4, 5, 5), 2, new Vector3(0.0f, 1.0f, 0.0f)));
        spheres.Add(new Sphere(new Vector3(6, 5, 5), 2, new Vector3(0.0f, 0.0f, 1.0f)));
        //planes.Add(new Plane(new Vector3(0, 5, 5), 5, new Vector3(1, 0, 0), new Vector3(1.0f, 0.0f, 0.0f)));
        lights.Add(new Light(new Vector3(0, 5, 2)));
    }

    public void Intersections(Ray ray)
    {
        float a, b, c, f, dis, result1, result2;
        Vector3 diff, d, e;
        Intersection i1 = null, i2 = null;
        distance = ray.raydistance;

        foreach (Sphere p in spheres)
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

                if(finalresult < distance)
                {
                    distance = finalresult;
                    i1 = new Intersection(p, distance, ray);
                }

                i1.x = ray.X;
                i1.y = ray.Y;
            }
        }

        //distance = ray.raydistance;

        //foreach (Plane p in planes)
        //{
        //    d = (p.position - ray.start) * p.normal;
        //    e = (ray.direction - p.normal);
        //    f = d.X / e.X + d.Y / e.Y + d.Z / e.Z;

        //    i2 = new Intersection(p, f, ray);
        //    i2.x = ray.X;
        //    i2.y = ray.Y;

        //    f = -(Vector3.Dot(ray.start, p.normal) + p.origindistance) / (Vector3.Dot(ray.direction, p.normal));
        //    if(f >= 0 && f < distance)
        //    {
        //        i2 = new Intersection(p, f, ray);
        //    }
        //}

        //if (i2 != null)
        //    intersections.Add(i2);
        if (i1 != null)
            intersections.Add(i1);
    }
}
