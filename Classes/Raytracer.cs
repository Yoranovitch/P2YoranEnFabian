using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Raytracer
{
    Vector3 origin;
    Vector3 direction;
    float distance = 10;
    Scene scene;
    Surface Sur;
    Camera camera;

    public Raytracer(Surface sur)
    {
        Sur = sur;
        scene = new Scene();
        camera = new Camera();
        origin = camera.position;
    }

    public struct Ray
    {
        public Vector3 start, direction;
        public int X, Y;
        public Ray(Vector3 a, Vector3 b, int x, int y)
        {
            start = a;
            direction = b;
            X = x;
            Y = y;
        }
    }

    Vector3 Directions(int c, int d)
    {
        Vector3 dir, screenpos;
        screenpos = camera.p0 + c * (camera.p1 - camera.p0) / (Sur.width / 2) + d * (camera.p2 - camera.p0) / Sur.height;
        dir = screenpos - camera.position;
        return Vector3.Normalize(dir);
    }

    public static int Color(Vector3 color)
    {
        float red = MathHelper.Clamp(color.X, 0, 1);
        float green = MathHelper.Clamp(color.Y, 0, 1);
        float blue = MathHelper.Clamp(color.Z, 0, 1);
        return ((int)(red * 255f) << 16) + ((int)(green * 255f) << 8) + ((int)(blue * 255f));
    }

    Vector2 Coordinates(Vector3 v)
    {
        return new Vector2(v.X * Sur.width / 20 + Sur.width / 2, Sur.height - v.Z * Sur.height / 10);
    }

    public void Render()
    {
        for (int i = 0; i < 512; i++)
        {
            for (int j = 0; j < 512; j++)
            {
                scene.Intersections(new Ray(camera.position, Directions(i, j), i, j));
            }
        }

        foreach(Intersection i in scene.intersections)
        {
            Sur.pixels[i.x + i.y * Sur.width] = Color(i.color);
        }
    }

    public void DrawDebug()
    {
        foreach(Primitive p in scene.primitives)
        {
            p.DrawDebug(512, 512, Sur);
        }
    }

}
