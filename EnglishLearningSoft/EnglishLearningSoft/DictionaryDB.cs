/**
字典存放单词用
*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace EnglishLearningSoftware
{
    class DictionaryDB
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string conStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\coding\EnglishLearningSoft\EnglishLearningSoft\Dictionary.mdf;Integrated Security = True";
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
        public DictionaryDB()
        {
            dictionary = new List<Word>();
            readDB();
        }
        private void readDB()
        {
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("请确定单词文件存在或未被占用");
            }
            cmd = new SqlCommand(@"select * from [dbo].[Dictionary]", con);
            dr=cmd.ExecuteReader();
            while (dr.Read())
                {
                string par1 = dr["frequency"].ToString();
                string par2 = dr["spell"].ToString();
                string par3 = dr["meaning"].ToString();
                dictionary.Add(new Word(par1, par2, par3));
                }
            dr.Close();
        }
    }
}
