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
        spheres.Add(new Sphere(new Vector3(4, 5, 5), 2, new Vector3(255 / 255f, 224 / 255f, 189 / 255f)));// (0.0f, 1.0f, 0.0f)));
        spheres.Add(new Sphere(new Vector3(6, 5, 5), 2, new Vector3(255 / 255f, 224 / 255f, 189 / 255f))); //(0.0f, 0.0f, 1.0f)));
        lights.Add(new Light(new Vector3(5, 5, 0), 3));
        //lights.Add(new Light(new Vector3(7, 5, 0), 4));
    }

    public int ShadowRays(Intersection i)
    {
        Vector3 diff, direction;
        float length;
        Ray ray;
        float kleurfactor = 0;

        foreach(Light l in lights)
        {
            diff = l.position - i.position;
            direction = Vector3.Normalize(diff);
            length = diff.Length;

            ray = new Ray(i.position, direction, i.x, i.y);
            ray.raydistance = length;
            CheckSpheres(ray);

            if (!ray.lightcollision)
            {
                kleurfactor += Vector3.Dot(i.normal, diff) / (length * length) * l.lightintensity;
                if (kleurfactor > 1)
                    kleurfactor = 1;
            }          
        }
        return Color(i.color * kleurfactor);
    }

    public void CheckSpheres(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;

        foreach (Sphere s in spheres)
        {
            diff = ray.start - s.position;
            a = Vector3.Dot(ray.direction, ray.direction);
            b = 2 * Vector3.Dot(diff, ray.direction);
            c = Vector3.Dot(diff, diff) - (s.radius * s.radius);
            dis = (b * b) - (4 * a * c);

            if (dis > 0)
            {
                result1 = (float)((-b + Math.Sqrt(dis)) / (2 * a));
                result2 = (float)((-b - Math.Sqrt(dis)) / (2 * a));

                if (result1 > 0 && result2 > 0)
                {
                    ray.raydistance = Math.Min(result1, result2);
                    ray.lightcollision = true;
                    return;
                } 
            }
        }
    }

    public void Intersections(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;
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
        if (i1 != null)
            intersections.Add(i1);
    }
}
