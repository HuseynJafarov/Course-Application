using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Group = Domain.Models.Group;

namespace Course_App.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();

        public void Create()
        {
            string strRegex = @"^[a-zA-Z]+$";
            string strRegexFor = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(strRegex);
            Regex regexFor = new Regex(strRegexFor);
          GroupName:
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Name :");
            string groupName = Console.ReadLine();
            if (!regexFor.IsMatch(groupName))
            {
                Helpers.WriteConsole(ConsoleColor.Red, "Add correct group Room :");
                goto GroupName;
            }
               
          GroupRoom: 
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Room :");
            string groupRoom = Console.ReadLine();
             if (!regexFor.IsMatch(groupRoom))
            {
                Helpers.WriteConsole(ConsoleColor.Red, "Add correct group Room :");
                goto GroupRoom;
            }
                
            GroupTeacher:
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Teacher :");
            string groupTeacher = Console.ReadLine();
             if (!regex.IsMatch(groupTeacher))
            {
                Helpers.WriteConsole(ConsoleColor.Red, "Add correct group Teacher :");
                goto GroupTeacher;
            }
                
            

            Group group = new Group()
            {
                Name = groupName,
                Room = groupRoom,
                Teacher = groupTeacher


            };
            var result = groupService.Create(group);
            Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {result.Id}, Group Name: {result.Name},Teacher Name: {result.Teacher}, Room:{result.Room}");


        }

        public void GetGroupById()
        {

            Helpers.WriteConsole(ConsoleColor.Blue, "Add group id :");
        GroupId: string groupId = Console.ReadLine();


            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId && !string.IsNullOrEmpty(groupId))
            {
                Group group = groupService.GetById(id);
                if (group != null)
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
        }

        public void GetAllGroupByTeacher()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "All group by teacher name :");
        TeacherName: string nameTh = Console.ReadLine();


            List<Group> groups1 = groupService.GetAllByTeacherName(nameTh);

            if (groups1.Count != 0)
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
        }

        public void GetAllGroupByRoom()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "All group by Room name :");
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
        }

        public void GetAllGroup()
        {
            List<Group> groups = groupService.GetAll();
            foreach (var item in groups)
            {
                Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {item.Id}, Group Name: {item.Name},Teacher Name: {item.Teacher}, Room:{item.Room}");
            }
        }

        public void Delete()
        {
        GroupId:
            string groupId = Console.ReadLine();
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group id :");


            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                groupService.Delete(id);
                Helpers.WriteConsole(ConsoleColor.Yellow, "Delete method works :");

            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct id type:");
                goto GroupId;
            }
        }

        public void Update()
        {
        GroupId:
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Id :");
            string updateGroupId = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);
            Group group1 = new Group();
            var result1 = groupService.Update(groupId, group1);
            if (result1 is null)
            {
                Helpers.WriteConsole(ConsoleColor.Red, "Add Correct Group Id :");
                goto GroupId;
            }

            if (isGroupId)
            {
                string strRegex = @"^[a-zA-Z]+$";
                string strRegexFor = @"^[a-zA-Z0-9]+$";
                Regex regex = new Regex(strRegex);
                Regex regexFor = new Regex(strRegexFor);
                GroupNewName:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Name:");
                string groupNewName = Console.ReadLine();
                if (!regexFor.IsMatch(groupNewName))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct group Room :");
                    goto GroupNewName;
                }
                GroupNewRoom:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Room:");
                string groupNewRoom = Console.ReadLine();
                if (!regexFor.IsMatch(groupNewRoom))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct group Room :");
                    goto GroupNewRoom;
                }
                TeacherName:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Teacher:");
                string groupNewTeacher = Console.ReadLine();
                
                if (!regex.IsMatch(groupNewTeacher))
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Teacher Name:");
                    goto TeacherName;
                }
                

                Group group = new Group()
                {
                    Name = groupNewName,
                    Room = groupNewRoom,
                    Teacher = groupNewTeacher
                };
                var resultGroup = groupService.Update(groupId, group);
                Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {resultGroup.Id}, Group Name: {resultGroup.Name},Teacher Name: {resultGroup.Teacher}, Room:{resultGroup.Room}");


            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Group Id:");
                goto GroupId;
            }
        }

        public void SearchGroupName()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group search text :");
        SearchText: string search = Console.ReadLine();
            List<Group> groups = groupService.SearchGroupName(search);
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {item.Id}, Group Name: {item.Name},Teacher Name: {item.Teacher}, Room:{item.Room}");
                }
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.Blue, "Group Not Fount :");
                goto SearchText;
            }

        }


    }

    
}
