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

namespace Wordle
{
    public partial class gameArea : Form
    {
        StreamReader textFile = new StreamReader(@"5-letter-words.txt");
        public static List<string> wordList;
        public static char[] randChar, guessChar;
        public string rand, guess;
        int remainingGuess = 6;
        int lineCount;

        public gameArea()
        {
            InitializeComponent();
            wordList = new List<string>();
            lineCount = File.ReadAllLines(@"5-letter-words.txt").Length;
            for (int i=0;i<lineCount;i++)
            {
                wordList.Add(textFile.ReadLine());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            helpWordle helpWordle = new helpWordle();
            helpWordle.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        public void btnEnter_Click(object sender, EventArgs e)
        {
            List<string> wordListUpper = new List<string>();
            randChar = wordleFunctions.stringToArray(rand);

            foreach (string word in wordList) wordListUpper.Add(word.ToUpper());

            
            if (remainingGuess == 6)
            {
                guess = cell00.Text + cell01.Text + cell02.Text + cell03.Text + cell04.Text;

                DisableTextBox(cell00, cell01, cell02, cell03, cell04);
            }
            else if (remainingGuess == 5)
            {
                guess = cell10.Text + cell11.Text + cell12.Text + cell13.Text + cell14.Text;

                DisableTextBox(cell10, cell11, cell12, cell13, cell14);
            }
            else if (remainingGuess == 4)
            {
                guess = cell20.Text + cell21.Text + cell22.Text + cell23.Text + cell24.Text;

                DisableTextBox(cell20, cell21, cell22, cell23, cell24);
            }
            else if (remainingGuess == 3)
            {
                guess = cell30.Text + cell31.Text + cell32.Text + cell33.Text + cell34.Text;

                DisableTextBox(cell30, cell31, cell32, cell33, cell34);
            }
            else if (remainingGuess == 2)
            {
                guess = cell40.Text + cell41.Text + cell42.Text + cell43.Text + cell44.Text;

                DisableTextBox(cell40, cell41, cell42, cell43, cell44);

            }
            else if (remainingGuess == 1)
            {
                guess = cell50.Text + cell51.Text + cell52.Text + cell53.Text + cell54.Text;

                DisableTextBox(cell50, cell51, cell52, cell53, cell54);
            }

            bool isInList = SearchWord(guess, wordListUpper);

            if (isInList == true)
            {
                guessChar = wordleFunctions.stringToArray(guess);

                if (remainingGuess == 6)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell00, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell00, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell00, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell01, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell01, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell01, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell02, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell02, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell02, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell03, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell03, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell03, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell04, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell04, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell04, guessChar[4]);

                    EnableTextBox(cell10, cell11, cell12, cell13, cell14);
                    cell10.Focus();

                    remainingGuess--;

                    CheckAns(cell00, cell01, cell02, cell03, cell04);
                }
                else if (remainingGuess == 5)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell10, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell10, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell10, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell11, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell11, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell11, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell12, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell12, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell12, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell13, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell13, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell13, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell14, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell14, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell14, guessChar[4]);

                    EnableTextBox(cell20, cell21, cell22, cell23, cell24);
                    cell20.Focus();

                    remainingGuess--;

                    CheckAns(cell10, cell11, cell12, cell13, cell14);
                }
                else if (remainingGuess == 4)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell20, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell20, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell20, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell21, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell21, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell21, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell22, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell22, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell22, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell23, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell23, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell23, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell24, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell24, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell24, guessChar[4]);

                    EnableTextBox(cell30, cell31, cell32, cell33, cell34);
                    cell30.Focus();

