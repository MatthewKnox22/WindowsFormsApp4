using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        //dictionaries
        private Dictionary<string, int> teamsamndWinnings = new Dictionary<string, int>();
        private Dictionary<int, string> yearsandWinners = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void form1_Load(object sender, EventArgs e)
        {
            InitializeTeamsAndWinnings();
            InitializeYearsAndWinners();
        }
        private void InitialteteamsandWinnings()
        {
            try
            {
                StreamReader infile = File.OpenText("WorldSeriesWinners.txt");

                while (infile.EndOfStream) ;
                {
                    string line = infile.ReadLine();

                    if (teamsamndWinnings.ContainsKey(line))
                    {
                        teamsamndWinnings[line]++;
                    }
                    else
                    {
                        if (line != "(NO GAME)")
                        {
                            teamsamndWinnings[line] = 1;
                        }
                    }
                    infile.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        private void InitalizeYearsAndWinners()
            {
                int year = 1903;
                try
                {
                    StreamReader infile = File.OpenText("WorldSeriesWinners.txt");
                }
                while (File.EndOfStream) ;
                {
                    string line = File.ReadLine();
                    yearsandWinners[year] = line;
                    year++;
                }
                File.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnWinner_Click(object sender, EventArgs e)
        {
            int year;
            textBox2.Text = "";
            textBox3.Text = "";

            if (int.TryParse(textBox2.Text, out year))
            {
                textBox2.Text = yearsandWinners[year];

                if (teamsamndWinnings.ContainsKey(textBox2.Text))
                {
                    textBox3.Text = teamsamndWinnings[textBox2.Text].ToString();
                }
                    if (teamsamndWinnings.ContainsKey(textBox2.Text))
                    {
                        textBox3.Text = teamsamndWinnings[textBox2.Text].ToString();
                    }
            }
            else
            {
                MessageBox.Show("Enter a valid year in the range 1903-2009.");
            }
            else
            {
                MessageBox.Show("Enter a valid year in the range of 1903-2009.");
            }
        }
    }
}