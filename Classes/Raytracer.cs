using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Raytracer
{
    Vector3 origin = new Vector3(0, 0, 0);
    Vector3 direction = new Vector3(0, 0, 1);
    float distance = 0;
    Scene scene;
    Camera camera;

    public Raytracer()
    {
        scene = new Scene();
        camera = new Camera();
    }

    public void Render()
    {
        
    }

    public void DrawDebug()
    {
        foreach(Primitive p in scene.primitives)
        {
            p.DrawDebug(10, 10);
        }
    }

}
