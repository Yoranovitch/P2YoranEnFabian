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

    public Raytracer()
    {
        scene = new Scene();
    }

    public void Render()
    {
        
    }

    public void DrawDebug()
    {

    }

}
