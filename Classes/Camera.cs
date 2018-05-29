using OpenTK;
using System;

class Camera
{
    public Vector3 position = new Vector3(5, 5, 0);
    public Vector3 direction = new Vector3(0, 0, 1);
    public Vector3 middle;
    public Vector3 p0, p1, p2;
    public float FOV, distancetocorner, FOVDegrees, Screenheight = 2;
    public double angletocorner;

    public Camera()
    {
        CalculateCamera();
    }
    
    public void CalculateCamera()
    {
        // The distance from the camera to the screen
        FOV = ((0.5f * Screenheight) / (float)Math.Tan((FOVDegrees) * (Math.PI / 180)));

        direction = middle - position;

        // Middle of the camera plane 
        middle = position + Vector3.Normalize(direction) * FOV;

        // Corners of the camera plane
        p0 = middle + new Vector3(-1, -1, 0);
        p1 = middle + new Vector3(-1, 1, 0);
        p2 = middle + new Vector3(1, -1, 0);

        angletocorner = FOVDegrees * Math.PI / 180;
        distancetocorner = (float)Math.Sqrt(1 + (FOV * FOV));
    }
}