using System;
using System.Drawing;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    class Game
    {
        public Surface screen;

        Application application = new Application();

        public void Init()
        {
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