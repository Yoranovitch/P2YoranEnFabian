using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class Application
{
    Raytracer raytracer;
    Camera camera;
    bool drawDebug;
    KeyboardState prevState;

    public Application(Surface sur)
    {
        raytracer = new Raytracer(sur);
        camera = new Camera();
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
        //if (prevState.IsKeyUp(Key.A) && Keyboard.GetState().IsKeyDown(Key.A))
        //    Camera.MoveLeft();
        //    //drawDebug = !drawDebug;
        //if (prevState.IsKeyUp(Key.D) && Keyboard.GetState().IsKeyDown(Key.D))
        //    Camera.MoveRight();
        //    prevState = Keyboard.GetState();
    }
}