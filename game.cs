using System;
using System.IO;

namespace Template
{
    class Game
    {
        public Surface screen;

        public void Init()
        {
        }

        public void Tick()
        {
            screen.Clear(0);
        }
    }
}