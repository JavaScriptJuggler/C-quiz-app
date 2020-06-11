using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace MCQ
{
    public partial class Form1 : Form
    {
        int minute = 0, second = 0, wrong = 0, right = 0, notatt = 50, scroll = -1, index, j = -1; bool show=true;
        OleDbConnection con; OleDbDataAdapter adpt; DataSet ds; bool changer;
        Form2 obj = new Form2(); int[] array = new int[100]; List<Button> buttons; int[] qbutton = new int[100];
       public void buttoncontrol(int choice)
        {
            Control[] co = new Control[] { button1, button2, button3, button6, button5, button10, button9, button8, button7, button4, button15, button14, button13, button12, button11, button20, button19, button18, button17, button16, button25, button24, button23, button22, button21, button30, button29, button28, button27, button26, button35, button34, button33, button32, button31, button40, button39, button38, button37, button36, button45, button44, button43, button42, button41, button50, button49, button48, button47, button46 };
          
           int n = choice,i=0;
            if (n == 1)
            {
                foreach (Control c in co)
                {
                    i++;
                    c.Text = Convert.ToString(i);
                }
            }
            else if (n == 2)
            {
                if (scroll <= co.Length - 1)
                {
                    co[scroll].Select();
                    if (co[scroll] is Button)
                    {
                        Button b = co[scroll] as Button; b.FlatAppearance.BorderColor = Color.Red;
                    }
                }
                else
                {
                    Form2.msg("End of Question !!!","You'r in review mode", Color.Red, Color.Black);
                    scroll = co.Length - 1;
                }
            }
            else if (n == 3)
            {
                    if (co[scroll] is Button)
                    {
                            Button b = co[scroll] as Button;
                            Button b1 = co[co.Length-1] as Button;
                            b.FlatAppearance.BorderColor = Color.Red;
                            b1.FlatAppearance.BorderColor = Color.Black;
                    }
            }
            else if (n == 6)
            {
                if (co[scroll] is Button)
                {
                    Button b2 = co[scroll] as Button;
                    b2.BackColor = Color.Green;
                }
            }
            else if (n == 5)
            {

                buttons = new[] { button1, button2, button3, button6, button5, button10, button9, button8, button7, button4, button15, button14, button13, button12, button11, button20, button19, button18, button17, button16, button25, button24, button23, button22, button21, button30, button29, button28, button27, button26, button35, button34, button33, button32, button31, button40, button39, button38, button37, button36, button45, button44, button43, button42, button41, button50, button49, button48, button47, button46 }.ToList();
                buttons.ForEach(x => x.Click += myeventhandeler);
            }
        }
       public void myeventhandeler(object sender,EventArgs e)
       {
           index = Convert.ToInt16(null);
           Button button = sender as Button;
           index = buttons.IndexOf(button);
           textBox1.Text = Convert.ToString(ds.Tables[0].Rows[index][1]);
           radioButton1.Text = Convert.ToString(ds.Tables[0].Rows[index][2]);
           radioButton2.Text = Convert.ToString(ds.Tables[0].Rows[index][3]);
           radioButton3.Text = Convert.ToString(ds.Tables[0].Rows[index][4]);
           radioButton4.Text = Convert.ToString(ds.Tables[0].Rows[index][5]); scroll = index; answers(scroll);
       }
        public void fetchdata(int n)
        {
            foreach (Control co in new Control[] { radioButton1, radioButton2, radioButton3, radioButton4 })
            {
                if (co is RadioButton)
                {
                    RadioButton rb = co as RadioButton; rb.Checked = false;
                }
            }
            if (n < ds.Tables[0].Rows.Count)
            {
                textBox1.Text = Convert.ToString(ds.Tables[0].Rows[n][1]);
                radioButton1.Text = Convert.ToString(ds.Tables[0].Rows[n][2]);
                radioButton2.Text = Convert.ToString(ds.Tables[0].Rows[n][3]);
                radioButton3.Text = Convert.ToString(ds.Tables[0].Rows[n][4]);
                radioButton4.Text = Convert.ToString(ds.Tables[0].Rows[n][5]);
            }
        }
        public void fetchdata1(int n)
        {
            foreach (Control co in new Control[] { radioButton1, radioButton2, radioButton3, radioButton4 })
            {
                if (co is RadioButton)
                {
                    RadioButton rb = co as RadioButton; rb.Checked = false;
                }
            }
            if (n >= 0)
            {
                textBox1.Text = Convert.ToString(ds.Tables[0].Rows[n][1]);
                radioButton1.Text = Convert.ToString(ds.Tables[0].Rows[n][2]);
                radioButton2.Text = Convert.ToString(ds.Tables[0].Rows[n][3]);
                radioButton3.Text = Convert.ToString(ds.Tables[0].Rows[n][4]);
                radioButton4.Text = Convert.ToString(ds.Tables[0].Rows[n][5]); answers(scroll);
            }
            else
                scroll = 0;
        }
        public void answers(int n)
        {
            if (array[n] != Convert.ToInt16(null))
            {
                if (array[n] == 1)
                    radioButton1.Checked = true;
                else if (array[n] == 2)
                    radioButton2.Checked = true;
                else if (array[n] == 3)
                    radioButton3.Checked = true;
                else if (array[n] == 4)
                    radioButton4.Checked = true;
            }
            else
            {
                foreach (Control co in new Control[] { radioButton1, radioButton2, radioButton3, radioButton4 })
                {
                    if (co is RadioButton)
                    {
                        RadioButton rb = co as RadioButton; rb.Checked = false;
                    }
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            con = new OleDbConnection("PROVIDER=MICROSOFT.JET.OLEDB.4.0;DATA SOURCE=DATABASE1.MDB"); con.Open();
            adpt = new OleDbDataAdapter("select * from table1 order by RND(INT(NOW*ID)-NOW*ID)", con);
            ds = new DataSet();
            adpt.Fill(ds);
            buttoncontrol(4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Dock = DockStyle.None;
            label2.Top = (panel4.Height / 2) - (label2.Height / 2);
            label2.Left=(panel4.Width/2)-(label2.Width/2);
            label3.Top = (panel1.Height / 2) - (label3.Height / 2);
            label3.Left = (panel1.Width / 2) - (label3.Width / 2);

            scroll++; fetchdata(scroll); buttoncontrol(1); timer1.Enabled = true; timer1.Interval = 1000;
            timer6.Enabled = true; timer6.Interval = 200;
            buttoncontrol(2); buttoncontrol(5);
        }

        int i = -1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] array = new string[] {"1","2","3","Let's Start" };
            if (show == true)
            {
                if (i < array.Length - 1)
                {
                    i++;
                    label2.Text = array[i];
                }
                else
                {
                    show = false;
                    panel4.Visible = false;
                    label2.Visible = false;
                }

            }





            else
            {

                second++;
                if (second == 60)
                {
                    if (minute != 19)
                    { minute++; second = 0; }
                    else
                    {
                        second = 0; timer1.Stop();
                        bool b = Form2.msg("Time Ends !!!", "Warning", Color.Red);
                        if (b == false)
                        { this.Close(); }

                    }
                }
                label4.Text = "Time Elapsed : " + Convert.ToString(minute) + " : " + Convert.ToString(second);
                label5.Text = "Date : " + DateTime.Now.ToString("dd" + "/" + "MMM" + "/" + "yyyy");
            }
        }
         
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (radioButton1.Text == Convert.ToString(ds.Tables[0].Rows[scroll][6]))
                {
                    right++;
                    radioButton1.BackColor = Color.Green;
                    array[scroll] = 1;
                }
                else
                {
                    wrong++;
                    radioButton1.BackColor = Color.Red;
                    array[scroll] = 1;
                }
                buttoncontrol(6);
            }
            else
                radioButton1.BackColor = Color.Transparent;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (radioButton2.Text == Convert.ToString(ds.Tables[0].Rows[scroll][6]))
                {
                    right++;
                    radioButton2.BackColor = Color.Green;
                   array[scroll] = 2;
                }
                else
                {
                   wrong++;
                   radioButton2.BackColor = Color.Red;
                  array[scroll] = 2;
                }
                buttoncontrol(6);
            }
            else
                radioButton2.BackColor = Color.Transparent;
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                if (radioButton4.Text == Convert.ToString(ds.Tables[0].Rows[scroll][6]))
                {
                    right++;
                    radioButton4.BackColor = Color.Green;
                    array[scroll] = 4;
                }
                else
                {
                   wrong++;
                   radioButton4.BackColor = Color.Red;
                   array[scroll] = 4;
                }
                buttoncontrol(6);
            }
            else
                radioButton4.BackColor = Color.Transparent;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                if (radioButton3.Text == Convert.ToString(ds.Tables[0].Rows[scroll][6]))
                {
                    right++;
                    radioButton3.BackColor = Color.Green;
                    array[scroll] = 3;
                }
                else
                {
                   wrong++;
                   radioButton3.BackColor = Color.Red;
                   array[scroll] = 3;
                } 
                buttoncontrol(6);
            }
            else
                radioButton3.BackColor = Color.Transparent;
        }
        private void button51_Click(object sender, EventArgs e)
        {
            normal();
            Button[] co = new Button[] { button1, button2, button3, button6, button5, button10, button9, button8, button7, button4, button15, button14, button13, button12, button11, button20, button19, button18, button17, button16, button25, button24, button23, button22, button21, button30, button29, button28, button27, button26, button35, button34, button33, button32, button31, button40, button39, button38, button37, button36, button45, button44, button43, button42, button41, button50, button49, button48, button47, button46 };
            scroll++; notatt--;
            fetchdata(scroll); buttoncontrol(2); buttoncontrol(3);
            answers(scroll);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            normal();
            scroll--; fetchdata1(scroll); buttoncontrol(2); buttoncontrol(3); answers(scroll);
        }
        private void button53_Click(object sender, EventArgs e)
        {
           bool b= Form2.msg("Your Score","Out of 50: "+Convert.ToString(right), Color.Red, Color.Black);
           if (b == false)
               this.Close();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                con.Close();
                string path = fbd.FileName;
                char[] split=new char[]{'.'};
                string[] filename = fbd.SafeFileName.Split(split);
                if (filename[filename.Length - 1] == "mdb")
                {
                    File.Delete("Database1.mdb");
                    File.Move(Path.GetDirectoryName(path) + "\\" + fbd.SafeFileName, "Database1.mdb");
                    Application.Restart();
                }
                else
                {
                    Form2.msg("Invalid File Format !!!", "Error");
                }
                
            }
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            j++;
            string[] name = new string[] { "D", "e", "v", "e", "l", "o", "p", "e", "d", " ", "B", "y", ":", " ", "S", "o", "u", "m", "y", "a", " ", "M", "a", "n", "n", "a" };
            if (j <= (name.Length - 1))
                label1.Text = label1.Text + name[j];
            else
            {
                j = -1; label1.Text = "";
            }
        }

        public void normal()
        {
            radioButton1.BackColor = Color.Transparent;
            radioButton2.BackColor = Color.Transparent;
            radioButton3.BackColor = Color.Transparent; 
            radioButton4.BackColor = Color.Transparent;
        }
    }
}
