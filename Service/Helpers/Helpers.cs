﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public class Helpers
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();


        }
            
    }

    public enum Menues
    {
        CreateGroup = 1,
        GetGroupbyid = 2,
        Updategroup = 3,
        Deletegroup =4,
        Getallgroupbyteacher = 5,
        Getallgroupbyroom =6,
        Getallgroup = 7,
        CreateStudent = 8,
        UpdateStudent = 9,
        Getstudentbyid = 10,
        Deletestudent = 11,
        GetStudentsbyAge = 12,
        GetallStudentsbyGroupid =13,
        SearchMethodforGroupsbyName =14,
        SearchMethodforStudentsbyNameorSurname = 15,
        GetAllStudent = 16






    }
}
