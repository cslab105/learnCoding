/**
字典存放单词用
*/
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnglishLearningSoftware
{
    class DictionaryFS
    {
        internal struct Word
        {
            private string meaning;
            private string spell;
            private string frequency;
            public Word(string Frequency,string Spell, string Meaning)
            {
                this.frequency = Frequency;
                this.spell = Spell;
                this.meaning = Meaning;
            }
            public override string ToString()
            {
                return spell + "  " + meaning + "  使用频率" + frequency;
            }
            public string Meaning
            {
                get
                {
                    return meaning;
                }

                set
                {
                    meaning = value;
                }
            }
            public string Spell
            {
                get
                {
                    return spell;
                }

                set
                {
                    spell = value;
                }
            }
            public string Frequency
            {
                get
                {
                    return frequency;
                }

                set
                {
                    frequency = value;
                }
            }
        }
        internal List<Word> dictionary;
        public DictionaryFS(){
            dictionary = new List<Word>();
            readFS();
        }
        private void readFS()
        {
            StreamReader Sr = new StreamReader(@"..\..\word\tenwords.txt", Encoding.UTF8);
            //            StreamReader Sr = new StreamReader(@"..\..\word\all_item.txt", Encoding.UTF8);
            while (!Sr.EndOfStream)    
            {
                string rdata = Sr.ReadLine();
                /*              char[] xpart = rdata.ToCharArray();
                                string part1=null, part2, part3;
                                int x = 0, y = 0, z = 0;
                                for (x = 0; y != 2 & x <= xpart.Length - 1; x++)
                                {
                                    if (xpart[x] == ' ' && y==0)
                                    {
                                        part1 = rdata.Substring(0, x);
                                        y++;
                                        z = x+1;
                                        continue;
                                    }
                                    if (xpart[x] == ' ' && y == 1)
                                    {
                                        part2 = rdata.Substring(z, x - z);
                                        part3 = rdata.Substring(x + 1);
                                        dictionary.Add(new Word(part1, part2, part3));
                                        y++;
                                    }
                                    continue;
                                }
                */
                int i = rdata.IndexOf(' ');
                int n = rdata.IndexOf('(');
                string par1 = rdata.Substring(0, i);
                string par2 = rdata.Substring(i + 1, n - i - 2);
                string par3 = rdata.Substring(n);
                dictionary.Add(new Word(par1, par2, par3));
            }
        }
    }
}
