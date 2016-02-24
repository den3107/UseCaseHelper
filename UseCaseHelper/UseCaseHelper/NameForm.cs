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
    public partial class NameForm : Form
    {
        public NameForm()
        {
            InitializeComponent();
        }

        private void actorNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void actorNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceptButton.PerformClick();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }
    }
}
