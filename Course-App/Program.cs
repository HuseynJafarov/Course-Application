using Course_App.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace Course_App
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();

            Helpers.WriteConsole(ConsoleColor.Red, "Select one Option :");

            GetMenues();


            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();
                int selecTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selecTrueOption);

                if (isSelectOption)
                {
                    switch (selecTrueOption)
                    {
                        case (int)Menues.CreateGroup:
                           groupController.Create();
                           break;
                        case (int)Menues.GetGroupbyid:
                            groupController.GetGroupById();
                            break;
                        case (int)Menues.Updategroup:
                            groupController.Update();
                            break;
                        case (int)Menues.Deletegroup:
                             groupController.Delete();
                            break;
                        case (int)Menues.Getallgroupbyteacher:
                            groupController.GetAllGroupByTeacher();
                            break;
                        case (int)Menues.Getallgroupbyroom:
                            groupController.GetAllGroupByRoom();
                            break;
                        case (int)Menues.Getallgroup:
                            groupController.GetAllGroup();
                            break;
                        case (int)Menues.CreateStudent:
                            studentController.Create();
                            break;
                        case (int)Menues.UpdateStudent:
                            studentController.Update();
                            break;
                        case (int)Menues.Getstudentbyid:
                            studentController.GetStudentById();
                            break;
                        case (int)Menues.Deletestudent:
                            studentController.Delete();
                            break;
                        case (int)Menues.GetStudentsbyAge:
                            studentController.GetStudentByAge();
                            break;
                        case (int)Menues.GetallStudentsbyGroupid:
                            studentController.GetAllStudentByGroupId();
                            break;
                        case (int)Menues.SearchMethodforGroupsbyName:
                            groupController.SearchGroupName();
                            break;
                        case (int)Menues.SearchMethodforStudentsbyNameorSurname:
                            studentController.SearchStudentNameSurname();
                            break;
                        case (int)Menues.GetAllStudent:
                            studentController.GetAllStudent();
                            break;
                        default:
                            Helpers.WriteConsole(ConsoleColor.Red, "Select correct Option numbers :");
                            break;
                    }
                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Select correct Option :");
                    goto SelectOption;
                }
             
            }
        }
        private static void GetMenues()
        {
            Helpers.WriteConsole(ConsoleColor.Green, "1- Create Group, 2- Get Group by id, 3- Update group,  " +
                "4- Delete group,5 - Get all group by teacher, 6 - Get all group  by room, 7 - Get all group, " +
                " 8 - Create Student  9 - Update Student   , 10- Get student  by id, 11 - Delete student, " +
                "   12 - Get students   by age, 13 - Get all students  by group id , 14- Search method for groups by name, " +
                "15 - Search method for students by name or surname, 16 - Get All Student");

        }
    }
}

