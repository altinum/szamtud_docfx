namespace WinFormsApp1
{
    partial class TermekKategoriaForm
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
            treeViewKategoriak = new TreeView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            törlésToolStripMenuItem = new ToolStripMenuItem();
            átnevezésToolStripMenuItem = new ToolStripMenuItem();
            frissítésToolStripMenuItem = new ToolStripMenuItem();
            újFőkategóriaToolStripMenuItem = new ToolStripMenuItem();
            újAlkategóriaToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewTermekek = new DataGridView();
            exportXMLToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTermekek).BeginInit();
            SuspendLayout();
            // 
            // treeViewKategoriak
            // 
            treeViewKategoriak.ContextMenuStrip = contextMenuStrip1;
            treeViewKategoriak.LabelEdit = true;
            treeViewKategoriak.Location = new Point(26, 33);
            treeViewKategoriak.Name = "treeViewKategoriak";
            treeViewKategoriak.Size = new Size(337, 722);
            treeViewKategoriak.TabIndex = 0;
            treeViewKategoriak.AfterLabelEdit += treeViewKategoriak_AfterLabelEdit;
            treeViewKategoriak.AfterSelect += treeViewKategoriak_AfterSelect;
            treeViewKategoriak.MouseDown += treeViewKategoriak_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(28, 28);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { törlésToolStripMenuItem, átnevezésToolStripMenuItem, frissítésToolStripMenuItem, újFőkategóriaToolStripMenuItem, újAlkategóriaToolStripMenuItem, exportXMLToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(271, 258);
            // 
            // törlésToolStripMenuItem
            // 
            törlésToolStripMenuItem.Name = "törlésToolStripMenuItem";
            törlésToolStripMenuItem.Size = new Size(270, 36);
            törlésToolStripMenuItem.Text = "Törlés";
            törlésToolStripMenuItem.Click += törlésToolStripMenuItem_Click;
            // 
            // átnevezésToolStripMenuItem
            // 
            átnevezésToolStripMenuItem.Name = "átnevezésToolStripMenuItem";
            átnevezésToolStripMenuItem.Size = new Size(270, 36);
            átnevezésToolStripMenuItem.Text = "Átnevezés";
            átnevezésToolStripMenuItem.Click += átnevezésToolStripMenuItem_Click;
            // 
            // frissítésToolStripMenuItem
            // 
            frissítésToolStripMenuItem.Name = "frissítésToolStripMenuItem";
            frissítésToolStripMenuItem.Size = new Size(270, 36);
            frissítésToolStripMenuItem.Text = "Frissítés";
            frissítésToolStripMenuItem.Click += frissítésToolStripMenuItem_Click;
            // 
            // újFőkategóriaToolStripMenuItem
            // 
            újFőkategóriaToolStripMenuItem.Name = "újFőkategóriaToolStripMenuItem";
            újFőkategóriaToolStripMenuItem.Size = new Size(270, 36);
            újFőkategóriaToolStripMenuItem.Text = "Új főkategória";
            újFőkategóriaToolStripMenuItem.Click += újFőkategóriaToolStripMenuItem_Click;
            // 
            // újAlkategóriaToolStripMenuItem
            // 
            újAlkategóriaToolStripMenuItem.Name = "újAlkategóriaToolStripMenuItem";
            újAlkategóriaToolStripMenuItem.Size = new Size(270, 36);
            újAlkategóriaToolStripMenuItem.Text = "Új alkategória";
            újAlkategóriaToolStripMenuItem.Click += újAlkategóriaToolStripMenuItem_Click;
            // 
            // dataGridViewTermekek
            // 
            dataGridViewTermekek.AllowUserToAddRows = false;
            dataGridViewTermekek.AllowUserToDeleteRows = false;
            dataGridViewTermekek.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTermekek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTermekek.Location = new Point(380, 38);
            dataGridViewTermekek.Name = "dataGridViewTermekek";
            dataGridViewTermekek.ReadOnly = true;
            dataGridViewTermekek.RowHeadersWidth = 72;
            dataGridViewTermekek.Size = new Size(586, 718);
            dataGridViewTermekek.TabIndex = 1;
            // 
            // exportXMLToolStripMenuItem
            // 
            exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            exportXMLToolStripMenuItem.Size = new Size(270, 36);
            exportXMLToolStripMenuItem.Text = "Export XML";
            exportXMLToolStripMenuItem.Click += exportXMLToolStripMenuItem_Click;
            // 
            // TermekKategoriaForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 790);
            Controls.Add(dataGridViewTermekek);
            Controls.Add(treeViewKategoriak);
            Name = "TermekKategoriaForm";
            Text = "TermekKategoriaForm";
            Load += TermekKategoriaForm_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTermekek).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeViewKategoriak;
        private DataGridView dataGridViewTermekek;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem átnevezésToolStripMenuItem;
        private ToolStripMenuItem törlésToolStripMenuItem;
        private ToolStripMenuItem újKategóriaMelléToolStripMenuItem;
        private ToolStripMenuItem újKategóriaAláToolStripMenuItem;
        private ToolStripMenuItem frissítésToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem újFőkategóriaToolStripMenuItem;
        private ToolStripMenuItem újAlkategóriaToolStripMenuItem;
        private ToolStripMenuItem exportXMLToolStripMenuItem;
    }
}