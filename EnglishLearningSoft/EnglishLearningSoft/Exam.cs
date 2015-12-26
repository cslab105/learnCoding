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
        //DictionaryFS d1;
        DictionaryDB d1;
        Examlog el1;
        Timer T1;
        string input;
        string stime;

        public Exam(Examlog examlog)
        {
            T1 = new Timer();
            el1 = examlog;
            right = 0;
            wrong = 0;
            Rpercentage = 0;
            Wpercentage = 0;
            //d1 = new Dictionary();
            d1 = new DictionaryDB();
            //原先循环不易理解且有缺陷
            /*            for (int i = 0; i < d1.dictionary.Count; i++)
                        {
                            Console.WriteLine(d1.dictionary[i].Meaning);
                            input = Console.ReadLine();
                            if (input == d1.dictionary[i].Spell)
                            {
                                Console.WriteLine("答對了");
                                el1.addExamLog(input);
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
            */
            while (d1.dictionary.Count != 0)
            {
                Random ran = new Random();
                int RandKey = ran.Next(0, d1.dictionary.Count);
                Console.WriteLine(d1.dictionary[RandKey].Meaning);
                input = Console.ReadLine();
                if (input == d1.dictionary[RandKey].Spell)
                {
                    Console.WriteLine("答對了");
                    el1.addTExamLog(d1.dictionary[RandKey].ToString());
                    right++;
                    d1.dictionary.RemoveAt(RandKey);
                }
                else
                {
                    Console.WriteLine("答錯了,是  " + d1.dictionary[RandKey].ToString());
                    el1.addFExamLog(input, d1.dictionary[RandKey].ToString());
                    el1.addExamErrorLog(input, d1.dictionary[RandKey].ToString());
                    wrong++;
                    d1.dictionary.Add(d1.dictionary[RandKey]);
                    d1.dictionary.RemoveAt(RandKey);
                }
            }

            Rpercentage = (double)right / (right + wrong) * 100;
            Wpercentage = (double)wrong / (right + wrong) * 100;
            Console.WriteLine("总题数有" + (right + wrong));
            Console.WriteLine("答對了" + right + "題,占總題數的" + Rpercentage + "%");
            Console.WriteLine("答錯了" + wrong + "題,占總題數的" + Wpercentage + "%");
            stime = T1.ToString();
            el1.endExamLog(stime);
            el1.endExamErrorLog(stime);
            Console.WriteLine(stime);
        }
    }

}
