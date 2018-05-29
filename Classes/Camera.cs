using OpenTK;
using System;

class Camera
{
    public Vector3 position = new Vector3(5, 5, 0);
    public Vector3 direction = new Vector3(0, 0, 1);
    public Vector3 middle;
    public Vector3 p0, p1, p2;
    public float FOV = 1.0f, distancetocorner, FOVDegrees = 30, Screenheight;
    public double angletocorner;

    public Camera()
    {        
        // Middle of the camera plane 
        middle = position + Vector3.Normalize(direction) * FOV;

        // Corners of the camera plane
        p0 = middle + new Vector3(-1, -1, 0);
        p1 = middle + new Vector3(-1, 1, 0);
        p2 = middle + new Vector3(1, -1, 0);

        Screenheight = Math.Abs(p0.Y) + p1.Y;
        FOV = ((0.5f * Screenheight) / (float)Math.Tan((FOVDegrees/2)*(Math.PI / 180)));

        angletocorner = Math.Sin(1 / FOV);
        distancetocorner = (float)Math.Sqrt(1 + (FOV * FOV));
    }
}