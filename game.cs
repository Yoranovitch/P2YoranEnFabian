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
            for (int i = 0; i < 3; i++)
            {
                for (double j = 0.0; j < 360; j++)
                {
                    double angle = j * Math.PI / 180;
                    int x = (int)(l + 50 * Math.Cos(angle));
                    int y = (int)(80 + 50 * Math.Sin(angle));
                    int Location = x + y * screen.width;
                    screen.pixels[Location] = 255;
                }
                l += 120;
            }
        }
    }
}