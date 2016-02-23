using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCaseHelper
{
    public partial class Form1 : Form
    {
        readonly int actorMargin = 5;
        readonly int actorBaseWidth;
        readonly int actorBaseHeight;
        int selectedIndex;
        List<Actor> actors;
        Graphics pictureBoxGraphics;

        public Form1()
        {
            actorBaseWidth = 25 + actorMargin * 2;
            actorBaseHeight = 75 + actorMargin * 2;

            InitializeComponent();

            selectedIndex = -1;
            actors = new List<Actor>();
            pictureBoxGraphics = useCaseDiagramPictureBox.CreateGraphics();
        }

        private void useCaseDiagramPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Redraw();
            selectedIndex = -1;
            // Check if in create mode
            if (createRadioButton.Checked)
            {
                // Check if actor is checked
                if (actorRadioButton.Checked)
                {
                    // Open dialog prompting user for actor name
                    using (ActorNameForm dialog = new ActorNameForm())
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            // Actor creation cancelled, step out of method
                            return;
                        }
                        else
                        {
                            // Actor creation validated, continue!
                            CreateActor(dialog.actorNameTextBox.Text, e.Location);
                        }
                    }
                }
            }
            else // Select mode
            {
                for (int i = 0; i < actors.Count; i++)
                {
                    Actor actor = actors[i];

                    // Check if mouse is within boudn of actor
                    if(e.Location.X >= actor.x && e.Location.X <= actor.x + actor.width && e.Location.Y >= actor.y && e.Location.Y <= actor.y + actor.height)
                    {
                        // Draw rectangle around actor
                        Pen pen = new Pen(Color.Black);
                        pictureBoxGraphics.DrawRectangle(pen, actor.x, actor.y, actor.width, actor.height);
                        selectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void Redraw()
        {
            pictureBoxGraphics.Clear(Color.White);
            foreach(Actor actor in actors)
            {
                actor.Draw(pictureBoxGraphics, Font);
            }
        }

        private void CreateActor(String name, Point mouse)
        {
            int width = actorBaseWidth;
            int height = actorBaseHeight;

            if(name != "")
            {
                // Get size of name when drawn
                SizeF nameBounds = pictureBoxGraphics.MeasureString(name, Font);

                // Update width and height
                width = Math.Max(width, (int) nameBounds.Width + actorMargin * 2);
                height += (int) nameBounds.Height + actorMargin;
            }

            // Create actor
            Actor actor = new Actor(mouse.X - actorMargin, mouse.Y - actorMargin, width, height, actorMargin, name);

            // Draw actor
            actor.Draw(pictureBoxGraphics, Font);

            // Add actor to list
            actors.Add(actor);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Basically just clear everything
            pictureBoxGraphics.Clear(Color.White);
            actors = new List<Actor>();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if(selectedIndex >= 0)
            {
                if(actorRadioButton.Checked)
                {
                    actors.RemoveAt(selectedIndex);
                }
                else if (useCaseRadioButton.Checked)
                {

                }
                else
                {

                }
            }
            Redraw();
        }
    }
}
