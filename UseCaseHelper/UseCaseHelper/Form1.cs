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
        // Base values
        readonly int actorBaseWidth = 25;
        readonly int actorBaseHeight = 75;
        readonly int useCaseBaseWidth = 50;
        readonly int useCaseBaseHeight = 25;
        readonly int lineBaseWidth = 10;
        readonly int lineBaseHeight = 10;

        // Selection indications
        int selectedIndex;
        Type selectedType;

        // Object lsts
        List<Actor> actors;
        List<UseCase> useCases;
        List<Line> lines;

        // Line selection objects
        Actor lineSelectionActor;
        UseCase lineSelectionUseCase;

        // Graphics object
        Graphics pictureBoxGraphics;

        public Form1()
        {
            InitializeComponent();

            selectedIndex = -1;
            selectedType = null;
            actors = new List<Actor>();
            useCases = new List<UseCase>();
            lines = new List<Line>();
            lineSelectionActor = null;
            lineSelectionUseCase = null;
            pictureBoxGraphics = useCaseDiagramPictureBox.CreateGraphics();
            pictureBoxGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pictureBoxGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
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
                    using (NameForm dialog = new NameForm("actor"))
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
                    using (NameForm dialog = new NameForm("use case"))
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
                    for (int i = 0; i < actors.Count; i++)
                    {
                        Actor actor = actors[i];

                        // Check if mouse is within bound of actor
                        if (e.Location.X >= actor.x && e.Location.X <= actor.x + actor.width && e.Location.Y >= actor.y && e.Location.Y <= actor.y + actor.height)
                        {
                            // Check if there was already a use case selected (connection made)
                            if (lineSelectionUseCase != null)
                            {
                                lineSelectionActor = actor;
                                CreateLine();
                            }
                            else
                            {
                                // Check if there was previously another actor selected
                                if (lineSelectionActor != null)
                                {
                                    // Redraw that actor, only unselected
                                    lineSelectionActor.Draw(pictureBoxGraphics, Font, false);
                                }

                                // Set selected actor
                                lineSelectionActor = actor;

                                // Redraw selected actor, only selected
                                actor.Draw(pictureBoxGraphics, Font, true);
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < useCases.Count; i++)
                    {
                        UseCase useCase = useCases[i];

                        // Check if mouse is within bound of use case
                        if (e.Location.X >= useCase.x && e.Location.X <= useCase.x + useCase.width && e.Location.Y >= useCase.y && e.Location.Y <= useCase.y + useCase.height)
                        {
                            // Check if there was already an actor selected (connection made)
                            if (lineSelectionActor != null)
                            {
                                lineSelectionUseCase = useCase;
                                CreateLine();
                            }
                            else
                            {
                                // Check if there was previously another use case selected
                                if (lineSelectionUseCase != null)
                                {
                                    // Redraw that use case, only unselected
                                    lineSelectionUseCase.Draw(pictureBoxGraphics, Font, false);
                                }

                                // Set selected use case
                                lineSelectionUseCase = useCase;

                                // Redraw selected use case, only selected
                                useCase.Draw(pictureBoxGraphics, Font, true);
                                return;
                            }
                        }
                    }

                    // Nothing selected, reset selection
                    lineSelectionActor = null;
                    lineSelectionUseCase = null;
                }
            }
            else // Select mode
            {
                for (int i = 0; i < actors.Count; i++)
                {
                    Actor actor = actors[i];

                    // Check if mouse is within bound of actor
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

                    // Check if mouse is within bound of use case
                    if (e.Location.X >= useCase.x && e.Location.X <= useCase.x + useCase.width && e.Location.Y >= useCase.y && e.Location.Y <= useCase.y + useCase.height)
                    {
                        // Redraw selected use case
                        useCase.Draw(pictureBoxGraphics, Font, true);
                        selectedIndex = i;
                        selectedType = typeof(UseCase);
                        return;
                    }
                }
                for (int i = 0; i < lines.Count; i++)
                {
                    Line line = lines[i];

                    // Check if mouse is within bound of line
                    if (e.Location.X >= line.xSelectionBox && e.Location.X <= line.xSelectionBox + line.widthSelectionBox && e.Location.Y >= line.ySelectionBox && e.Location.Y <= line.ySelectionBox + line.heightSelectionBox)
                    {
                        // Redraw selected line
                        line.Draw(pictureBoxGraphics, Font, true);
                        selectedIndex = i;
                        selectedType = typeof(Line);
                        return;
                    }
                }
            }
        }

        private void Redraw()
        {
            pictureBoxGraphics.Clear(Color.White);
            // Always draw lines first, then the rest so they overlap the line
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Draw(pictureBoxGraphics, Font, (i == selectedIndex && selectedType == typeof(Line) ? true : false));
            }
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

        private void CreateLine()
        {
            // Get selectionbox position
            int x = ((lineSelectionActor.x + lineSelectionActor.width / 2) + (lineSelectionUseCase.x + lineSelectionUseCase.width / 2)) / 2 - lineBaseWidth / 2;
            int y = ((lineSelectionActor.y + lineSelectionActor.height / 2) + (lineSelectionUseCase.y + lineSelectionUseCase.height / 2)) / 2 - lineBaseHeight / 2;

            // Create line
            Line line = new Line(x, y, lineBaseWidth, lineBaseHeight, lineSelectionActor, lineSelectionUseCase);

            // Set selection
            selectedIndex = lines.Count;
            selectedType = typeof(Line);

            // Draw line
            line.Draw(pictureBoxGraphics, Font, true);

            // Add to list
            lines.Add(line);

            // Set line selection to nothing
            lineSelectionActor = null;
            lineSelectionUseCase = null;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Basically just clear everything
            pictureBoxGraphics.Clear(Color.White);
            actors = new List<Actor>();
            useCases = new List<UseCase>();
            lines = new List<Line>();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if(selectedIndex >= 0)
            {
                if(selectedType == typeof(Actor))
                {
                    // Check if connected to line and delete line if it is
                    Line line = GetConnectedLine(actors[selectedIndex]);
                    if(line != null)
                    {
                        lines.Remove(line);
                    }
                    actors.RemoveAt(selectedIndex);
                }
                else if (selectedType == typeof(UseCase))
                {
                    // Check if connected to line and delete line if it is
                    Line line = GetConnectedLine(useCases[selectedIndex]);
                    if (line != null)
                    {
                        lines.Remove(line);
                    }
                    useCases.RemoveAt(selectedIndex);
                }
                else if (selectedType == typeof(Line))
                {
                    lines.RemoveAt(selectedIndex);
                }
            }
            selectedIndex = -1;
            selectedType = null;
            Redraw();
        }

        private Line GetConnectedLine(Actor actor)
        {
            foreach(Line line in lines)
            {
                if(line.actor == actor)
                {
                    return line;
                }
            }
            return null;
        }

        private Line GetConnectedLine(UseCase useCase)
        {
            foreach (Line line in lines)
            {
                if (line.useCase == useCase)
                {
                    return line;
                }
            }
            return null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (pictureBoxGraphics != null)
            {
                // Create new graphics object due to new sizes (they don't update)
                pictureBoxGraphics = useCaseDiagramPictureBox.CreateGraphics();
                pictureBoxGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pictureBoxGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                Redraw();
            }
        }
        
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            // Reset all selections and redraw
            selectedIndex = -1;
            selectedType = null;
            lineSelectionActor = null;
            lineSelectionUseCase = null;
            Redraw();

            // Check if select radiobutton is now selected
            if((RadioButton) sender == selectRadioButton)
            {
                // Deactivate the element radiobuttons as you shouldn't be able to use them now
                actorRadioButton.Enabled = false;
                useCaseRadioButton.Enabled = false;
                lineRadioButton.Enabled = false;
            }
            else
            {
                // Active them
                actorRadioButton.Enabled = true;
                useCaseRadioButton.Enabled = true;
                lineRadioButton.Enabled = true;
            }
        }
    }
}
