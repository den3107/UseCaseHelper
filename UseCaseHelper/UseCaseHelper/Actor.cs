using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseHelper
{
    public class Actor
    {
        public int x { get; }
        public int y { get; }
        public int width { get; }
        public int height { get; }
        public String name { get; }

        public Actor(int x, int y, int width, int height, String name)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.name = name;
        }

        public void Draw(Graphics g, Font Font, Boolean isSelected)
        {
            // Draw background
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, x, y, width, height);

            // Get middle
            int middle = (int) width / 2;

            // Body
            Pen pen = new Pen((isSelected ? Color.Red : Color.Black)); // Use red when selected, otherwise black
            g.DrawEllipse(pen, x + middle - 13, y, 25, 25);
            g.DrawLine(pen, x + middle, y + 25, x + middle, y + 50);
            g.DrawLine(pen, x + middle - 13, y + 35, x + middle + 13, y + 35);
            g.DrawLine(pen, x + middle, y + 50, x + middle - 13, y + 75);
            g.DrawLine(pen, x + middle, y + 50, x + middle + 13, y + 75);

            if (name != "")
            {
                // Get size of name when drawn
                SizeF nameBounds = g.MeasureString(name, Font);

                // Draw name
                brush = new SolidBrush((isSelected ? Color.Red : Color.Black));
                g.DrawString(name, Font, brush, x + middle - (int) nameBounds.Width / 2, y + 75 + 5);
            }
        }
    }
}
