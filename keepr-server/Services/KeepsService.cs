using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Keep> GetAll()
        {
            return _repo.GetAll();
        }

        internal Keep Get(int id)
        {
            var data = _repo.Get(id);
            if (data == null)
            {
                throw new Exception("Invalid Id Aye");
            }
            return data;
        }

        internal Keep Create(Keep newKeep)
        {
            newKeep.Id = _repo.Create(newKeep);
            return newKeep;
        }

        internal Keep Edit(Keep editData, string userId)
        {
            Keep original = Get(editData.Id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot edit a Keep you did not create, so cut it out"); }
            editData.Name = editData.Name == null ? original.Name : editData.Name;

            return _repo.Edit(editData);
        }

        internal string Delete(int id, string userId)
        {
            Keep original = Get(id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Keep you did not create, get outta here"); }
            _repo.Remove(id);
            return "Keep deleted";
        }
    }
}