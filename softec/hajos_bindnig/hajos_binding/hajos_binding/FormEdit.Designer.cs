namespace hajos_binding
{
    partial class FormEdit
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
            components = new System.ComponentModel.Container();
            buttonClose = new Button();
            textBox1 = new TextBox();
            vizsgaKérdésBindingSource = new BindingSource(components);
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)vizsgaKérdésBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.DialogResult = DialogResult.OK;
            buttonClose.Location = new Point(1393, 690);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(131, 40);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "&Ok";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "Kerdes", true));
            textBox1.Location = new Point(31, 128);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1494, 110);
            textBox1.TabIndex = 2;
            // 
            // vizsgaKérdésBindingSource
            // 
            vizsgaKérdésBindingSource.DataSource = typeof(VizsgaKérdés);
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "V1", true));
            textBox2.Location = new Point(31, 290);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(735, 110);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "V2", true));
            textBox3.Location = new Point(790, 290);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(735, 110);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "V3", true));
            textBox4.Location = new Point(31, 459);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(735, 110);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "HelyesValasz", true));
            textBox5.Location = new Point(37, 621);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(175, 35);
            textBox5.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 95);
            label1.Name = "label1";
            label1.Size = new Size(161, 30);
            label1.TabIndex = 7;
            label1.Text = "Kérdés szövege:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 257);
            label2.Name = "label2";
            label2.Size = new Size(91, 30);
            label2.TabIndex = 8;
            label2.Text = "1. válasz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(790, 257);
            label3.Name = "label3";
            label3.Size = new Size(91, 30);
            label3.TabIndex = 9;
            label3.Text = "2. válasz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 426);
            label4.Name = "label4";
            label4.Size = new Size(91, 30);
            label4.TabIndex = 10;
            label4.Text = "3. válasz";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 588);
            label5.Name = "label5";
            label5.Size = new Size(141, 30);
            label5.TabIndex = 11;
            label5.Text = "Helyes válasz:";
            // 
            // textBox6
            // 
            textBox6.DataBindings.Add(new Binding("Text", vizsgaKérdésBindingSource, "Szam", true));
            textBox6.Location = new Point(31, 45);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(181, 35);
            textBox6.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 12);
            label6.Name = "label6";
            label6.Size = new Size(96, 30);
            label6.TabIndex = 13;
            label6.Text = "Sorszám:";
            // 
            // FormEdit
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1550, 761);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormEdit";
            Text = "Új kérdés rögzítése";
            Load += FormAddNew_Load;
            ((System.ComponentModel.ISupportInitialize)vizsgaKérdésBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private BindingSource vizsgaKérdésBindingSource;
    }
}