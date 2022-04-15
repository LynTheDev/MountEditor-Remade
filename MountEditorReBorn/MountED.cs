using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MountEditorReBorn
{
    public partial class MountED : Form
    {
        public MountED()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "#include<iostream>\n\nint main(void)\n{\n    std::cout<<\"Hello world!\";\n\nreturn 0;\n}";
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save your file as";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtout = new StreamWriter(saveFileDialog.FileName);
                txtout.Write(fastColoredTextBox1.Text);
                txtout.Close();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a new file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Clear();
                using (StreamReader str = new StreamReader(openFileDialog.FileName))
                {
                    fastColoredTextBox1.Text = str.ReadToEnd();
                    str.Close();
                }
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void UndoB_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void RedoB_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void SelectAllB_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoB.PerformClick();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RedoB.PerformClick();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton.PerformClick();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripButton.PerformClick();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton.PerformClick();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAllB.PerformClick();
        }

        private void cpp_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "#include<iostream>\n\nint main(void)\n{\n    std::cout<<\"Hello world!\";\n\nreturn 0;\n}";
        }

        private void csharp_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "using System;\n\nnamespace MountEditor\n{\n    class Program\n    {\n        static void Main(string[], args)\n        {\n           Console.Write(\"Hello World!\");\n        }\n    }\n}";
        }

        private void clang_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "#include<stdio.h>\n#include<stdlib.h>\n\nint main(void)\n{\n   printf(\"%s\\n\", \"Hello World!\");\n\nreturn EXIT_SUCCESS;\n}";
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //markers
            e.ChangedRange.SetFoldingMarkers("{", "}");
            //identifiers
            e.ChangedRange.SetStyle(idenStyle, "virtual");
            e.ChangedRange.SetStyle(idenStyle, "public");
            e.ChangedRange.SetStyle(idenStyle, "static");
            e.ChangedRange.SetStyle(idenStyle, "internal");
            e.ChangedRange.SetStyle(idenStyle, "extern");
            e.ChangedRange.SetStyle(idenStyle, "protected");
            //csharp
            e.ChangedRange.SetStyle(sharpStyle, "Write");
            e.ChangedRange.SetStyle(sharpStyle, "WriteLine");
            e.ChangedRange.SetStyle(conStyle, "Console.");
            e.ChangedRange.SetStyle(sharpStyle, "ReadLine");
            //inclusions, comments and miscs
            e.ChangedRange.SetStyle(QuoteStyle, "\".*?\"");
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(LGreenStyle, "namespace");
            e.ChangedRange.SetStyle(LGreenStyle, "class");
            e.ChangedRange.SetStyle(YellowStyle, @"#include<.*?>");
            e.ChangedRange.SetStyle(returnStyle, "return");
            e.ChangedRange.SetStyle(YellowStyle, "using");
            //if and switch and case and stuff
            e.ChangedRange.SetStyle(CaseStyle, "if");
            e.ChangedRange.SetStyle(CaseStyle, "else");
            e.ChangedRange.SetStyle(CaseStyle, "switch");
            e.ChangedRange.SetStyle(CaseStyle, "case");
            e.ChangedRange.SetStyle(CaseStyle, "break");
            e.ChangedRange.SetStyle(CaseStyle, "do");
            e.ChangedRange.SetStyle(CaseStyle, "try");
            e.ChangedRange.SetStyle(CaseStyle, "while");
            e.ChangedRange.SetStyle(CaseStyle, "for");
            e.ChangedRange.SetStyle(CaseStyle, "foreach");
            e.ChangedRange.SetStyle(CaseStyle, "struct");
            e.ChangedRange.SetStyle(CaseStyle, "sleep_");
            e.ChangedRange.SetStyle(CaseStyle, "Sleep");

            //declarations and shit
            e.ChangedRange.SetStyle(ErrorStyle, "printf");
            e.ChangedRange.SetStyle(declarationStyle, "int");
            e.ChangedRange.SetStyle(declarationStyle, "double");
            e.ChangedRange.SetStyle(declarationStyle, "float");
            e.ChangedRange.SetStyle(declarationStyle, "bool");
            e.ChangedRange.SetStyle(declarationStyle, "auto");
            e.ChangedRange.SetStyle(declarationStyle, "var");
            e.ChangedRange.SetStyle(declarationStyle, "char");
            e.ChangedRange.SetStyle(declarationStyle, "void");
            //namespaces, cout, cerr and stuff
            e.ChangedRange.SetStyle(LGreenStyle, ".*?::");
            e.ChangedRange.SetStyle(ErrorStyle, "cerr");
            //stuff
            e.ChangedRange.SetStyle(helpStyle, ">");
            e.ChangedRange.SetStyle(helpStyle, "<");
            e.ChangedRange.SetStyle(helpStyle, "$");
            e.ChangedRange.SetStyle(helpStyle, "&");
            e.ChangedRange.SetStyle(helpStyle, "=");
            //owo

        }

        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        Style ErrorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style LGreenStyle = new TextStyle(Brushes.LightGreen, null, FontStyle.Regular);
        Style YellowStyle = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        Style QuoteStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        Style CaseStyle = new TextStyle(Brushes.Thistle, null, FontStyle.Regular);
        Style returnStyle = new TextStyle(Brushes.LightCoral, null, FontStyle.Regular);
        Style declarationStyle = new TextStyle(Brushes.Pink, null, FontStyle.Regular);
        Style helpStyle = new TextStyle(Brushes.PaleVioletRed, null, FontStyle.Regular);
        Style idenStyle = new TextStyle(Brushes.LightSalmon, null, FontStyle.Regular);
        Style sharpStyle = new TextStyle(Brushes.LightGreen, null, FontStyle.Regular);
        Style conStyle = new TextStyle(Brushes.LightBlue, null, FontStyle.Regular);
    }
}
