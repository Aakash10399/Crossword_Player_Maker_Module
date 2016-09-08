using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crossword_Module
{
    public partial class Form1 : Form
    {
        public static string MCwordvar;
        public static string MCwordinfo;
        public static string[] words;
        public static string[] words_info;
        public static string[] words_rep;
        public static int errors = 0;
        public Form1()
        {
            InitializeComponent();
            AutoScroll = true;
            
            /* TextBox[] txtTeamNames = new TextBox[10];
            for (int i = 0; i < txtTeamNames.Length; i++)
            {
                var txt = new TextBox();
                txtTeamNames[i] = txt;
                txt.Name = "A";
                txt.Text = "A";
                txt.Location = new Point(1,0+(i*30));
                txt.Visible = true;
                txt.Height = 25;
                txt.Width = 25;
                txt.Font = new Font(txt.Font.FontFamily, 20);
                this.Controls.Add(txt);
            }
              */

            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Public\\words.txt");
            int c = 0; string line;
            while ((line = file.ReadLine()) != null)
            {
                c++;
            }
            file.Close();
            words = new string[c];
            words_info = new string[c];
            c = 0;
            System.IO.StreamReader file1 = new System.IO.StreamReader("C:\\Users\\Public\\words.txt");
            while ((line = file1.ReadLine()) != null)
            {
                words[c] = line;
                c++;
            }
            c = 0;
            System.IO.StreamReader file2 = new System.IO.StreamReader("C:\\Users\\Public\\words_info.txt");
            while ((line = file2.ReadLine()) != null)
            {
                words_info[c] = line;
                c++;
            }
            MCwordfunc();
            
            
            words = words.Where(w => w != MCwordvar).ToArray();
            words_info = words_info.Where(w => w != MCwordinfo).ToArray();
            words_rep = words.ToArray();
            
            pTbox();
            Lover();
            info();
            
                
            
        }
        
        
        public void MCwordfunc()
        {
            int cg = 0; int t = 0; int k = 0;
            for(int i=0;i<words.Length;i++)
            {
                t = 0; k = 0;
                for (int j = 0; j < words.Length; j++) {
                      foreach(char obj in words[j])
                      {
                          if(words[i].Contains(obj.ToString()))
                          {
                              t++; 
                          }
                      }

                }
                if(cg<(t+words[i].Length))
                {
                    cg = t + words[i].Length;
                    MCwordvar = words[i];
                    MCwordinfo = words_info[i];
                }
                


            }
            

        }

        public void pTbox()
        {
            int c = 0; int k = 0; bool flag = false; int z = 0;
            foreach(char obj in MCwordvar)
            {
                
                var txt = new TextBox();
                txt.Name = "T" + c.ToString();
                if (c == 0 || c == MCwordvar.Length - 1)
                {
                    txt.Text = obj.ToString();
                }
                txt.MaxLength = 1;
                txt.Location = new Point(300, 100 + (c * 30));
                txt.Visible = true;
                txt.Height = 25;
                txt.Width = 25;
                txt.Font = new Font(txt.Font.FontFamily, 20);
                this.Controls.Add(txt);
                c++;
            }
            for (k = 0; k < MCwordvar.Length; k++)
            {
                flag = false;
                for (int i = 0; i < words.Length; i++)
                {
                    c = 0;
                    foreach (char obj in words[i])
                    {
                        if (MCwordvar.Substring(k,1).Contains(obj.ToString()))
                        {
                            int m = 1;
                            if(k!=0 || k!=MCwordvar.Length-1)
                            {
                                Control ctn = this.Controls["T"+(k).ToString()];
                                ctn.Text = MCwordvar.Substring(k, 1);
                                
                            }
 
                            
                            for (z = c+1 ; z <(words[i].Length); z++)
                            {
                                var txt = new TextBox();
                                txt.Name = "B" + z.ToString() + k.ToString();
                                if (z == words[i].Length - 1) {
                                    txt.Text = words[i].Substring(z, 1);
                                }
                                txt.MaxLength = 1;
                                txt.Location = new Point(300 + (m * 30), 100 + (k * 30));
                                txt.Visible = true;
                                txt.Height = 25;
                                txt.Width = 25;
                                txt.Font = new Font(txt.Font.FontFamily, 20);
                                this.Controls.Add(txt);
                                flag = true;
                                m++;
                            } m = 1;
                            for (z = c-1; z >=0; z--)
                            {
                                var txt = new TextBox();
                                txt.Name = "B" + z.ToString() + k.ToString();
                                if (z == 0) {
                                    txt.Text = words[i].Substring(z, 1);
                                }
                                txt.MaxLength = 1;
                                txt.Location = new Point(300-(m*30), 100 + (k * 30));
                                txt.Visible = true;
                                txt.Height = 25;
                                txt.Width = 25;
                                txt.Font = new Font(txt.Font.FontFamily, 20);
                                this.Controls.Add(txt);
                                flag = true;
                                m++;
                            }
                            
                            words = words.Where(w => w != words[i]).ToArray();
                        }
                        if (flag == true)
                        { break; }

                        c++;
                    }
                    if (flag == true)
                    { break; }
                }
             }
            
        }
        public void Lover()
        {
            int z; int ty = MCwordvar.Length; int m = 1; int k = 1;
            for (int i = 0; i < words.Length; i++)
            {

                if (i % 2 == 0)
                {
                    for (z = 0; z < (words[i].Length); z++)
                    {
                        var txt = new TextBox();
                        txt.Name = "B" + z.ToString() + ty.ToString();
                        if (z == 0 || z == words[i].Length - 1)
                        {
                            txt.Text = words[i].Substring(z, 1);
                        }
                        txt.MaxLength = 1;
                        txt.Location = new Point(300 + ((z + 1) * 30), 100 + (ty * 30));
                        txt.Visible = true;
                        txt.Height = 25;
                        txt.Width = 25;
                        txt.Font = new Font(txt.Font.FontFamily, 20);
                        this.Controls.Add(txt);
                    }
                }
                if (i % 2 != 0)
                {
                    m = -1; k = 1;
                    for (z = words[i].Length - 1; z >= 0; z--)
                    {
                        var txt = new TextBox();
                        txt.Name = "B" + m.ToString() + ty.ToString();
                        if (z == 0 || z == words[i].Length - 1)
                        {
                            txt.Text = words[i].Substring(z, 1);
                        }
                        txt.MaxLength = 1;
                        txt.Location = new Point(300 - (k * 30), 100 + (ty * 30));
                        txt.Visible = true;
                        txt.Height = 25;
                        txt.Width = 25;
                        txt.Font = new Font(txt.Font.FontFamily, 20);
                        this.Controls.Add(txt);
                        m--; k++;
                    }
                    ty++;
                }

            }

        }

        public void pTboxc()
        {
            int c = 0; int k = 0; bool flag = false; int z = 0;
            foreach (char obj in MCwordvar)
            {

                
                Control ctn = this.Controls["T"+c.ToString()];
                if(ctn.Text.Equals(obj.ToString()))
                { }
                else { errors++;
                ctn.BackColor = Color.Red;
                }
                
                
                c++;
            }
            for (k = 0; k < MCwordvar.Length; k++)
            {
                flag = false;
                for (int i = 0; i < words_rep.Length; i++)
                {
                    c = 0;
                    foreach (char obj in words_rep[i])
                    {
                        if (MCwordvar.Substring(k, 1).Contains(obj.ToString()))
                        {
                            int m = 1;



                            for (z = c + 1; z < (words_rep[i].Length); z++)
                            {

                                Control ctn = this.Controls["B" + z.ToString() + k.ToString()];
                                if(ctn.Text.Equals(words_rep[i].Substring(z,1)))
                                { }
                                else { errors++; ctn.BackColor = Color.Red; }
                                
                                m++;
                            } m = 1;
                            for (z = c - 1; z >= 0; z--)
                            {
                                
                                
                                Control ctn = this.Controls["B" + z.ToString() + k.ToString()];
                                if(ctn.Text.Equals(words_rep[i].Substring(z,1)))
                                { }
                                else { errors++; ctn.BackColor = Color.Red; }
                                
                                m++;
                            }

                            words_rep = words_rep.Where(w => w != words_rep[i]).ToArray();
                        }
                        if (flag == true)
                        { break; }

                        c++;
                    }
                    if (flag == true)
                    { break; }
                }
            }

        }
        public void Loverc()
        {
            int z; int ty = MCwordvar.Length; int m = 1;
            for (int i = 0; i < words_rep.Length; i++)
            {

                if (i % 2 == 0)
                {
                    for (z = 0; z < (words_rep[i].Length); z++)
                    {
                        Control ctn = this.Controls["B" + z.ToString() + ty.ToString()];
                        if (ctn.Text.Equals(words_rep[i].Substring(z, 1)))
                        { }
                        else
                        {
                            errors++;
                            ctn.BackColor = Color.Red;
                        }
                    }
                }
                if (i % 2 != 0)
                {
                    m = -1;
                    for (z = words_rep[i].Length - 1; z >= 0; z--)
                    {

                        Control ctn = this.Controls["B" + m.ToString() + ty.ToString()];
                        if (ctn.Text.Equals(words_rep[i].Substring(z, 1)))
                        { }
                        else
                        {
                            errors++;
                            ctn.BackColor = Color.Red;
                        }
                        
                        
                        
                        m--;
                    }
                    ty++;
                }

            }

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            pTboxc();
            Loverc();

            if(errors==0)
            { textBox1.Text = "Perfect!"; errors = 0; }
            else
            {
                textBox1.Text = "Total Errors : " + errors.ToString(); errors = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void info()
        {
            var txt = new Label();
            txt.Text = "Tree :";
            txt.Location = new Point(0, 100);
            txt.Visible = true;
            txt.Font = new Font(txt.Font, FontStyle.Underline);
            this.Controls.Add(txt);
            var txt2 = new Label();
            txt2.Text = MCwordinfo;
            txt2.Location = new Point(0, 130);
            txt2.Visible = true;
            this.Controls.Add(txt2);
            var txt3 = new Label();
            txt3.Text = "Branches :";
            txt3.Location = new Point(0, 160);
            txt3.Visible = true;
            txt3.Font = new Font(txt3.Font, FontStyle.Underline);
            this.Controls.Add(txt3);
            for(int i=0;i<words_info.Length;i++)
            {

                var txt4 = new Label();
                txt4.Text = words_info[i];
                txt4.Location = new Point(0, 160 + (i + 1) * 30);
                txt4.Visible = true;
                this.Controls.Add(txt4);
            }
            
            
        }
        

        

        

        
        

        
        


        
       

    }
}