                    remainingGuess--;
                    CheckAns(cell20, cell21, cell22, cell23, cell24);
                }
                else if (remainingGuess == 3)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell30, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell30, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell30, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell31, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell31, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell31, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell32, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell32, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell32, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell33, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell33, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell33, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell34, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell34, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell34, guessChar[4]);

                    EnableTextBox(cell40, cell41, cell42, cell43, cell44);
                    cell40.Focus();

                    remainingGuess--;
                    CheckAns(cell30, cell31, cell32, cell33, cell34);
                }
                else if (remainingGuess == 2)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell40, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell40, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell40, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell41, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell41, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell41, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell42, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell42, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell42, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell43, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell43, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell43, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell44, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell44, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell44, guessChar[4]);

                    EnableTextBox(cell50, cell51, cell52, cell53, cell54);

                    cell50.Focus();

                    remainingGuess--;
                    CheckAns(cell40, cell41, cell42, cell43, cell44);
                }
                else if (remainingGuess == 1)
                {
                    if (randChar[0] == guessChar[0]) GreenBackColor(cell50, guessChar[0]);
                    else if (rand.Contains(guessChar[0])) YellowBackColor(cell50, guessChar[0]);
                    else if (randChar[0] != guessChar[0]) GrayBackColor(cell50, guessChar[0]);

                    if (randChar[1] == guessChar[1]) GreenBackColor(cell51, guessChar[1]);
                    else if (rand.Contains(guessChar[1])) YellowBackColor(cell51, guessChar[1]);
                    else if (randChar[1] != guessChar[1]) GrayBackColor(cell51, guessChar[1]);

                    if (randChar[2] == guessChar[2]) GreenBackColor(cell52, guessChar[2]);
                    else if (rand.Contains(guessChar[2])) YellowBackColor(cell52, guessChar[2]);
                    else if (randChar[2] != guessChar[2]) GrayBackColor(cell52, guessChar[2]);

                    if (randChar[3] == guessChar[3]) GreenBackColor(cell53, guessChar[3]);
                    else if (rand.Contains(guessChar[3])) YellowBackColor(cell53, guessChar[3]);
                    else if (randChar[3] != guessChar[3]) GrayBackColor(cell53, guessChar[3]);

                    if (randChar[4] == guessChar[4]) GreenBackColor(cell54, guessChar[4]);
                    else if (rand.Contains(guessChar[4])) YellowBackColor(cell54, guessChar[4]);
                    else if (randChar[4] != guessChar[4]) GrayBackColor(cell54, guessChar[4]);

                    remainingGuess--;

                    CheckAns(cell50, cell51, cell52, cell53, cell54);
                }
            }
            else
            {
                ClearTextBox(remainingGuess);

                cell04.Focus();
                cell03.Focus();
                cell02.Focus();
                cell01.Focus();
                cell00.Focus();
            }
        }
        public void gameReset()
        {
            rand = wordleFunctions.GetRandomWord(wordList);

            EnableTextBox(cell00, cell01, cell02, cell03, cell04);

            DisableTextBox(cell10, cell11, cell12, cell13, cell14);
            DisableTextBox(cell20, cell21, cell22, cell23, cell24);
            DisableTextBox(cell30, cell31, cell32, cell33, cell34);
            DisableTextBox(cell40, cell41, cell42, cell43, cell44);
            DisableTextBox(cell50, cell51, cell52, cell53, cell54);

        }
        public void gameArea_Load(object sender, EventArgs e)
        {
            rand = wordleFunctions.GetRandomWord(wordList);
            remainingGuess = 6;

            EnableTextBox(cell00, cell01, cell02, cell03, cell04);

            cell00.Focus();
        }

        public void CheckAns(TextBox cell1, TextBox cell2, TextBox cell3, TextBox cell4, TextBox cell5)
        {
            if (cell1.BackColor == Color.FromArgb(124, 176, 109) && cell2.BackColor == Color.FromArgb(124, 176, 109) && cell3.BackColor == Color.FromArgb(124, 176, 109) && cell4.BackColor == Color.FromArgb(124, 176, 109) && cell5.BackColor == Color.FromArgb(124, 176, 109))
            {
                WinningMess();
                DisableTextBox(cell00, cell01, cell02, cell03, cell04);
                DisableTextBox(cell10, cell11, cell12, cell13, cell14);
                DisableTextBox(cell20, cell21, cell22, cell23, cell24);
                DisableTextBox(cell30, cell31, cell32, cell33, cell34);
                DisableTextBox(cell40, cell41, cell42, cell43, cell44);
                DisableTextBox(cell50, cell51, cell52, cell53, cell54);
                btnEnter.Enabled = false;

                btnReset.Enabled = true;
            }
            else if (remainingGuess == 0)
            {
                MessageBox.Show(string.Format("Game Over! \nThe word is {0}. \nTry again.", rand.ToUpper()));
                btnEnter.Enabled = false;
                btnReset.Enabled = true;
            }
            else return;
        }

        public void WinningMess()
        {
            MessageBox.Show("You got the word. Congratulations!");
        }

        public void GreenBackColor(TextBox txtCell, char letter)
        {
            txtCell.BackColor = Color.FromArgb(124, 176, 109);
            txtCell.Text = letter.ToString();
        }

        public void YellowBackColor(TextBox txtCell, char letter)
        {
            txtCell.BackColor = Color.FromArgb(241, 235, 156);
            txtCell.Text = letter.ToString();
        }

        public void GrayBackColor(TextBox txtCell, char letter)
        {
            txtCell.BackColor = Color.FromArgb(154, 162, 151);
            txtCell.Text = letter.ToString();
        }

        public void ClearTextBox(int guessNum)
        {
            if (guessNum == 6)
            {
                ClearTextBox(cell00, cell01, cell02, cell03, cell04);

                EnableTextBox(cell00, cell01, cell02, cell03, cell04);

                cell00.Focus();
            }
            else if (guessNum == 5)
            {
                ClearTextBox(cell10, cell11, cell12, cell13, cell14);

                EnableTextBox(cell10, cell11, cell12, cell13, cell14);

                cell10.Focus();
            }
            else if (guessNum == 4)
            {
                ClearTextBox(cell20, cell21, cell22, cell23, cell24); 
                EnableTextBox(cell20, cell21, cell22, cell23, cell24);

                cell20.Focus();
            }
            else if (guessNum == 3)
            {
                ClearTextBox(cell30, cell31, cell32, cell33, cell34);
                EnableTextBox(cell30, cell31, cell32, cell33, cell34);

                cell30.Focus();
            }
            else if (guessNum == 2)
            {
                ClearTextBox(cell40, cell41, cell42, cell43, cell44);
                EnableTextBox(cell40, cell41, cell42, cell43, cell44);

                cell40.Focus();
            }
            else if (guessNum == 1)
            {
                ClearTextBox(cell50, cell51, cell52, cell53, cell54);
                EnableTextBox(cell50, cell51, cell52, cell53, cell54);

                cell50.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTextBox(cell00, cell01, cell02, cell03, cell04);
            ClearTextBox(cell10, cell11, cell12, cell13, cell14);
            ClearTextBox(cell20, cell21, cell22, cell23, cell24);
            ClearTextBox(cell30, cell31, cell32, cell33, cell34);
            ClearTextBox(cell40, cell41, cell42, cell43, cell44);
            ClearTextBox(cell50, cell51, cell52, cell53, cell54);
            ChangeOrigBackColor(cell00, cell01, cell02, cell03, cell04);
            ChangeOrigBackColor(cell10, cell11, cell12, cell13, cell14);
            ChangeOrigBackColor(cell20, cell21, cell22, cell23, cell24);
            ChangeOrigBackColor(cell30, cell31, cell32, cell33, cell34);
            ChangeOrigBackColor(cell40, cell41, cell42, cell43, cell44);
            ChangeOrigBackColor(cell50, cell51, cell52, cell53, cell54);
            btnEnter.Enabled = true;
            btnReset.Enabled = false;
            gameArea_Load(sender, e);
        }

        public static bool SearchWord(string input, List<string> wordList)
        {
            if (wordList.Contains(input))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Word not in the list.");
                return false;
            }
        }

        public void ChangeOrigBackColor(TextBox cell1, TextBox cell2, TextBox cell3, TextBox cell4, TextBox cell5)
        {
            cell1.BackColor = Color.WhiteSmoke;
            cell2.BackColor = Color.WhiteSmoke;
            cell3.BackColor = Color.WhiteSmoke;
            cell4.BackColor = Color.WhiteSmoke;
            cell5.BackColor = Color.WhiteSmoke;
        }

        public void ClearTextBox(TextBox cell1, TextBox cell2, TextBox cell3, TextBox cell4, TextBox cell5)
        {
            cell1.Clear();
            cell2.Clear();
            cell3.Clear();
            cell4.Clear();
            cell5.Clear();
        }

        public void EnableTextBox(TextBox cell1, TextBox cell2, TextBox cell3, TextBox cell4, TextBox cell5)
        {
            cell1.Enabled = true;
            cell2.Enabled = true;
            cell3.Enabled = true;
            cell4.Enabled = true;
            cell5.Enabled = true;
        }

        public void DisableTextBox(TextBox cell1, TextBox cell2, TextBox cell3, TextBox cell4, TextBox cell5)
        {
            cell1.Enabled = false;
            cell2.Enabled = false;
            cell3.Enabled = false;
            cell4.Enabled = false;
            cell5.Enabled = false;
        }

        public void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
