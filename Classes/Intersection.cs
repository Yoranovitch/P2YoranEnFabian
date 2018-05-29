using OpenTK;
using static Raytracer;

class Intersection
{
    public int x, y;
    public Vector3 position, color, normal;
    public Primitive prim;
    public float distance;
    public Ray ray;

    public Intersection(Primitive p, float a, Ray r)
    {
        prim = p;
        ray = r;
        distance = a;
        position = r.start + r.direction * distance;
        color = p.color;
        if (prim is Plane)
            normal = p.normal;
        else
            normal = Vector3.Normalize(position - prim.position);
    }
}