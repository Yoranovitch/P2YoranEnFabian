using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raytracer;

class Intersection
{
    public int x, y;
    public Vector3 position, color, normal;
    public Primitive Object;
    public float distance;
    public Ray ray;

    public Intersection(Primitive p, float a, Ray r)
    {
        Object = p;
        ray = r;
        distance = a;
        position = r.start + r.direction * distance;
        color = p.color;
        normal = Vector3.Normalize(position - Object.position);
    }
}