﻿namespace WebSignalRAppLesson15.Helpers;
public static class FileHelper
{
    public static double Read()
    {
        return double.Parse(File.ReadAllText("data.txt"));
    }

    public static void Write(double data)
    {
        File.WriteAllText("data.txt",data.ToString());
    }
}
