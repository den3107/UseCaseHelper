using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseHelper
{
    class Line
    {
        public int xSelectionBox { get; }
        public int ySelectionBox { get; }
        public int widthSelectionBox { get; }
        public int heightSelectionBox { get; }
        public Actor actor { get; }
        public UseCase useCase { get; }

        public Line(int xSelectionBox, int ySelectionBox, int widthSelectionBox, int heightSelectionBox, Actor actor, UseCase useCase)
        {
            this.xSelectionBox = xSelectionBox;
            this.ySelectionBox = ySelectionBox;
            this.widthSelectionBox = widthSelectionBox;
            this.heightSelectionBox = heightSelectionBox;
            this.actor = actor;
            this.useCase = useCase;
        }

        public void Draw(Graphics g, Font font, Boolean isSelected)
        {
            // Get middle of actor and usecase
            Point middleActor = new Point(actor.x + actor.width / 2, actor.y + actor.height / 2);
            Point middleUseCase = new Point(useCase.x + useCase.width / 2, useCase.y + useCase.height / 2);

            // Draw line
            Pen pen = new Pen((isSelected ? Color.Red : Color.Black));
            g.DrawLine(pen, middleActor, middleUseCase);

            // Draw selection box
            Brush brush = new SolidBrush((isSelected ? Color.Red : Color.Black));
            g.FillRectangle(brush, xSelectionBox, ySelectionBox, widthSelectionBox, heightSelectionBox);

            // Redraw actor and user case
            actor.Draw(g, font, false);
            useCase.Draw(g, font, false);
        }
    }
}
