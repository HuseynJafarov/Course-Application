using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_App.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();

        public void Create()
        {
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
            Helpers.WriteConsole(ConsoleColor.Blue, "Search group by teacher name :");
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

            Helpers.WriteConsole(ConsoleColor.Blue, "Add group id :");
        GroupId: string groupId = Console.ReadLine();


            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                groupService.Delete(id);
                Console.WriteLine("Delete method works :");
               
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct id type:");
                goto GroupId;
            }
        }

        public void Update()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Id :");
            GroupId:
            string updateGroupId = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Name:");
                string groupNewName = Console.ReadLine();
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Room:");
                string groupNewRoom = Console.ReadLine();
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Group new Teacher:");
                TeacherName:
                string groupNewTeacher = Console.ReadLine();

                int teacherName;
                bool isTeacherName = int.TryParse(groupNewTeacher, out teacherName);

                if (!isTeacherName && !string.IsNullOrEmpty(groupNewTeacher) || groupNewTeacher == "")
                {
                    bool isTeacher = string.IsNullOrEmpty(groupNewTeacher);

                    int? tname = null;
                    if (isTeacherName)
                    {                                               
                        tname = null;                             //if yada rejex stringdi deye
                    }
                    else
                    {
                        tname = teacherName;
                    }

                    Group group = new Group()
                    {
                        Name = groupNewName,
                        Room = groupNewRoom,
                        Teacher = groupNewTeacher
                    };
                    var resultGroup = groupService.Update(groupId, group);
                    if(resultGroup == null)
                    {
                        Helpers.WriteConsole(ConsoleColor.DarkRed, "Group not found, please try again:");
                        goto TeacherName;
                    }
                    else
                    {
                        Helpers.WriteConsole(ConsoleColor.Green, $" Group Id: {resultGroup.Id}, Group Name: {resultGroup.Name},Teacher Name: {resultGroup.Teacher}, Room:{resultGroup.Room}");
                    }

                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Teacher Name:");
                    goto TeacherName;
                }

            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Group Id:");
                goto GroupId;
            }
        }
    }
}
