using System;
using System.Drawing;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    class Game
    {
        public Surface screen;

        Application application;

        public void Init()
        {
            application = new Application(screen);
        }

        public void Tick()
        {        
        }

        public void RenderGL()
        {
            application.Update();
        }
    }
}