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
            int l = screen.width / 2 + 80;
            int r = 50;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 360; j++)
                {
                    double angle = j * Math.PI / 180;
                    int x = (int)(l + r * Math.Cos(angle));
                    int y = (int)(80 + r * Math.Sin(angle));
                    int Location = x + y * screen.width;
                    screen.pixels[Location] = 255;
                }
                l += 110;
            }
        }
    }
}