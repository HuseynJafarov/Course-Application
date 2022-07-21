using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAllByTeacherName(string name);
        List<Group> GetAllByRoom(string room);
        List<Group> GetAll();
        

    }
}
