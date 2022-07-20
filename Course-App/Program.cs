using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace Course_App
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();

            Helpers.WriteConsole(ConsoleColor.Red, "Select one Option :");
            Helpers.WriteConsole(ConsoleColor.Green,"1- Create Group, 2- Get Group by id, 3- Update group, 4- Delete group");

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();
                int selecTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selecTrueOption);

                if (isSelectOption)
                {
                    switch (selecTrueOption)
                    {
                        case 1:

                            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Name :");
                            string groupName = Console.ReadLine();
                            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Room :");
                            string groupRoom = Console.ReadLine();
                            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Teacher :");
                        Teacher:
                             string groupTeacher = Console.ReadLine();
                            Console.Clear();

                            
                            int teacherName;
                            bool isTeacherName = int.TryParse(groupTeacher, out teacherName);
                            

                            if (!isTeacherName && string.IsNullOrEmpty(groupTeacher))
                            {
                                Group group = new Group()
                                {
                                    Name = groupName,
                                    Room = groupRoom,
                                    Teacher = groupTeacher
                                    

                                };
                                var result = groupService.Create(group);
                                Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {result.Id}, Group Name: {result.Name},Teacher Name: {result.Teacher}, Room:{result.Room}");
                            }
                            
                            else
                            {
                                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Teacher Name:");
                                goto Teacher;
                                
                            }
                            

                           


                            break;
                        case 2:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 3:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(selecTrueOption);
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
    }
}

