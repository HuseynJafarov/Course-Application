﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);
        Student Delete(int id);
        Student GetById(int id);
        List<Student> GetAll();
        Student Update(int id, Student student);
        List<Student> GetByAge(int age);
        List<Student> GetAllStudentByGroupId(int id);
    }
}
