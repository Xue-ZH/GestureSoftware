using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVs
{
    //读取CSV
    public static string[][] Read(string path)
    {
        string[] lineData = File.ReadAllLines(path);
        var rd = new string[lineData.Length][];
        for (int i = 0; i < lineData.Length; i++)
        {
            rd[i] = lineData[i].Split(',');
        }
        return rd;
    }

    //写入CSV
    //public static void Write(string[][]  sth,string path)
    //{
    //    StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
    //    string data = "";
    //    int j = 0;
    //    for (int i = 0; i < sth.Length;i++)
    //    {
    //        data = "";
    //        for (j = 0; j < sth[i].Length; j++)
    //        {
    //            data += sth[i][j];
    //            if (j < sth[i].Length - 1) data += ",";
    //        }
    //        sw.WriteLine(data);
    //    }
    //    sw.Flush();
    //    sw.Close();
    //}
    public static void Write(List<string> list, string path)
    {
        StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
        string data = "\n";
        for (int i = 0; i < list.Count; i++)
        {
            data = list[i] ;
            sw.WriteLine(data);
        }
        sw.Flush();
        sw.Close();
    }
    //按Key读取一行，仅用于Key纵向书写时
    public static string[] Readline(string path, string key)
    {
        var str = Read(path);
        var rdl=new string[] {};
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i][0] == key)
            {
                rdl = str[i];
                break;
            }
        }
        return rdl;
    }

    //按行写入
    //public static void Writeline(string[] strl, string path)
    //{
    //    var str = Read(path);
    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i][0] == strl[0])
    //        {
    //            str[i] = strl;
    //            break;
    //        }
    //    }
    //    Write(str,path);
    //}

    //public static void Writeline(string[] strl, string path)
    //{
    //    var str = Read(path);
    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i][0] == strl[0])
    //        {
    //            str[i] = strl;
    //            break;
    //        }
    //    }
    //    Write(str, path);
    //}


    ////这里因为我第一列存储的是书名，第二列是作者名，这里的函数用作根据书名返回相应作者名的功能
    //public static string FindAt(string book)
    //{
    //    var str = Read(Application.streamingAssetsPath + "/books.csv");
    //    var At = "";
    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i][0] == book)
    //        {
    //            At = str[i][1];
    //        }
    //    }

    //    return At;
    //}

    ////基本同上，根据书名返回第三列——书籍简介（所以！可以根据自身函数要求建立自己的通用函数，再整个程序中都可以调用，避免重复编写）
    //public static string FindBr(string book)
    //{
    //    var str = Read(Application.streamingAssetsPath + "/books.csv");
    //    var br = "";
    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i][0] == book)
    //        {
    //            br = str[i][2];
    //        }
    //    }

    //    return br;
    //}
}
