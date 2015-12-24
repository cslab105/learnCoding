/**
考试测验
*/
using System;

namespace EnglishLearningSoftware
{
    internal class Exam
    {
        int right, wrong;
        double Rpercentage, Wpercentage;
        //Dictionary d1;
        DictionaryFS d1;
        string input;
        Examlog el = new Examlog();

        public Exam()
        {
            right = 0;
            wrong = 0;
            Rpercentage = 0;
            Wpercentage = 0;
            //d1 = new Dictionary();
            d1 = new DictionaryFS();
            for (int i = 0; i < d1.dictionary.Count; i++)
            {
                Console.WriteLine(d1.dictionary[i].Meaning);
                input = Console.ReadLine();
                if (input == d1.dictionary[i].Spell)
                {
                    Console.WriteLine("答對了");
                    right++;
                    d1.dictionary.RemoveAt(i);
                    i--;
                }
                else
                {
                    Console.WriteLine("答錯了,是  " + d1.dictionary[i].ToString());
                    wrong++;
                }
            }

            Rpercentage = (double)right / (right + wrong) * 100;
            Wpercentage = (double)wrong / (right + wrong) * 100;
            Console.WriteLine("总题数有" + (right + wrong));
            Console.WriteLine("答對了" + right + "題,占總題數的" + Rpercentage + "%");
            Console.WriteLine("答錯了" + wrong + "題,占總題數的" + Wpercentage + "%");

        }
    }

}
