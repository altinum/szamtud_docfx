using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsApp1
{
    public partial class TermekKategoriaForm : Form
    {
        RendelesDbContext _context = new RendelesDbContext();
        public TermekKategoriaForm()
        {
            InitializeComponent();

        }

private void CreateXML()
{
    var kategoriak = (from k in _context.TermekKategoria select k).ToList();

    var fokategoriak = from k in kategoriak where k.SzuloKategoriaId == null select k;

    XDocument xdoc = new XDocument();

    XDeclaration xdecl = new XDeclaration("1.0", "utf-8", "yes");
    xdoc.Declaration = xdecl;

    XElement root = new XElement("Kategoriak");
    xdoc.Add(root);

    foreach (var fokategoria in fokategoriak)
    {
        XElement fokategoriaNode = CreateXElement(fokategoria, kategoriak);
        root.Add(fokategoriaNode);
    }

    MessageBox.Show(xdoc.ToString());
    xdoc.Save("kategoriak.xml");
}

XElement CreateXElement(TermekKategoria kategoria, List<TermekKategoria> kategoriak)
{
    XElement node = new XElement("Kategoria");
    //Igy is lehet
    node.SetAttributeValue("KategoriaId", kategoria.KategoriaId);
            
    //Meg így is
    XAttribute nameAttribute = new XAttribute("Nev", kategoria.Nev);
    node.Add(nameAttribute);

    var gyerekek = from k in kategoriak where k.SzuloKategoriaId == kategoria.KategoriaId select k;
    foreach (var gyerek in gyerekek)
    {
        node.Add(CreateXElement(gyerek, kategoriak));
    }
    return node;
}

        private void TermekKategoriaForm_Load(object sender, EventArgs e)
        {
            var kategoriak = (from k in _context.TermekKategoria select k).ToList();

            var fokategoriak = from k in kategoriak where k.SzuloKategoriaId == null select k;

            treeViewKategoriak.Nodes.Clear();

            foreach (var fokategoria in fokategoriak)
            {
                TreeNode fokategoriaNode = CreateTreeNode(fokategoria, kategoriak);
                treeViewKategoriak.Nodes.Add(fokategoriaNode);
            }
        }

        TreeNode CreateTreeNode(TermekKategoria kategoria, List<TermekKategoria> kategoriak)
        {
            TreeNode node = new TreeNode(kategoria.Nev);
            node.Tag = kategoria;

            var gyerekek = from k in kategoriak where k.SzuloKategoriaId == kategoria.KategoriaId select k;
            foreach (var gyerek in gyerekek)
            {
                node.Nodes.Add(CreateTreeNode(gyerek, kategoriak));
            }
            return node;
        }

        private void treeViewKategoriak_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                var kiválasztottTrmekKategoria = (TermekKategoria)e.Node.Tag;

                var termekek = from t in _context.Termek where t.KategoriaId == kiválasztottTrmekKategoria.KategoriaId select t;

                dataGridViewTermekek.DataSource = termekek.ToList();


            }
        }

        private void treeViewKategoriak_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                var kategoria = (TermekKategoria)e.Node.Tag;
                kategoria.Nev = e.Label;
                _context.SaveChanges();
            }
        }

        private void átnevezésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewKategoriak.SelectedNode.BeginEdit();
        }

        private void újKategóriaMelléToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TermekKategoria kategoria = new TermekKategoria();
            kategoria.Nev = "Új kategória";
            kategoria.SzuloKategoriaId = ((TermekKategoria)treeViewKategoriak.SelectedNode.Tag).SzuloKategoriaId;

            _context.TermekKategoria.Add(kategoria);
            _context.SaveChanges();


            TreeNode treeNode = new TreeNode(kategoria.Nev);
            treeNode.Tag = kategoria;
            treeViewKategoriak.SelectedNode.Nodes.Add(treeNode);

            treeViewKategoriak.SelectedNode = treeNode;
        }


        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _context.TermekKategoria.Remove((TermekKategoria)treeViewKategoriak.SelectedNode.Tag);
            _context.SaveChanges();

            if (treeViewKategoriak.SelectedNode.Parent == null)
            {
                treeViewKategoriak.Nodes.Remove(treeViewKategoriak.SelectedNode);
            }
            else
            {
                treeViewKategoriak.SelectedNode.Parent.Nodes.Remove(treeViewKategoriak.SelectedNode);
            }
        }

        private void újFőkategóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TermekKategoria kategoria = new TermekKategoria();
            kategoria.Nev = "Új kategória";
            kategoria.SzuloKategoriaId = null;

            _context.TermekKategoria.Add(kategoria);
            _context.SaveChanges();

            TreeNode treeNode = new TreeNode(kategoria.Nev);
            treeNode.Tag = kategoria;
            treeViewKategoriak.Nodes.Add(treeNode);

            treeViewKategoriak.SelectedNode = treeNode;

        }

        private void újAlkategóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TermekKategoria kategoria = new TermekKategoria();
            kategoria.Nev = "Új kategória";
            kategoria.SzuloKategoriaId = ((TermekKategoria)treeViewKategoriak.SelectedNode.Tag).KategoriaId;

            _context.TermekKategoria.Add(kategoria);
            _context.SaveChanges();

            TreeNode treeNode = new TreeNode(kategoria.Nev);
            treeNode.Tag = kategoria;
            treeViewKategoriak.SelectedNode.Nodes.Add(treeNode);

            treeViewKategoriak.SelectedNode = treeNode;
        }

        private void treeViewKategoriak_MouseDown(object sender, MouseEventArgs e)
        {
            // Step 1: Check if the right mouse button is clicked
            if (e.Button == MouseButtons.Right)
            {
                // Step 2: Get the node at the mouse position
                TreeNode clickedNode = treeViewKategoriak.GetNodeAt(e.X, e.Y);

                if (clickedNode != null)
                {
                    // Step 3: Select the node under the cursor
                    treeViewKategoriak.SelectedNode = clickedNode;

                    // Step 4: Show the context menu at the mouse position
                    contextMenuStrip1.Show(treeViewKategoriak, e.Location);
                }
            }
        }

        private void frissítésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TermekKategoriaForm_Load(null, null);
        }

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateXML();
        }
    }
}
