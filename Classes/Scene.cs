﻿using OpenTK;
using System;
using System.Collections.Generic;
using static Raytracer;

class Scene
{
    public List<Sphere> spheres;
    public List<Plane> planes;
    public List<Light> lights;
    public List<Intersection> intersections;
    public float finalresult, finalresult2, distance, distance2, shadowdistance, t;
    public Vector3 v, u;

    public Scene()
    {
        v = new Vector3(1, 0, 0);
        u = new Vector3(0, 0, 1);

        // Initialises the lists
        spheres = new List<Sphere>();
        planes = new List<Plane>();
        lights = new List<Light>();
        intersections = new List<Intersection>();

        // Adds the primitives and lights
        spheres.Add(new Sphere(new Vector3(7, 5, 5), 1, new Vector3(0.0f, 1.0f, 0.0f), true));
        spheres.Add(new Sphere(new Vector3(3, 5, 5), 1, new Vector3(0.0f, 0.0f, 1.0f), false));
        lights.Add(new Light(new Vector3(2, 5, 0), 3));
        lights.Add(new Light(new Vector3(8, 5, 0), 3));
        planes.Add(new Plane(new Vector3(5, 0, 5), 5, new Vector3(0, -1, 0), new Vector3(1.0f, 1.0f, 1.0f)));
    }

    //public int Mirror(Intersection i)
    //{
    //    Vector3 nextdirection = i.ray.direction - 2 * i.prim.normal * (Vector3.Dot(i.ray.direction, i.prim.normal));
    //    Ray ray = new Ray(i.position, nextdirection, i.x, i.y);

    //    Vector3 idiff;
    //    Intersection nexti = null;
    //    float d, e, f, dis2, result3, result4;
    //    distance2 = ray.raydistance;

    //    foreach (Sphere s in spheres)
    //    {
    //        // Creates a discriminant
    //        idiff = ray.start - s.position;
    //        d = Vector3.Dot(ray.direction, ray.direction);
    //        e = 2 * Vector3.Dot(idiff, ray.direction);
    //        f = Vector3.Dot(idiff, idiff) - (s.radius * s.radius);
    //        dis2 = (e * e) - (4 * d * f);

    //        // Checks for intersections and store the distance to the closest in "distance"
    //        // Makes a intersection for every intersection that is closer than the previous one
    //        if (dis2 > 0)
    //        {
    //            result3 = (float)((-e + Math.Sqrt(dis2)) / (2 * d));
    //            result4 = (float)((-e - Math.Sqrt(dis2)) / (2 * d));

    //            if (result3 > 0 && result4 > 0)
    //                finalresult2 = Math.Min(result3, result4);
    //            else
    //                finalresult2 = Math.Max(result3, result4);

    //            if (finalresult2 < distance2)
    //            {
    //                distance2 = finalresult2;
    //                nexti = new Intersection(s, distance2, ray, s.reflexive);
    //            }

    //            nexti.x = ray.X;
    //            nexti.y = ray.Y;
    //        }
    //    }
    //    //if (nexti.reflexive)
    //    //    Mirror(nexti);
    //    if(nexti != null)
    //        return ShadowRays(nexti);
    //    return 0;
    //}

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

            if (i.prim is Plane)
            {
                Vector3 intersectionposition = i.position - i.prim.position;
                if (Math.Sin(Vector3.Dot(intersectionposition, v)) < 0 && Math.Sin(Vector3.Dot(intersectionposition, u)) < 0)
                    i.color = new Vector3(0.0f, 0.0f, 0.0f);
                else if (Math.Sin(Vector3.Dot(intersectionposition, v)) < 0 || Math.Sin(Vector3.Dot(intersectionposition, u)) < 0)
                    i.color = new Vector3(1.0f, 1.0f, 1.0f);
                else
                    i.color = new Vector3(0.0f, 0.0f, 0.0f);
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
            float d = p.startdistance;
            t = (Vector3.Dot(ray.start, p.normal) + d) / Vector3.Dot(ray.direction, p.normal);
            if (Vector3.Dot(p.normal, ray.direction) < 0)
            {
                Vector3 IntPoint = ray.start + (t * ray.direction);
                i2 = new Intersection(p, t, ray, false);
                i2.x = ray.X;
                i2.y = ray.Y;
            }
        }

        // Adds for every ray its intersections to the list with intersections
        if(i2 != null)
            intersections.Add(i2);
        if(i1 != null)
            intersections.Add(i1);
    }
}
