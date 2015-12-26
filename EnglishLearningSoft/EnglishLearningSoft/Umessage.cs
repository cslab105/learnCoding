
//使用了goto语句待优化
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EnglishLearningSoftware
{
    internal class Umessage
    {
        public string uName;
        string uPassWord;
        public Umessage()
        {
            int num;
            Console.WriteLine("请选择操作： \n1.注册帐号 \n2.登入帐号 \n3.删除帐号 \n4.修改密码");
            num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("欢迎注册，请输入帐号名：");
                    uName = Console.ReadLine();
                    Console.WriteLine("请输入密码：");
                    uPassWord = readPassWord();
                    addUmessage();
                    Console.WriteLine("注册成功，开始测试！\n");
                    break;
                case 2:
                    Console.WriteLine("欢迎登入，请输入帐号名：");
                    uName = Console.ReadLine();
                    Console.WriteLine("请输入密码：");
                    uPassWord = readPassWord();
                    if (matchUmessage())
                        Console.WriteLine("登入成功，开始测试！\n");
                    else
                    {
                        Console.WriteLine("帐号或密码错误请重新输入");
                        goto case 2;
                    }
                    break;
                case 3:
                    Console.WriteLine("请输要删除的帐号名：");
                    uName = Console.ReadLine();
                    Console.WriteLine("请输入密码：");
                    uPassWord = readPassWord();
                    if (matchUmessage())
                    {
                        delUmessage();
                        Console.WriteLine("删除成功！");
                    }
                    else
                    {
                        Console.WriteLine("帐号或密码错误请重新输入");
                        goto case 3;
                    }
                    Process.GetCurrentProcess().Kill();
                    break;
                case 4:
                    Console.WriteLine("请输要修改密码的帐号名：");
                    uName = Console.ReadLine();
                    Console.WriteLine("请输入原密码：");
                    uPassWord = readPassWord();
                    if (matchUmessage())
                    {
                        changePassWord();
                    }
                    else
                    {
                        Console.WriteLine("帐号或密码错误请重新输入");
                        goto case 4;
                    }
                    break;
                default:
                    Console.WriteLine("输入参数错误\n");
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }
        private string readPassWord()
        {
            string PassWord = null;
            char ckey = ' ';
            while (ckey != '\r')
            {
                ckey = Console.ReadKey(true).KeyChar;
                if (ckey == '\b')
                {
                    if (PassWord.Length > 0)
                    {
                        PassWord = PassWord.Substring(0, PassWord.Length - 1);
                    }
                    Console.Write("\b \b");

                }
                else if (ckey != '\r')
                {
                    PassWord += ckey;
                    Console.Write('*');
                }
            }
            Console.WriteLine();
            return PassWord;
        }
        private bool matchUmessage()
        {
            bool match = false;
            StreamReader sr = new StreamReader("Umessage.txt");
            while (match != true && !sr.EndOfStream)
            {
                string singleLine = sr.ReadLine();
                int i = singleLine.IndexOf(' ');
                if (uName.Equals(singleLine.Substring(0, i)))
                    match = uPassWord.Equals(singleLine.Substring(i + 1));
            }
            sr.Close();
            return match;
        }
        private void addUmessage()
        {
            FileStream sf = new FileStream("Umessage.txt", FileMode.OpenOrCreate);
            sf.Position = sf.Length;
            StreamWriter sw = new StreamWriter(sf);
            sw.WriteLine(uName + " " + uPassWord);
            sw.Close();
            sf.Close();
        }
        private void delUmessage()
        {
            if (matchUmessage())
            {
                List<string> lines = new List<string>(File.ReadAllLines("Umessage.txt"));
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Equals(uName + " " + uPassWord))
                        lines.RemoveAt(i);
                }
                File.WriteAllLines("Umessage.txt", lines.ToArray());
            }
            else
                Console.WriteLine("请输入正确的帐号密码");

        }
        private void changePassWord()
        {
            delUmessage();
            Console.WriteLine("请输入新密码:");
            uPassWord = readPassWord();
            addUmessage();
            Console.WriteLine("修改密码成功，开始测试！\n");
        }
    }
}