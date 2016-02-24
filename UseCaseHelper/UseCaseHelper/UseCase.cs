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
            // Get size of name
            SizeF nameBounds = g.MeasureString(name, Font);

            // Update width
            width = Math.Max(minWidth, (int) nameBounds.Width + 15 * 2);

            // Draw background
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, x, y, width, height);

            // Draw ellipse and name
            Pen pen = new Pen((isSelected ? Color.Red : Color.Black));
            g.DrawEllipse(pen, x, y, width, height);
            brush = new SolidBrush((isSelected ? Color.Red : Color.Black));
            g.DrawString(name, Font, brush, x + width / 2 - nameBounds.Width / 2, y + height / 2 - nameBounds.Height / 2);
        }
    }
}
