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
    public float finalresult, distance, shadowdistance;

    public Scene()
    {
        // Initialises the lists
        spheres = new List<Sphere>();
        planes = new List<Plane>();
        lights = new List<Light>();
        intersections = new List<Intersection>();

        // Adds the primitives and lights
        spheres.Add(new Sphere(new Vector3(6, 5, 8), 1, new Vector3(0.0f, 1.0f, 0.0f), true));
        spheres.Add(new Sphere(new Vector3(4, 5, 4), 1, new Vector3(0.0f, 0.0f, 1.0f), false));
        lights.Add(new Light(new Vector3(2, 5, 0), 3));
    }

    public int ShadowRays(Intersection i)
    {
        Vector3 diff, direction;
        float length;
        Ray ray;
        float kleurfactor = 0;
 
        // Creates a new ray
        // If this ray not intersects return a color to color the intersection that was used to shoot the ray from
        foreach(Light l in lights)
        {
            diff = l.position - i.position;
            direction = Vector3.Normalize(diff);
            length = diff.Length;

            ray = new Ray(i.position + (0.1f * direction), direction, i.x, i.y);
            ray.raydistance = length;

            CheckSpheres(ray);

            shadowdistance = ray.raydistance;

            // Creates the colorintensity depending on the distance to the lightsource and its intensity
            if (!ray.lightcollision)
            {
                kleurfactor += Vector3.Dot(i.normal, diff) / (length * length) * l.lightintensity;
                if (kleurfactor > 1)
                    kleurfactor = 1;
            }          
        }

        // Returns a color
        return Color(i.color * kleurfactor);
    }

    // Shoots a ray from a intersection to a every single light
    // Checks if there is a new intersection
    public void CheckSpheres(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;

        foreach (Sphere s in spheres)
        {
            // Creates a discriminant
            diff = ray.start - s.position;
            a = Vector3.Dot(ray.direction, ray.direction);
            b = 2 * Vector3.Dot(diff, ray.direction);
            c = Vector3.Dot(diff, diff) - (s.radius * s.radius);
            dis = (b * b) - (4 * a * c);

            // Checks for intersections 
            // Stores the distance to the closest intersection 
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

    // Checks if the given ray intersects with primitives in the scene
    // If so, add the closest intersection to the list with intersections
    public void Intersections(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;
        Intersection i1 = null;
        distance = ray.raydistance;

        foreach (Sphere p in spheres)
        {
            // Creates a discriminant
            diff = ray.start - p.position;
            a = Vector3.Dot(ray.direction, ray.direction);
            b = 2 * Vector3.Dot(diff, ray.direction);
            c = Vector3.Dot(diff, diff) - (p.radius * p.radius);
            dis = (b * b) - (4 * a * c);

            // Checks for intersections and store the distance to the closest in "distance"
            // Makes a intersection for every intersection that is closer than the previous one
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
                    i1 = new Intersection(p, distance, ray, p.reflexive);
                }

                i1.x = ray.X;
                i1.y = ray.Y;
            }
        }

        // Adds for every ray the closest intersection to the list with intersections
        if (i1 != null)
            intersections.Add(i1);
    }
}
