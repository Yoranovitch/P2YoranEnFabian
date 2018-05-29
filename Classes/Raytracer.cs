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
    public Camera camera;

    public Raytracer(Surface sur)
    {
        Sur = sur;
        scene = new Scene();
        camera = new Camera();
        origin = camera.position;
    }

    // Construct a new ray
    public struct Ray
    {
        public Vector3 start, direction;
        public int X, Y;
        public float raydistance;
        public bool lightcollision;

        public Ray(Vector3 a, Vector3 b, int x, int y)
        {
            start = a;
            direction = b;
            raydistance = 100;
            X = x;
            Y = y;
            lightcollision = false;
        }
    }

    // Determines the direction of a ray starting at the position of the camera using the camera plane 
    Vector3 Directions(int c, int d)
    {
        Vector3 dir, screenpos;
        screenpos = camera.p0 + c * (camera.p2 - camera.p0) / (Sur.width / 2) + d * (camera.p1 - camera.p0) / Sur.height;
        dir = screenpos - camera.position;
        return Vector3.Normalize(dir);
    }

    // Turns a Vector3 color into a integer color
    public static int Color(Vector3 color)
    {
        float red = MathHelper.Clamp(color.X, 0, 1);
        float green = MathHelper.Clamp(color.Y, 0, 1);
        float blue = MathHelper.Clamp(color.Z, 0, 1);
        return ((int)(red * 255f) << 16) + ((int)(green * 255f) << 8) + ((int)(blue * 255f));
    }

    // Turns a Vector3 position into a Vector2 position for the debug
    Vector2 Coordinates(Vector3 v)
    {
        return new Vector2(v.X * Sur.width / 20 + Sur.width / 2, Sur.height - (v.Z + 1) * Sur.height / 10);
    }

    // Renders the left side of out screen
    public void Render()
    {
        // Line that seperates the left and the right side of the screen
        Sur.Line(Sur.width / 2, 0, Sur.width / 2, Sur.height, 0xffffff);

        for (int i = 0; i < 512; i++)
        {
            for (int j = 0; j < 512; j++)
            {
                // Shoot a ray for each pixel on your screen
                scene.Intersections(new Ray(camera.position, Directions(i, j), i, j));

                // Draw those ray on the right side of your screen
                if (j == 256 && i % 16 == 0)
                {
                    float c = scene.distance * Sur.height / 10;
                    while ((int)Coordinates(camera.position).X + (int)(c * Directions(i, j).X) < Sur.width / 2)
                        c--;
                    Sur.Line((int)Coordinates(camera.position).X, (int)Coordinates(camera.position).Y, (int)Coordinates(camera.position).X + (int)(c * Directions(i, j).X), (int)Coordinates(camera.position).Y - (int)(c * Directions(i, j).Z), 0x444444);
                }
            }
        }

        foreach (Intersection i in scene.intersections)
        {         
            // Give the pixel that represent a intersection a color
            Sur.pixels[i.x + i.y * Sur.width] = scene.ShadowRays(i);

            // Draw the shadowrays that belong to the intersections
            if(Sur.pixels[i.x + i.y * Sur.width] != 0)
                if (i.y == 256 && i.x % 16 == 0)
                    foreach (Light l in scene.lights)
                    {
                        Vector3 dir = Vector3.Normalize(l.position - i.position);
                        float c = scene.shadowdistance * Sur.height / 10;
                        Sur.Line((int)Coordinates(i.position).X, (int)Coordinates(i.position).Y, (int)Coordinates(i.position).X + (int)(c * dir.X), (int)Coordinates(i.position).Y - (int)(c * dir.Z), 0x888888);
                    }
        }

        // Clear the list with intersections
        scene.intersections.Clear();
    }

    public void DrawDebug()
    {
        foreach(Sphere p in scene.spheres)
        {
            p.DrawDebug(512, 512);

            // Draw the circles belonging to the spheres in the scene
            for (double i = 0.0; i < 360; i++)
            {
                double angle = i / 180 * Math.PI;
                float x = (p.position.X + p.radius * (float)Math.Cos(angle));
                float y = (p.position.Y);
                float z = (p.position.Z + p.radius * (float)Math.Sin(angle));

                Vector2 circle = Coordinates(new Vector3(x, y, z));
                Sur.pixels[(int)circle.X + (int)circle.Y * Sur.width] = Color(p.color);
            }
        }

        // Draw the camera in the debug
        Sur.Line((int)Coordinates(camera.position).X + 10, (int)Coordinates(camera.position).Y + 20, (int)Coordinates(camera.position).X, (int)Coordinates(camera.position).Y, 0xffffff);
        Sur.Line((int)Coordinates(camera.position).X - 10, (int)Coordinates(camera.position).Y + 20, (int)Coordinates(camera.position).X, (int)Coordinates(camera.position).Y, 0xffffff);

        // Draw the camera plane in the debug
        Sur.Line((int)Coordinates(camera.p1).X, (int)Coordinates(camera.p1).Y, (int)Coordinates(camera.p2).X, (int)Coordinates(camera.p2).Y, 0xffffff);

        foreach(Light l in scene.lights)
        {
            // Draw the lights in the debug
            Sur.Line((int)Coordinates(l.position).X - 10, (int)Coordinates(l.position).Y - 10, (int)Coordinates(l.position).X + 10, (int)Coordinates(l.position).Y + 10, 0xffffff);
            Sur.Line((int)Coordinates(l.position).X - 10, (int)Coordinates(l.position).Y + 10, (int)Coordinates(l.position).X + 10, (int)Coordinates(l.position).Y - 10, 0xffffff);
        }
    }

}
