/**
猜单词
*/
using System;
namespace EnglishLearningSoftware
{
    internal class Guess
    {
        Dictionary d1;
        char[] word;//从字典中读出的单词
        char[] gword;//用*替代的单词
        char a = '*';
        char inputKey;
        public Guess() {
            d1 = new Dictionary();
            for (int num = 0; num < d1.dictionary.Count; num++)
            {
                initializeWord(num);
                while (!hitIt(gword))
                {
                    inputKey = Convert.ToChar(Console.ReadLine());
                    for (int num1 = 0; num1 <= word.Length - 1; num1++)
                    {
                        if (word[num1] == inputKey)
                            gword[num1] = inputKey;
                    }
                    Console.WriteLine(gword);
                }
            }
        }

        //初始化被猜的单词
        private void initializeWord(int num) {
            word = d1.dictionary[num].Spell.ToCharArray();
            gword = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                gword[i] = a;
            }
            Console.WriteLine(gword);
        }
        private bool hitIt(char[] gword) {
            bool it = false;
            for (int num = 0; num <= gword.Length - 1; num++)
            {
                if (gword[num] == '*')
                    break;
                if (num == gword.Length - 1)
                    it = true;
            }

            return it;
        }
    }
}