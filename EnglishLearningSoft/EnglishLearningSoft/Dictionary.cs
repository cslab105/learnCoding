/**
字典存放单词用
*/
using System.Collections.Generic;

namespace EnglishLearningSoftware
{
     class Dictionary
    {
        internal struct Word
        {
            private string meaning;
            private string spell;

            public override string ToString()
            {
                return spell + "  "+ meaning;
            }
            public Word(string Spell, string Meaning)
            {
                this.spell = Spell;
                this.meaning = Meaning;
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
        }

        internal List<Word> dictionary;
 
        public Dictionary(){
            dictionary = new List<Word> {
                    new Word("abandon", "(v.)放棄(=give up) 耽溺於，陷於..之中(～oneself to)"),
                    new Word("abbey", "(n.)修道院；大修道院；全院修士(或修女)"),
                    new Word("abide", "(v.)遵守(～by)(與by連用)"),
                    new Word("ability", "(n.)能力"),
            };
        }


    }
}
