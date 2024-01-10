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
    class wordleFunctions
    {
        gameArea gameArea = new gameArea();
        public static string GetRandomWord (List<string> wordList)
        {
            Random newWord = new Random();
            int index = newWord.Next(wordList.Count);
            string random = wordList[index].ToUpper();
            return random;
        }

        public static char[] stringToArray (string word)
        {
            char[] wordArray = new char[word.Length];
            wordArray = word.ToCharArray();
            return wordArray;
        }

        public static bool CheckInput (string input)
        {
            if (input.Length == 5) return true;
            else return false;
        }
    }
}
