﻿//使用了goto语句待优化
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EnglishLearningSoftware
{
    internal class UmessageHASH
    {
        Hashtable uhash;
        public string uName;
        string uPassWord;
        public UmessageHASH()
        {
            uhash = new Hashtable();
            hashload();

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
        private void hashload()
        {
            uhash.Clear();
            FileStream fs = new FileStream("Umessage.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                uhash = (Hashtable)bf.Deserialize(fs);
            }
            catch (Exception e) { }
            fs.Close();

        }
        private void hashsave()
        {
            FileStream fs = new FileStream("Umessage.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, uhash);
            fs.Close();
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
            foreach (DictionaryEntry item in uhash)
            {
                if (item.Key.Equals(uName) && item.Value.Equals(uPassWord))
                    match = true;
            }
            return match;
        }
        private void addUmessage()
        {
            uhash.Add(uName, uPassWord);
            hashsave();
        }
        private void delUmessage()
        {
            if (matchUmessage())
            {
                uhash.Remove(uName);
                hashsave();
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