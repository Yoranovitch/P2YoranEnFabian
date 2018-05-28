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
    //bool drawDebug;
    KeyboardState prevState;

    public Application(Surface sur)
    {
        raytracer = new Raytracer(sur);
        camera = raytracer.camera;//new Camera();
        prevState = Keyboard.GetState();
    }

    public void Update()
    {
        //if (drawDebug)
            raytracer.DrawDebug();
        //else
        
            raytracer.Render();
    }

    public void HandleInput()
    {
        if (prevState.IsKeyUp(Key.Right) && Keyboard.GetState().IsKeyDown(Key.Right))
        {
            camera.position.X += 0.1f;
        }
            
        if (prevState.IsKeyUp(Key.Left) && Keyboard.GetState().IsKeyDown(Key.Left))
            camera.position.X -= 0.1f;
        if (prevState.IsKeyUp(Key.Up) && Keyboard.GetState().IsKeyDown(Key.Up))
            camera.position.Y -= 0.1f;
        if (prevState.IsKeyUp(Key.Down) && Keyboard.GetState().IsKeyDown(Key.Down))
            camera.position.Y += 0.1f;
        if (prevState.IsKeyUp(Key.W) && Keyboard.GetState().IsKeyDown(Key.W))
            camera.position.Z += 0.1f;
        if (prevState.IsKeyUp(Key.S) && Keyboard.GetState().IsKeyDown(Key.S))
            camera.position.Z -= 0.1f;
        prevState = Keyboard.GetState();
        //drawDebug = !drawDebug;
    }
}