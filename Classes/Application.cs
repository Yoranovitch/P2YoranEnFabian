using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK;

class Application
{
    Raytracer raytracer;
    Camera camera;
    KeyboardState prevState;

    public Application(Surface sur)
    {
        raytracer = new Raytracer(sur);
        camera = raytracer.camera;
        prevState = Keyboard.GetState();
    }

    public void Update()
    {
            raytracer.DrawDebug();
            raytracer.Render();
    }

    public void HandleInput()
    {
        if (Keyboard.GetState().IsKeyDown(Key.A))
        {
            camera.p0.Z -= 0.1f;
            camera.p1.Z -= 0.1f;
            camera.p2.Z += 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.D))
        {
            camera.p0.Z += 0.1f;
            camera.p1.Z += 0.1f;
            camera.p2.Z -= 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.W))
        {
            camera.p0.Z += 0.1f;
            camera.p1.Z -= 0.1f;
            camera.p2.Z += 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.S))
        {
            camera.p0.Z -= 0.1f;
            camera.p1.Z += 0.1f;
            camera.p2.Z -= 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.Right))
        {
            camera.position.X += 0.1f;
            camera.p0.X += 0.1f;
            camera.p1.X += 0.1f;
            camera.p2.X += 0.1f;
            camera.middle.X += 0.1f;
        }
            
        if (Keyboard.GetState().IsKeyDown(Key.Left))
        {
            camera.position.X -= 0.1f;
            camera.p0.X -= 0.1f;
            camera.p1.X -= 0.1f;
            camera.p2.X -= 0.1f;
            camera.middle.X -= 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.Up))
        {
            camera.position.Y -= 0.1f;
            camera.p0.Y -= 0.1f;
            camera.p1.Y -= 0.1f;
            camera.p2.Y -= 0.1f;
            camera.middle.Y -= 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.Down))
        {
            camera.position.Y += 0.1f;
            camera.p0.Y += 0.1f;
            camera.p1.Y += 0.1f;
            camera.p2.Y += 0.1f;
            camera.middle.Y += 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.Enter))
        {
            camera.position.Z += 0.1f;
            camera.p0.Z += 0.1f;
            camera.p1.Z += 0.1f;
            camera.p2.Z += 0.1f;
            camera.middle.Z += 0.1f;
        }
        if (Keyboard.GetState().IsKeyDown(Key.LShift))
        {
            camera.position.Z -= 0.1f;
            camera.p0.Z -= 0.1f;
            camera.p1.Z -= 0.1f;
            camera.p2.Z -= 0.1f;
            camera.middle.Z -= 0.1f;
        }       
    }
}