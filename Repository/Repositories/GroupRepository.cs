using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data NotFound");
                 AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }

        public void Delete(Group data)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
