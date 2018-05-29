using System;
using Template;
using OpenTK.Input;

class Application
{
    Raytracer raytracer;
    Camera camera;
    KeyboardState prevState;
    int i = 90;

    public Application(Surface sur)
    {
        raytracer = new Raytracer(sur);
        camera = raytracer.camera;
        prevState = Keyboard.GetState();
    }

    public void Update()
    {
        // Calls the draw methods in raytracer
        raytracer.DrawDebug();
        raytracer.Render();
    }

    // Camera Movement
    public void HandleInput()
    {
        // Turn left
        if (Keyboard.GetState().IsKeyDown(Key.A))
        {
            i++;
            if (i >= 450)
                i = 90;
            double angle = i * Math.PI / 180;
            camera.p0.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle + camera.angletocorner));
            camera.p0.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle + camera.angletocorner));
            camera.p1.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle + camera.angletocorner));
            camera.p1.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle + camera.angletocorner));
            camera.p2.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle - camera.angletocorner));
            camera.p2.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle - camera.angletocorner));
        }
        // Turn right
        if (Keyboard.GetState().IsKeyDown(Key.D))
        {
            i--;
            if (i < 0)
                i = 450;
            double angle = i * Math.PI / 180;
            camera.p0.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle + camera.angletocorner));
            camera.p0.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle + camera.angletocorner));
            camera.p1.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle + camera.angletocorner));
            camera.p1.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle + camera.angletocorner));
            camera.p2.X = (camera.position.X + camera.distancetocorner * (float)Math.Cos(angle - camera.angletocorner));
            camera.p2.Z = (camera.position.Z + camera.distancetocorner * (float)Math.Sin(angle - camera.angletocorner));
        }
        //// Turn up
        //if (Keyboard.GetState().IsKeyDown(Key.W))
        //{
        //    camera.p0.Z += 0.1f;
        //    camera.p1.Z -= 0.1f;
        //    camera.p2.Z += 0.1f;
        //}
        //// Turn down
        //if (Keyboard.GetState().IsKeyDown(Key.S))
        //{
        //    camera.p0.Z -= 0.1f;
        //    camera.p1.Z += 0.1f;
        //    camera.p2.Z -= 0.1f;
        //}
        // Move right
        if (Keyboard.GetState().IsKeyDown(Key.Right))
        {
            camera.position.X += 0.1f;
            camera.p0.X += 0.1f;
            camera.p1.X += 0.1f;
            camera.p2.X += 0.1f;
            camera.middle.X += 0.1f;
        }
        // Move left 
        if (Keyboard.GetState().IsKeyDown(Key.Left))
        {
            camera.position.X -= 0.1f;
            camera.p0.X -= 0.1f;
            camera.p1.X -= 0.1f;
            camera.p2.X -= 0.1f;
            camera.middle.X -= 0.1f;
        }
        // Move up
        if (Keyboard.GetState().IsKeyDown(Key.Up))
        {
            camera.position.Y -= 0.1f;
            camera.p0.Y -= 0.1f;
            camera.p1.Y -= 0.1f;
            camera.p2.Y -= 0.1f;
            camera.middle.Y -= 0.1f;
        }
        // Move down
        if (Keyboard.GetState().IsKeyDown(Key.Down))
        {
            camera.position.Y += 0.1f;
            camera.p0.Y += 0.1f;
            camera.p1.Y += 0.1f;
            camera.p2.Y += 0.1f;
            camera.middle.Y += 0.1f;
        }
        // Move forward
        if (Keyboard.GetState().IsKeyDown(Key.Enter))
        {
            camera.position.Z += 0.1f;
            camera.p0.Z += 0.1f;
            camera.p1.Z += 0.1f;
            camera.p2.Z += 0.1f;
            camera.middle.Z += 0.1f;
        }
        // Move backward
        if (Keyboard.GetState().IsKeyDown(Key.RShift))
        {
            camera.position.Z -= 0.1f;
            camera.p0.Z -= 0.1f;
            camera.p1.Z -= 0.1f;
            camera.p2.Z -= 0.1f;
            camera.middle.Z -= 0.1f;
        }       
    }
}