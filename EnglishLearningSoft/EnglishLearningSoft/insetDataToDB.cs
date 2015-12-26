using System;
using System.Data.SqlClient;
using System.Text;

namespace EnglishLearningSoftware
{
    internal class insetDataToDB
    {
        SqlConnection con;
        SqlCommand cmd;
        string conStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\coding\EnglishLearningSoft\EnglishLearningSoft\Dictionary.mdf;Integrated Security = True";

        public insetDataToDB()
        {
            con = new SqlConnection(conStr);
            con.Open();
            DictionaryFS d1 = new DictionaryFS();
            foreach (DictionaryFS.Word temp in d1.dictionary)
            {
                cmd = new SqlCommand(@"insert into Dictionary(meaning,spell,frequency) values (N" + "'" + temp.Meaning + "','" + temp.Spell + "','" + temp.Frequency + "')", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
