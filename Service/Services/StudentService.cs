using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (student is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            
            _count++;
            return student;
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            _studentRepository.Delete(student);
        }

        public Student GetById(int id)
        {
            var student = _studentRepository.Get(m => m.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student Update(int id, Student student)
        {
            Student dbStudent = GetById(id);
            if (dbStudent is null) return null;
            student.Id = dbStudent.Id;                         //4-cu video 10-cu dq
            _studentRepository.Update(student);
            return student;
        }
    }

}
