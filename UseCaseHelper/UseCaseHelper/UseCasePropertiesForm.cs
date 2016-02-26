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
    public partial class UseCasePropertiesForm : Form
    {
        public UseCasePropertiesForm(UseCase useCase)
        {
            InitializeComponent();
            nameTextBox.Text = useCase.name;
            summaryTextBox.Text = useCase.summary;
            for (int i = 0; i < useCase.actors.Count; i++)
            {
                if (i < useCase.actors.Count - 1)
                {
                    actorsTextBox.Text += useCase.actors[i].name + ", ";
                }
                else
                {
                    actorsTextBox.Text += useCase.actors[i].name;
                }
            }
            assumptionTextBox.Text = useCase.assumption;
            descriptionTextBox.Text = useCase.description;
            exceptionTextBox.Text = useCase.exception;
            resultTextBox.Text = useCase.result;
        }
    }
}
