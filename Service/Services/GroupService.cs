﻿using Domain.Models;
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
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllByRoom(string room)
        {


            return _groupRepository.GetAll(m => m.Room.Trim().ToLower().StartsWith(room.Trim().ToLower()));

            //return _groupRepository.GetAll(m => m.Name.StartsWith(room));
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

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
