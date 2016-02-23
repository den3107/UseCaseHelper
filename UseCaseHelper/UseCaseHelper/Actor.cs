using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseHelper
{
    class Actor
    {
        public int x { get; }
        public int y { get; }
        public int width { get; }
        public int height { get; }
        public int margin { get; }
        public String name { get; }

        public Actor(int x, int y, int width, int height, int margin, String name)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.margin = margin;
            this.name = name;
        }

        public void Draw(Graphics g, Font Font)
        {
            // Background
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, x, y, width, height);

            // Body
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x + (int) width/2 - 13, y + margin, 25, 25);
            g.DrawLine(pen, x + (int) width / 2, y + 25 + margin, x + (int) width / 2, y + 50 + margin);
            g.DrawLine(pen, x + (int) width / 2 - 13, y + 35 + margin, x + (int) width / 2 + 13, y + 35 + margin);
            g.DrawLine(pen, x + (int) width / 2, y + 50 + margin, x + (int) width / 2 - 13, y + 75 + margin);
            g.DrawLine(pen, x + (int) width / 2, y + 50 + margin, x + (int) width / 2 + 13, y + 75 + margin);
            /*g.DrawEllipse(pen, x + margin, y + margin, 25, 25);
            g.DrawLine(pen, x + 13 + margin, y + 25 + margin, x + 13 + margin, y + 50 + margin);
            g.DrawLine(pen, x + margin, y + 35 + margin, x + 25 + margin, y + 35 + margin);
            g.DrawLine(pen, x + 13 + margin, y + 50 + margin, x + margin, y + 75 + margin);
            g.DrawLine(pen, x + 13 + margin, y + 50 + margin, x + 25 + margin, y + 75 + margin);*/

            if (name != "")
            {
                // Get size of name when drawn
                SizeF nameBounds = g.MeasureString(name, Font);

                // Get x position of name
                //int xPos = x + 13 - (int) Math.Ceiling(nameBounds.Width / 2) + margin;

                // Draw name
                brush = new SolidBrush(Color.Black);
                g.DrawString(name, Font, brush, x + (int) width / 2 - (int) nameBounds.Width / 2, y + 75 + margin + margin);
            }
        }
    }
}
