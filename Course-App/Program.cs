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
            GroupService groupService = new GroupService();

            Helpers.WriteConsole(ConsoleColor.Red, "Select one Option :");
            Helpers.WriteConsole(ConsoleColor.Green, "1- Create Group, 2- Get Group by id, 3- Update group, 4- Delete group,5 - Get all group by teacher, 6 - Get all group  by room, 7 - Get all group,");

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
                            

                            
                            int teacherName;
                            bool isTeacherName = int.TryParse(groupTeacher, out teacherName);
                            

                            if (!isTeacherName && !string.IsNullOrEmpty(groupTeacher))
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
                            Helpers.WriteConsole(ConsoleColor.Blue, "Add group id :");
                            GroupId: string groupId = Console.ReadLine();
                           

                            int id;
                            bool isGroupId = int.TryParse(groupId, out id);

                            if (isGroupId && !string.IsNullOrEmpty(groupId))
                            {
                                Group group = groupService.GetById(id);
                                if(group != null)
                                {
                                    Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {group.Id}, Group Name: {group.Name},Teacher Name: {group.Teacher}, Room:{group.Room}");
                                }
                                else
                                {
                                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Group not found:");
                                    goto GroupId;
                                }
                            }
                            else
                            {
                                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct id type:");
                                goto GroupId;
                            }
                            break;
                        case 3:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 5:
                            Helpers.WriteConsole(ConsoleColor.Blue, "Search group by teacher name :");
                            TeacherName: string nameTh = Console.ReadLine();


                            List<Group> groups1 = groupService.GetAllByTeacherName(nameTh);

                            if (groups1.Count !=0)
                            {

                                foreach (var tName in groups1)
                                {
                                    Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {tName.Id}, Group Name: {tName.Name},Teacher Name: {tName.Teacher}, Room:{tName.Room}");
                                }
                               
                            }
                            else
                            {
                                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct teacher name:");
                                goto TeacherName;
                            }
                            break;
                        case 6:
                            Helpers.WriteConsole(ConsoleColor.Blue, "Search group by Room name :");
                        RoomName: string nameRoom = Console.ReadLine();


                            List<Group> groups2 = groupService.GetAllByRoom(nameRoom);

                            if (groups2.Count != 0)
                            {

                                foreach (var roomName in groups2)
                                {
                                    Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {roomName.Id}, Group Name: {roomName.Name},Teacher Name: {roomName.Teacher}, Room:{roomName.Room}");
                                }

                            }
                            else
                            {
                                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct Room name:");
                                goto RoomName;
                            }
                            break;
                        case 7:
                            List<Group> groups = groupService.GetAll();
                            foreach (var item in groups)
                            {
                                Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {item.Id}, Group Name: {item.Name},Teacher Name: {item.Teacher}, Room:{item.Room}");
                            }
                            break;
                        case 8:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 9:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 10:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 11:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 12:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 13:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 14:
                            Console.WriteLine(selecTrueOption);
                            break;
                        case 15:
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

