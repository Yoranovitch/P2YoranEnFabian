using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Camera
{
    public Vector3 position = new Vector3(5, 5, 0);
    public Vector3 direction = new Vector3(0, 0, 1);
    public Vector3 middle; 
    public Vector3 p0, p1, p2;
    public float distancetoscreen = 1.0f;
    Surface screen;

    public Camera()//Vector3 position, Vector3 direction)
    {
        middle = position + Vector3.Normalize(direction) * distancetoscreen;
        p0 = middle + new Vector3(-1, -1, 0);
        p1 = middle + new Vector3(-1, 1, 0);
        p2 = middle + new Vector3(1, -1, 0);
    }
}