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
    bool drawDebug;
    KeyboardState prevState;

    public Application(Surface sur)
    {
        raytracer = new Raytracer(sur);
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
        if (prevState.IsKeyUp(Key.S) && Keyboard.GetState().IsKeyDown(Key.S))
            drawDebug = !drawDebug;
        prevState = Keyboard.GetState();
    }
}