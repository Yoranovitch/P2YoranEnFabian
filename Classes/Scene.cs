using OpenTK;
using System;
using System.Collections.Generic;
using static Raytracer;

class Scene
{
    public List<Sphere> spheres;
    public List<Plane> planes;
    public List<Light> lights;
    public List<Intersection> intersections;
    public float finalresult, distance, shadowdistance, t;

    public Scene()
    {
        // Initialises the lists
        spheres = new List<Sphere>();
        planes = new List<Plane>();
        lights = new List<Light>();
        intersections = new List<Intersection>();

        // Adds the primitives and lights
        spheres.Add(new Sphere(new Vector3(7, 5, 5), 1, new Vector3(0.0f, 1.0f, 0.0f), true));
        spheres.Add(new Sphere(new Vector3(3, 5, 5), 1, new Vector3(0.0f, 0.0f, 1.0f), false));
        lights.Add(new Light(new Vector3(2, 5, 0), 3));
        planes.Add(new Plane(new Vector3(5, 0, 5), 5, new Vector3(0, -1, 0), new Vector3(1.0f, 0.0f, 0.0f)));
    }

    public int ShadowRays(Intersection i)
    {
        Vector3 diff, direction;
        float length;
        Ray ray;
        float kleurfactor = 0.2f;
 
        // Creates a new ray
        // If this ray not intersects return a color to color the intersection that was used to shoot the ray from
        foreach(Light l in lights)
        {
            diff = l.position - i.position;
            direction = Vector3.Normalize(diff);
            length = diff.Length;

            ray = new Ray(i.position + (0.1f * direction), direction, i.x, i.y);
            ray.raydistance = length;

            ray = CheckSpheres(ray);

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
    public Ray CheckSpheres(Ray ray)
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
                    return ray;
                } 
            }
        }
        return ray;
    }

    // Checks if the given ray intersects with primitives in the scene
    // If so, add the closest intersection to the list with intersections
    public void Intersections(Ray ray)
    {
        float a, b, c, dis, result1, result2;
        Vector3 diff;
        Intersection i1 = null, i2 = null;
        distance = ray.raydistance;

        foreach (Sphere s in spheres)
        {
            // Creates a discriminant
            diff = ray.start - s.position;
            a = Vector3.Dot(ray.direction, ray.direction);
            b = 2 * Vector3.Dot(diff, ray.direction);
            c = Vector3.Dot(diff, diff) - (s.radius * s.radius);
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
                    i1 = new Intersection(s, distance, ray, s.reflexive);
                }

                i1.x = ray.X;
                i1.y = ray.Y;
            }
        }

        foreach(Plane p in planes)
        {
            float d = 0;
            t = (-Vector3.Dot(ray.start, p.normal) + d) / Vector3.Dot(ray.direction, p.normal);
            if (Vector3.Dot(p.normal, ray.direction) < 0)
            {
                Vector3 IntPoint = ray.start + (t * ray.direction);
                i2 = new Intersection(p, t, ray, false);
                i2.x = ray.X;
                i2.y = ray.Y;
            }

        }
        if (i1 != null && i2 == null)
        {
            intersections.Add(i1);
        }
        else if(i2 != null && i1 == null)
        {
            intersections.Add(i2);
        }
        else if(i2 != null && i1 != null)
        {
            if(t > distance)
            {
                intersections.Add(i2);
            }
            else
            {
                intersections.Add(i1);
            }
        }

        // Adds for every ray the closest intersection to the list with intersections
        if (i1 != null)
            intersections.Add(i1);
    }
}
