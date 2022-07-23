using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_App.Controllers
{
   public class StudentController
    {
        StudentService studentService = new StudentService();
        public void Create()
        {
            StudentService studentService = new StudentService();
            Helpers.WriteConsole(ConsoleColor.Blue, "Add group Id :");
            GroupId:
            string groupId = Console.ReadLine();
            int selectedGroupId;
            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            if (isSelectedId)
            {
                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Name :");
                string studentName = Console.ReadLine();

                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Surname :");
                string studentSurname = Console.ReadLine();

                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Age :");
                StudentAge:
                string studentAge = Console.ReadLine();
                int selectedAge;
                bool isSelectedAge = int.TryParse(studentAge, out selectedAge);
                if (isSelectedAge)
                {
                    Student student = new Student
                    {
                        Name = studentName,
                        Surname = studentSurname,
                        Age = selectedAge
                    };
                    var result = studentService.Create(selectedGroupId,student);
                    if(result != null)
                    {
                        Helpers.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Student name : {result.Name}, Student SurName {result.Surname}, Student Age : {result.Age}, Student Group :{result.Group.Name} ");
                    }
                    else
                    {
                        goto StudentAge;
                    }
                    

                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Add student Age :");
                    goto StudentAge;
                }
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct group Id type :");
                goto GroupId;
            }
            


            
            
        }
    }
}
