using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int Id, Group group);
        void Delete(int Id);
        Group GetById(int Id);
        List<Group> GetAll();

    }
}
