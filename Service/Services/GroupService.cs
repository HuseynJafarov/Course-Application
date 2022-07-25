using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public Group Create(Group group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);
            _groupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllByRoom(string room)
        {


            return _groupRepository.GetAll(m => m.Room.Trim().ToLower().StartsWith(room.Trim().ToLower()));

            //return _groupRepository.GetAll(m => m.Name.StartsWith(room)); //1-ci video 30-cu dq //2-ci video 18- ci dq
        }

        public List<Group> GetAllByTeacherName(string name)
        {
            return _groupRepository.GetAll(m => m.Teacher.Trim().ToLower().StartsWith(name.Trim().ToLower()));
        }

        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        }

        public List<Group> SearchGroupName(string search)
        {
            return _groupRepository.GetAll(m => m.Name.StartsWith(search));
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;                         //4-cu video 10-cu dq
            _groupRepository.Update(group);
            return group;
        }

        
    }
}
