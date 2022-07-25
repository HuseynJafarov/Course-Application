using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Course_App.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService GroupService = new GroupService();

        public void Create()
        {

        GroupId:
            Helpers.WriteConsole(ConsoleColor.Blue, "Add Group Id :");
            string groupId = Console.ReadLine();

            int selectedGroupId;
            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);
            //Group group = new Group();
            //var result1 = studentService.Create(selectedGroupId, student1);
            //if (result1.Group is null)
            //{
            //  Helpers.WriteConsole(ConsoleColor.Red, "Add Correct Group Id :");
            //goto GroupId;
            //}
            if (isSelectedId)
            {
                string strRegex = @"^[a-zA-Z]+$";               
                Regex regex = new Regex(strRegex);
                StudentName:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Name :");
                string studentName = Console.ReadLine();
                if (!regex.IsMatch(studentName))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct student Name :");
                    goto StudentName;
                }
                StudentSurname:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Surname :");
                string studentSurname = Console.ReadLine();
                if (!regex.IsMatch(studentSurname))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct student Surname :");
                    goto StudentSurname;
                }

            StudentAge:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add student Age :");
                string studentAge = Console.ReadLine();
                int selectedAge;
                bool isSelectedAge = int.TryParse(studentAge, out selectedAge);
                if (isSelectedAge)
                {
                    Student student3 = new Student
                    {
                        
                        Name = studentName,
                        Surname = studentSurname,
                        Age = selectedAge
                    };
                    var result = studentService.Create(selectedGroupId,student3);

                    if (result != null)
                    {
                        Helpers.WriteConsole(ConsoleColor.Green, $"Student id : {result.Id}, Student name : {result.Name}, Student SurName {result.Surname}, Student Age : {result.Age}, Student Group :{result.Group.Name} ");
                    }
                    else
                    {
                        goto GroupId;
                    }
                   

                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct student Age :");
                    goto StudentAge;
                }
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct group Id type :");
                goto GroupId;
            }





        }

        public void Delete()
        {

            Helpers.WriteConsole(ConsoleColor.Blue, "Add Student id :");
        StudentId: string studentId = Console.ReadLine();


            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                var result = studentService.Delete(id);
                if (result == null)
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Student Can Not Find :");
                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.Yellow, "Student Delete :");
                }



            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct id type:");
                goto StudentId;
            }
        }

        public void GetStudentById()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "Add Student id :");
        StudentId: string studentId = Console.ReadLine();


            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId && !string.IsNullOrEmpty(studentId))
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    Helpers.WriteConsole(ConsoleColor.Green, $" Student Id: {student.Id}, Student Name: {student.Name},Student Surname: {student.Surname}, Student Age:{student.Age}, Student Group :{student.Group.Name}");
                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Student not found:");
                    goto StudentId;
                }
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct id type:");
                goto StudentId;
            }
        }

        public void GetAllStudent()
        {
            List<Student> students = studentService.GetAll();
            foreach (var item in students)
            {
                Helpers.WriteConsole(ConsoleColor.Green, $"Student id : {item.Id}, Student name : {item.Name}, Student SurName {item.Surname}, Student Age : {item.Age}, Student Group :{item.Group.Name} ");

            }
        }

        public void GetStudentByAge()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "Add Student Age :");
        StudentAge: string studentAge = Console.ReadLine();


            int age;
            bool isStudentAge = int.TryParse(studentAge, out age);

            if (isStudentAge && !string.IsNullOrEmpty(studentAge))
            {
                List<Student> students = studentService.GetByAge(age);
                if (!students.Any())
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Student not found:");
                    goto StudentAge;
                }

                foreach (var student in students)
                    Helpers.WriteConsole(ConsoleColor.Green, $" Student Id: {student.Id}, Student Name: {student.Name},Student Surname: {student.Surname}, Student Age:{student.Age}, Student Group :{student.Group.Name}");
                
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct Age:");
                goto StudentAge;
            }
        }

        public void GetAllStudentByGroupId()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "All Student by group id :");
        GroupId: string groupId = Console.ReadLine();

            int id;
            bool isGrouptId = int.TryParse(groupId, out id);
            if (isGrouptId && !string.IsNullOrEmpty(groupId))
            {
                List<Student> student1 = studentService.GetAllStudentByGroupId(id);

                if (student1.Count != 0)
                {

                    foreach (var item in student1)
                    {
                        Helpers.WriteConsole(ConsoleColor.Green, $" Student Id: {item.Id}, Student Name: {item.Name},Student Surname: {item.Surname}, Student Age:{item.Age}, Student Group :{item.Group.Name}");
                    }

                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Select correct Group Id:");
                    goto GroupId;
                }
            }





        }

        public void SearchStudentNameSurname()
        {
            Helpers.WriteConsole(ConsoleColor.Blue, "Add Student search text :");
        SearchText: string search = Console.ReadLine();
            List<Student> students = studentService.SearchStudentNameSurname(search);
            if (students != null)
            {
                foreach (var item in students)
                {
                    Helpers.WriteConsole(ConsoleColor.Green, $" Student Id: {item.Id}, Student Name: {item.Name},Student Surname: {item.Surname}, Student Age:{item.Age}, Student Group :{item.Group.Name}");
                }
            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.Blue, "Student Not Fount :");
                goto SearchText;
            }

        }

        public void Update()
        {
        StudentId:
            Helpers.WriteConsole(ConsoleColor.Blue, "Add Student Id :");
            string updateStudentId = Console.ReadLine();
            int studentId;
            bool isStudentId = int.TryParse(updateStudentId, out studentId);
            Student student1 = new Student();
            var result1 = studentService.Update(studentId, student1);
            if (result1 is null)
            {
                Helpers.WriteConsole(ConsoleColor.Red, "Add Correct Student Id :");
                goto StudentId;
            }

            if (isStudentId)
            {
                string strRegex = @"^[a-zA-Z]+$";                
                Regex regex = new Regex(strRegex);
                NewName:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Student new Name:");
                string studentNewName = Console.ReadLine();
                if (!regex.IsMatch(studentNewName))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct student new Name :");
                    goto NewName;
                }
                NewSurname:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Student new Surname:");
                string studentNewSurname = Console.ReadLine();
                if (!regex.IsMatch(studentNewSurname))
                {
                    Helpers.WriteConsole(ConsoleColor.Red, "Add correct student new Surname :");
                    goto NewSurname;
;
                }
                StudentAge:
                Helpers.WriteConsole(ConsoleColor.Blue, "Add Student new Age:");
                string studentNewAge = Console.ReadLine();

                int studentAge;
                bool isStudentAge = int.TryParse(studentNewAge, out studentAge);


                if (isStudentAge)
                {

                    Student student = new Student()
                    {
                        Name = studentNewName,
                        Surname = studentNewSurname,
                        Age = studentAge
                    };
                    var result = studentService.Update(studentId, student);
                    if (result != null)
                    {
                        Helpers.WriteConsole(ConsoleColor.Green, $"Student id : {result.Id}, Student name : {result.Name}, Student SurName {result.Surname}, Student Age : {result.Age} ");
                    }
                    else
                    {
                        goto StudentId;
                    }

                }
                else
                {
                    Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct New Age :");
                    goto StudentAge;
                }

            }
            else
            {
                Helpers.WriteConsole(ConsoleColor.DarkRed, "Add correct Syudent Id:");
                goto StudentId;
            }
        }


    }
}
