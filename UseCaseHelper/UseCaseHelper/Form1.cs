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
        readonly int actorBaseWidth = 25;
        readonly int actorBaseHeight = 75;
        readonly int useCaseBaseWidth = 50;
        readonly int useCaseBaseHeight = 25;
        int selectedIndex;
        Type selectedType;
        List<Actor> actors;
        List<UseCase> useCases;
        Graphics pictureBoxGraphics;

        public Form1()
        {
            InitializeComponent();

            selectedIndex = -1;
            selectedType = null;
            actors = new List<Actor>();
            useCases = new List<UseCase>();
            pictureBoxGraphics = useCaseDiagramPictureBox.CreateGraphics();
        }

        private void useCaseDiagramPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            selectedIndex = -1;
            selectedType = null;
            Redraw();
            // Check if in create mode
            if (createRadioButton.Checked)
            {
                // Check if actor is checked
                if (actorRadioButton.Checked)
                {
                    // Open dialog prompting user for actor name
                    using (NameForm dialog = new NameForm())
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Actor creation validated, continue!
                            CreateActor(dialog.actorNameTextBox.Text, e.Location);
                        }
                        else
                        {
                            // Actor creation cancelled, step out of method
                            return;
                        }
                    }
                }
                else if(useCaseRadioButton.Checked)
                {
                    // Open dialog prompting user for use case name
                    using (NameForm dialog = new NameForm())
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Actor creation validated, continue!
                            CreateUseCase(dialog.actorNameTextBox.Text, e.Location);
                        }
                        else
                        {
                            // Actor creation cancelled, step out of method
                            return;
                        }
                    }
                }
                else if (lineRadioButton.Checked)
                {

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
                        // Redraw selected actor
                        actor.Draw(pictureBoxGraphics, Font, true);
                        selectedIndex = i;
                        selectedType = typeof(Actor);
                        return;
                    }
                }
                for (int i = 0; i < useCases.Count; i++)
                {
                    UseCase useCase = useCases[i];

                    // Check if mouse is within boudn of actor
                    if (e.Location.X >= useCase.x && e.Location.X <= useCase.x + useCase.width && e.Location.Y >= useCase.y && e.Location.Y <= useCase.y + useCase.height)
                    {
                        // Redraw selected actor
                        useCase.Draw(pictureBoxGraphics, Font, true);
                        selectedIndex = i;
                        selectedType = typeof(UseCase);
                        return;
                    }
                }
            }
        }

        private void Redraw()
        {
            pictureBoxGraphics.Clear(Color.White);
            for (int i = 0; i < actors.Count; i++)
            {
                actors[i].Draw(pictureBoxGraphics, Font, (i == selectedIndex && selectedType == typeof(Actor) ? true : false));
            }
            for (int i = 0; i < useCases.Count; i++)
            {
                useCases[i].Draw(pictureBoxGraphics, Font, (i == selectedIndex && selectedType == typeof(UseCase) ? true : false));
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
                width = Math.Max(width, (int) nameBounds.Width);
                height += (int) nameBounds.Height;
            }

            // Create actor
            Actor actor = new Actor(mouse.X, mouse.Y, width, height, name);

            // Draw actor and set as selected
            actor.Draw(pictureBoxGraphics, Font, true);
            selectedIndex = actors.Count;
            selectedType = typeof(Actor);

            // Add actor to list
            actors.Add(actor);
        }

        private void CreateUseCase(String name, Point mouse)
        {
            int width = useCaseBaseWidth;
            int height = useCaseBaseHeight;

            if (name != "")
            {
                // Get size of name when drawn
                SizeF nameBounds = pictureBoxGraphics.MeasureString(name, Font);

                // Update width
                width = Math.Max(width, (int) nameBounds.Width + 15 * 2);
            }

            // Create use case
            UseCase useCase = new UseCase(useCaseBaseWidth, mouse.X, mouse.Y, width, height, name);

            // Draw actor and set as selected
            useCase.Draw(pictureBoxGraphics, Font, true);
            selectedIndex = useCases.Count;
            selectedType = typeof(UseCase);

            // Add actor to list
            useCases.Add(useCase);
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
                if(selectedType == typeof(Actor))
                {
                    actors.RemoveAt(selectedIndex);
                }
                else if (selectedType == typeof(UseCase))
                {
                    useCases.RemoveAt(selectedIndex);
                }
                else if (true)
                {

                }
            }
            selectedIndex = -1;
            selectedType = null;
            Redraw();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (pictureBoxGraphics != null)
            {
                // Create new graphics object due to new sizes (they don't update)
                pictureBoxGraphics = useCaseDiagramPictureBox.CreateGraphics();
                Redraw();
            }
        }
    }
}
