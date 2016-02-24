using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseHelper
{
    class UseCase
    {
        // Minimum sizes
        readonly int minWidth;

        // Location and size
        public int x { get; }
        public int y { get; }
        public int width { get; private set; }
        public int height { get; }

        // Properties
        public String name { get; set; }
        public String summary { get; set; }
        public List<Actor> actors { get; private set; }
        public String description { get; set; }
        public String exceptions { get; set; }
        public String result { get; set; }

        public UseCase(int minWidth, int x, int y, int width, int height, String name)
        {
            this.minWidth = minWidth;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.name = name;
            this.summary = "";
            this.actors = new List<Actor>();
            this.description = "";
            this.exceptions = "";
            this.result = "";
        }

        public void addActor(Actor actor)
        {
            actors.Add(actor);
        }

        public void removeActor(Actor actor)
        {
            actors.Remove(actor);
        }

        public void Draw(Graphics g, Font Font, Boolean isSelected)
        {
            // Get middle
            //int middle = (int) width / 2;

            // Get size of name
            SizeF nameBounds = g.MeasureString(name, Font);

            // Update width
            width = Math.Max(minWidth, (int) nameBounds.Width + 15 * 2);

            // Draw ellipse and name
            Pen pen = new Pen((isSelected ? Color.Red : Color.Black));
            g.DrawEllipse(pen, x, y, width, height);
            Brush brush = new SolidBrush((isSelected ? Color.Red : Color.Black));
            g.DrawString(name, Font, brush, x + width / 2 - nameBounds.Width / 2, y + height / 2 - nameBounds.Height / 2);

            // Body
            /*Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x + middle - 13, y + margin, 25, 25);
            g.DrawLine(pen, x + middle, y + 25 + margin, x + middle, y + 50 + margin);
            g.DrawLine(pen, x + middle - 13, y + 35 + margin, x + middle + 13, y + 35 + margin);
            g.DrawLine(pen, x + middle, y + 50 + margin, x + middle - 13, y + 75 + margin);
            g.DrawLine(pen, x + middle, y + 50 + margin, x + middle + 13, y + 75 + margin);

            if (name != "")
            {
                // Get size of name when drawn
                SizeF nameBounds = g.MeasureString(name, Font);

                // Draw name
                brush = new SolidBrush(Color.Black);
                g.DrawString(name, Font, brush, x + middle - (int) nameBounds.Width / 2, y + 75 + margin + margin);
            }*/
        }
    }
}
