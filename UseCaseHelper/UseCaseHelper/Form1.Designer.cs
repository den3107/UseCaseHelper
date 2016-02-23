namespace UseCaseHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lineRadioButton = new System.Windows.Forms.RadioButton();
            this.useCaseRadioButton = new System.Windows.Forms.RadioButton();
            this.actorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectRadioButton = new System.Windows.Forms.RadioButton();
            this.createRadioButton = new System.Windows.Forms.RadioButton();
            this.useCaseDiagramPictureBox = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useCaseDiagramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lineRadioButton);
            this.groupBox1.Controls.Add(this.useCaseRadioButton);
            this.groupBox1.Controls.Add(this.actorRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elements";
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.AutoSize = true;
            this.lineRadioButton.Location = new System.Drawing.Point(7, 78);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(56, 21);
            this.lineRadioButton.TabIndex = 2;
            this.lineRadioButton.TabStop = true;
            this.lineRadioButton.Text = "Line";
            this.lineRadioButton.UseVisualStyleBackColor = true;
            // 
            // useCaseRadioButton
            // 
            this.useCaseRadioButton.AutoSize = true;
            this.useCaseRadioButton.Location = new System.Drawing.Point(7, 50);
            this.useCaseRadioButton.Name = "useCaseRadioButton";
            this.useCaseRadioButton.Size = new System.Drawing.Size(88, 21);
            this.useCaseRadioButton.TabIndex = 1;
            this.useCaseRadioButton.TabStop = true;
            this.useCaseRadioButton.Text = "Use case";
            this.useCaseRadioButton.UseVisualStyleBackColor = true;
            // 
            // actorRadioButton
            // 
            this.actorRadioButton.AutoSize = true;
            this.actorRadioButton.Checked = true;
            this.actorRadioButton.Location = new System.Drawing.Point(7, 22);
            this.actorRadioButton.Name = "actorRadioButton";
            this.actorRadioButton.Size = new System.Drawing.Size(62, 21);
            this.actorRadioButton.TabIndex = 0;
            this.actorRadioButton.TabStop = true;
            this.actorRadioButton.Text = "Actor";
            this.actorRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectRadioButton);
            this.groupBox2.Controls.Add(this.createRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(126, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modes";
            // 
            // selectRadioButton
            // 
            this.selectRadioButton.AutoSize = true;
            this.selectRadioButton.Location = new System.Drawing.Point(7, 50);
            this.selectRadioButton.Name = "selectRadioButton";
            this.selectRadioButton.Size = new System.Drawing.Size(68, 21);
            this.selectRadioButton.TabIndex = 1;
            this.selectRadioButton.TabStop = true;
            this.selectRadioButton.Text = "Select";
            this.selectRadioButton.UseVisualStyleBackColor = true;
            // 
            // createRadioButton
            // 
            this.createRadioButton.AutoSize = true;
            this.createRadioButton.Checked = true;
            this.createRadioButton.Location = new System.Drawing.Point(7, 22);
            this.createRadioButton.Name = "createRadioButton";
            this.createRadioButton.Size = new System.Drawing.Size(71, 21);
            this.createRadioButton.TabIndex = 0;
            this.createRadioButton.TabStop = true;
            this.createRadioButton.Text = "Create";
            this.createRadioButton.UseVisualStyleBackColor = true;
            // 
            // useCaseDiagramPictureBox
            // 
            this.useCaseDiagramPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useCaseDiagramPictureBox.BackColor = System.Drawing.Color.White;
            this.useCaseDiagramPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.useCaseDiagramPictureBox.Location = new System.Drawing.Point(20, 151);
            this.useCaseDiagramPictureBox.Name = "useCaseDiagramPictureBox";
            this.useCaseDiagramPictureBox.Size = new System.Drawing.Size(863, 358);
            this.useCaseDiagramPictureBox.TabIndex = 2;
            this.useCaseDiagramPictureBox.TabStop = false;
            this.useCaseDiagramPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.useCaseDiagramPictureBox_MouseUp);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(779, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(97, 35);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear all";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(779, 53);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(97, 35);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 521);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.useCaseDiagramPictureBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "Use Case Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useCaseDiagramPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton lineRadioButton;
        private System.Windows.Forms.RadioButton useCaseRadioButton;
        private System.Windows.Forms.RadioButton actorRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton selectRadioButton;
        private System.Windows.Forms.RadioButton createRadioButton;
        private System.Windows.Forms.PictureBox useCaseDiagramPictureBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button removeButton;
    }
}

