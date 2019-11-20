using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookworm_Adventures
{
    public partial class Form1 : Form
    {
        //Variables and stuff
        string[] words = System.IO.File.ReadAllLines(@"C:\Users\jaxdr\Desktop\Master\BookWormAdventures\Bookworm Adventures\bin\Debug\wordness.txt");
        string[] upletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] rndletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "QU" };
        string[] lowletters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        double[] weights = new double[] { 1, 1.25, 1.25, 1, 1, 1.25, 1, 1.25, 1, 1.75, 1.75, 1, 1.25, 1, 1, 1.25, 1.75, 1, 1, 1, 1, 1.5, 1.5, 2, 1.5, 2 };
        List<string> wordList = new List<string>();
        public Button[] buttons = new Button[17];
        public Random random = new Random();
        public int rnd, turn = 1;
        public string currentLetter;
        public double p1Health = 20, p2Health = 20, wordWeight = 0, attackStrength;
        public bool[] used = new bool[17];
        public string word;
        public bool attackButtonOnOff = false;
        public Form1()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting up things
            reloadWords();
            label1.Text = p1Health.ToString();
            label2.Text = p2Health.ToString();
            attackWord.Text = "";
            for (int i = 1; i <= 16; i++)
            {
                used[i] = true;
            }
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
            buttons[5] = button5;
            buttons[6] = button6;
            buttons[7] = button7;
            buttons[8] = button8;
            buttons[9] = button9;
            buttons[10] = button10;
            buttons[11] = button11;
            buttons[12] = button12;
            buttons[13] = button13;
            buttons[14] = button14;
            buttons[15] = button15;
            buttons[16] = button16;

            Letter_Gen();
        }
        public void reloadWords()
        {

            List<string> words = System.IO.File.ReadAllLines(@"C:\Users\jaxdr\Desktop\Master\BookWormAdventures\Bookworm Adventures\bin\Debug\wordness.txt").ToList();
            wordList.Clear();
            for (int i = 0; i < words.Count(); i++)
            {
                wordList.Add(words[i]);




            }
        }
        private void Letter_Gen()
        {//Generate letters only for tiles used last turn
            for (int i = 1; i <= 16; i++)
            {
                if (used[i] == true)
                {
                    rnd = random.Next(0, 26);
                    buttons[i].Text = rndletters[rnd];


                }



            }




            wordReset();
        }

        private void wordReset()
        {
            //Resets the word, used very often
            attackWord.Text = "";
            for (int i = 1; i <= 16; i++)
            {
                used[i] = false;
            }
            wordWeight = 0;
            attackButtonOff();
        }

        private void attackButtonOff()
        {
            //Sets the attack button to off
            attackButton.BackColor = Color.Maroon;
            attackButton.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Letter tile 1
            if (used[1] != true)
            {
                attackWord.Text = attackWord.Text + button1.Text;
                used[1] = true;
                wordUpdate();
            }
        }

        private void wordUpdate()
        {
            //Check for a real word
            word = attackWord.Text;
            word = word.ToLower();
            for (int i = 0; i < wordList.Count; i++)
            {
                if (word != wordList[i])
                {
                    attackButtonOff();
                    attackButtonOnOff = false;
                }
                if (word == wordList[i] )
                {
                    if (word.Length > 2)
                    {
                        attackButtonOn();
                        attackButtonOnOff = true;
                        for (int k = 0; k < word.Length; k++)
                        {
                            currentLetter = word.Substring(k, 1);
                            for (int frick = 0; frick < upletters.Length; frick++)
                            {
                                if (currentLetter == upletters[frick] || currentLetter == lowletters[frick])
                                {
                                    wordWeight = wordWeight + weights[frick];
                                    i = 7656119;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void addGemAmethyst()
        {
            //Add amethyst gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Purple;
        }

        private void attackButtonOn()
        {
            //Switch the attack button to on
            wordWeight = 0;
            attackButtonOnOff = false;
            attackButton.BackColor = Color.Lime;
            attackButton.ForeColor = Color.Black;
        }

        private void scramble_Click(object sender, EventArgs e)
        {
            //Change all letters and change the turn
            for (int i = 1; i <= 16; i++)
            {
                used[i] = true;
            }
            Letter_Gen();
            if (turn == 1)
            {
                turn = 2;
            }
            else if (turn == 2)
            {
                turn = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Letter tile 2
            if (used[2] != true)
            {
                attackWord.Text = attackWord.Text + button2.Text;
                used[2] = true;
                wordUpdate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Letter tile 3
            if (used[3] != true)
            {
                attackWord.Text = attackWord.Text + button3.Text;
                used[3] = true;
                wordUpdate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Letter tile 4
            if (used[4] != true)
            {
                attackWord.Text = attackWord.Text + button4.Text;
                used[4] = true;
                wordUpdate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Letter tile 5
            if (used[5] != true)
            {
                attackWord.Text = attackWord.Text + button5.Text;
                used[5] = true;
                wordUpdate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Letter tile 6
            if (used[6] != true)
            {
                attackWord.Text = attackWord.Text + button6.Text;
                used[6] = true;
                wordUpdate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Letter tile 7
            if (used[7] != true)
            {
                attackWord.Text = attackWord.Text + button7.Text;
                used[7] = true;
                wordUpdate();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Letter tile 8
            if (used[8] != true)
            {
                attackWord.Text = attackWord.Text + button8.Text;
                used[8] = true;
                wordUpdate();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Letter tile 9
            if (used[9] != true)
            {
                attackWord.Text = attackWord.Text + button9.Text;
                used[9] = true;
                wordUpdate();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Letter tile 10
            if (used[10] != true)
            {
                attackWord.Text = attackWord.Text + button10.Text;
                used[10] = true;
                wordUpdate();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Letter tile 11
            if (used[11] != true)
            {
                attackWord.Text = attackWord.Text + button11.Text;
                used[11] = true;
                wordUpdate();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Letter tile 12
            if (used[12] != true)
            {
                attackWord.Text = attackWord.Text + button12.Text;
                used[12] = true;
                wordUpdate();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Letter tile 13
            if (used[13] != true)
            {
                attackWord.Text = attackWord.Text + button13.Text;
                used[13] = true;
                wordUpdate();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Letter tile 14
            if (used[14] != true)
            {
                attackWord.Text = attackWord.Text + button14.Text;
                used[14] = true;
                wordUpdate();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Letter tile 15
            if (used[15] != true)
            {
                attackWord.Text = attackWord.Text + button15.Text;
                used[15] = true;
                wordUpdate();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Letter tile 16
            if (used[16] != true)
            {
                attackWord.Text = attackWord.Text + button16.Text;
                used[16] = true;
                wordUpdate();
            }
        }

        private void resetWord_Click(object sender, EventArgs e)
        {
            //Literally just resets the word
            wordReset();
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            //Check if the word is valid and the attack button is on
            if (attackButtonOnOff == true)
            {
                attackStrength = wordWeight;
               
                if (attackStrength > 0)
                {
                   for(int i = 0; i <= 16; i++)
                    {    //Amethyst calculations
                        if (used[i] && buttons[i].BackColor == Color.Purple) {
                            attackStrength = attackStrength * 1.15;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Emerald Calculations
                        if (used[i] && buttons[i].BackColor == Color.Lime) {
                            attackStrength = attackStrength * 1.20;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Sapphire Calculations
                        if(used[i] && buttons[i].BackColor == Color.Blue)
                        {
                            attackStrength = attackStrength * 1.25;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Garnet Calculations
                        if(used[i] && buttons[i].BackColor == Color.Orange)
                        {
                            attackStrength = attackStrength * 1.30;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Ruby Calculations
                        if (used[i] && buttons[i].BackColor == Color.Red)
                        {
                            attackStrength = attackStrength * 1.35;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Crystal Calculations
                        if (used[i] && buttons[i].BackColor == Color.Pink)
                        {
                            attackStrength = attackStrength * 1.50;
                            buttons[i].BackColor = Color.Transparent;
                        }
                        //Diamond Calculations
                        if (used[i] && buttons[i].BackColor == Color.Cyan)
                        {
                            attackStrength = attackStrength * 2;
                            buttons[i].BackColor = Color.Transparent;
                        }


                    }
                }
                //Gem addition
                if (attackStrength > 0)
                {
                    if (word.Length == 5)
                    {
                        addGemAmethyst();
                    }
                    if (word.Length == 6)
                    {
                        addGemEmerald();
                    }
                    if (word.Length == 7)
                    {
                        addGemSaphire();
                    }
                    if (word.Length == 8)
                    {
                        addGemGarnet();
                    }
                    if (word.Length == 9)
                    {
                        addGemRuby();
                    }
                    if (word.Length == 10)
                    {
                        addGemCrystal();
                    }
                    if (word.Length >= 11)
                    {
                        addGemDiamond();
                    }
                }
                //Actual damage dealing
                if (turn == 1)
                {
                    p2Health = p2Health - attackStrength;
                    label2.Text = p2Health.ToString();
                    turn = 2;
                }
                else if (turn == 2)
                {
                    p1Health = p1Health - attackStrength;
                    label1.Text = p1Health.ToString();
                    turn = 1;
                }
                Letter_Gen();
            }
        }

        private void addGemDiamond()
        {
            //Add diamond gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Cyan;
        }

        private void addGemCrystal()
        {
            //Add crystal gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Pink;
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                for (int i = 0; i < wordList.Count(); i++)
                {

                    if (toolStripTextBox1.Text == wordList[i])
                    {
                        wordList.RemoveAt(i);
                        System.IO.File.WriteAllLines(@"C:\Users\jaxdr\Desktop\Master\BookWormAdventures\Bookworm Adventures\bin\Debug\wordness.txt", wordList);
                        reloadWords();
                        wordUpdate();
                        toolStripTextBox1.Clear();


                    }
                }
            }
        }

        private void reloadWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadWords();
        }

        private void addGemRuby()
        {
            //Add ruby gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Red;
        }

        private void addGemGarnet()
        {
            //Add garnet gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Orange;
        }

        private void addGemSaphire()
        {
            //Add saphire gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Blue;
        }

        private void addGemEmerald()
        {
            //Add emerald gem to a random tile
            rnd = random.Next(1, 17);
            buttons[rnd].BackColor = Color.Lime;
        }
    }
}
