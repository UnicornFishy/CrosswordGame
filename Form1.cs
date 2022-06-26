using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cross_Word_Puzzle_Game
{
    public partial class Form1 : Form
    {
        bool cluetxtbool = true; //bool to help load clues into the clue box
        public Form1()
        {
            InitializeComponent();
            changeTextBoxStatus(); // to create the black boxesa and work in the hint and check guess buttons
            
            // On form load this will load the clue into the clue text box
            //the first array is the hint array
            string[] clueStrs = new string[] { "Plumber that saves a princess", Environment.NewLine,
                                               "i put my pen __ the box", Environment.NewLine,
                                               "Another word for when a person is being saucy", Environment.NewLine,
                                               "Geography", Environment.NewLine, 
                                               "One of the Army of two brothers", Environment.NewLine,
                                               "__ cool __ ice", Environment.NewLine,
                                               "ye" 
                                              };
            //this foreach loop will put the array into the cluebox
            foreach (string clueStr in clueStrs)
            {
                if (cluetxtbool == true)
                {
                    clueTxtBox.Text += clueStr;
                }

            }
            // now the clues will be put into the clue box
        }

        
        private void clueTxtBox_TextChanged(object sender, EventArgs e)
        {
            //clue text box
        }


        private void checkGuessBttn_Click(object sender, EventArgs e)
        {
            //Array for the words to be checked against
            string[,] crossWordArray = new string[5, 5]
          {
                {"m","a","r","i","o"},
                {"a","x","i","n","x"},
                {"p","x","o","x","x"}, // this is here to help me code so i dont have to scroll up
                {"s","a","s","s","y"},
                {"x","s","x","x","e"},
          };
            //Array for the text cells to be checked against
            TextBox[,] textCells = new TextBox[5, 5] 
            { {txtCell00, txtCell01, txtCell02, txtCell03, txtCell04 },
              {txtCell10, txtCell11, txtCell12, txtCell13, txtCell14 },
              {txtCell20, txtCell22, txtCell22, txtCell23, txtCell24 }, // this is here to help me code so i dont have to scroll up
              {txtCell30, txtCell32, txtCell32, txtCell33, txtCell34 },
              {txtCell40, txtCell42, txtCell42, txtCell43, txtCell44 }
            };

            //nested for loops that check for whether or not the guesses are correct
            for (int i = 0; i < textCells.GetLength(0); i++)
            {
                for (int j = 0; j < textCells.GetLength(1); j++)
                {
                    if(textCells[i, j].Text == crossWordArray[i, j])
                    {
                        textCells[i, j].ForeColor = Color.Green;
                    }
                    else if(textCells[i, j].Text != crossWordArray[i, j] && crossWordArray [i,j] == "x")
                    {
                         textCells[i, j].BackColor = Color.Black;
                    }
                    else if (textCells[i, j].Text != crossWordArray[i, j])
                    {
                        textCells[i, j].ForeColor = Color.Red;
                    }
                };
            };
            changeTextBoxStatus();
            //Now you know what is right and wrong interms of the players answers

        }

        private void showHintBttn_Click(object sender, EventArgs e)
        {
            //so that it was easier for me to see the code I just repasted it here 
            string[,] crossWordArray = new string[5, 5]
          {
                {"m","a","r","i","o"},
                {"a","x","i","n","x"},
                {"p","x","o","x","x"}, // this is here to help me code so i dont have to scroll up
                {"s","a","s","s","y"},
                {"x","s","x","x","e"},
          };

            TextBox[,] textCells = new TextBox[5, 5]
            { {txtCell00, txtCell01, txtCell02, txtCell03, txtCell04 },
              {txtCell10, txtCell11, txtCell12, txtCell13, txtCell14 },
              {txtCell20, txtCell21, txtCell22, txtCell23, txtCell24 }, // this is here to help me code so i dont have to scroll up
              {txtCell30, txtCell31, txtCell32, txtCell33, txtCell34 },
              {txtCell40, txtCell41, txtCell42, txtCell43, txtCell44 }
            };
            
            //declarations for the show hint loop
            bool hintLoop = true;
            int x , y ;

            //the show hint loop that determines the hint that is shown
            while ( hintLoop == true)
            {
                Random xValue = new Random();
                x = xValue.Next(0, 5);
                Random yValue = new Random();
                y = yValue.Next(0, 5);

                if ( textCells [x , y].BackColor == Color.Black || textCells[x, y].ForeColor == Color.Green )
                {
                    hintLoop = true;
                }
                else
                {
                    textCells[x, y].Text = crossWordArray[x, y];
                    textCells[x, y].BackColor = Color.Black;
                    textCells[x, y].ForeColor = Color.White;
                    hintLoop = false; // will break out of the loop

                }
                
            }
            // after exiting the loop you know that it has found a cell that is not black and has not been fulled int
            changeTextBoxStatus();
        }

        private void extBttn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //so that the application exits
        }

        private void changeTextBoxStatus()
        {
            // to make a the fore and background change colours
            

            string[,] crossWordArray = new string[5, 5]
          {
                {"m","a","r","i","o"},
                {"a","x","i","n","x"},
                {"p","x","o","x","x"}, // this is here to help me code so i dont have to scroll up
                {"s","a","s","s","y"},
                {"x","s","x","x","e"},
          };

            TextBox[,] textCells = new TextBox[5, 5]
            { {txtCell00, txtCell01, txtCell02, txtCell03, txtCell04 },
              {txtCell10, txtCell11, txtCell12, txtCell13, txtCell14 },
              {txtCell20, txtCell21, txtCell22, txtCell23, txtCell24 }, // this is here to help me code so i dont have to scroll up
              {txtCell30, txtCell31, txtCell32, txtCell33, txtCell34 },
              {txtCell40, txtCell41, txtCell42, txtCell43, txtCell44 }
            };

            //this makes the back color to black on load
            for (int i = 0; i < textCells.GetLength(0); i++)
            {
                for (int j = 0; j < textCells.GetLength(1); j++)
                {
                    if (crossWordArray[i, j] == "x")
                    {
                        textCells[i, j].BackColor = Color.Black;
                    };
                };
            };
           


        }
    }

    

}

/*char strs[NUMBER_OF_STRINGS][STRING_LENGTH+1] ;
...
strcpy(strs[0], aString); // where aString is either an array or pointer to char
strcpy(strs[1], "foo");*/

//for (int i = 0; i < array2.Length; i++) //counter to keep track of how many chars the player has that are crrect
//{
//    if (array2[i] == array[i])
//    {
//        correctGuess++;
//    }
//}

//foreach (char c in array2) //counter to see how long the hidden word is
//{
//    hiddenWordAmount++;
//}
//hiddenWordStr = hiddenWordAmount.ToString(); //conv to string

//Mario, in, sassy, 
//Maps, Rios, in, as, ye

//for (int i = 0; i < textCells.GetLength(0); i++)
//{
//    for (int j = 0; j < textCells.GetLength(1); j++)
//    {
//        if (crossWordArray[i,j] != "x")
//        {
//            if (textCells[i, j].Text == "")
//            {
//                textCells[i, j].Text = crossWordArray[i, j];
//                textCells[i, j].BackColor = Color.Black;
//                textCells[i, j].ForeColor = Color.White;
//            };
//        };
//    };
//};

//for ( int i = 0; i < playerAnswerArray2.Length; i++)
//{
//    if (playerAnswerArray2[i, i] == crossWordArray[i, i]) ;
//}
