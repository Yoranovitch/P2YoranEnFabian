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
            screen.Line(0, 0, 5, 5, 0xffffff);
        }

        public void RenderGL()
        {
            application.Update();
        }
    }
}