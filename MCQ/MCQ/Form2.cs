using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCQ
{
    public partial class Form2 : Form
    {
        public static Form2 obj = new Form2(); bool dialoug = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Left = (this.Width / 2) - (label1.Width / 2); 
            label2.Left = (this.Width / 2) - (label2.Width / 2);
            button1.Left = (this.Width / 2) - (button1.Width / 2);
            this.Visible = false; this.Icon = SystemIcons.Asterisk;
        }

        public static bool msg(string text)
        {
            obj. label2.Hide();
            obj.label1.Text = text;
            obj.ShowDialog();
            return obj.dialoug;
        }
        public static bool msg(string text, string caption)
        {
            obj.label2.Hide();
            obj.label1.Text = text;
            obj.Text = caption;
            obj.ShowDialog(); return obj.dialoug;
        }
        public static bool msg(string text, string caption, Color textcolor)
        {
            obj.label2.Hide();
            obj.label1.Text = text;
            obj.label1.ForeColor = textcolor;
            obj.Text = caption;
            obj.ShowDialog(); return obj.dialoug;
        }
        public static bool msg(string text, Color textcolor)
        {
            obj.label2.Hide();
            obj.label1.Text = text;
            obj.label1.ForeColor = textcolor;
            obj.ShowDialog(); return obj.dialoug;
        }
        public static bool msg(string text,string text2, Color textcolor,Color textcolor2)
        {
            obj.label2.Show();
            obj.label1.Text = text;
            obj.label1.ForeColor = textcolor;
            obj.label2.Text = text2;
            obj.label2.ForeColor = textcolor2;
            obj.ShowDialog(); return obj.dialoug;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); dialoug = false;
        }
    }
}
