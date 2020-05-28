using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        // NOTE Post Request
        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        // NOTE Get Requests
        public IEnumerable<Keep> GetPublicKeeps()
        {
            return _repo.GetPublicKeeps();
        }
        public Keep GetKeepById(int id)
        {
            Keep foundKeep = _repo.GetKeepById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundKeep;
        }
        internal IEnumerable<Keep> GetKeepsByUser(string userId)
        {
            return _repo.GetKeepsByUser(userId);
        }

        // NOTE Delete Request
        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetKeepById(id);
            if (foundKeep.UserId != userId)
            {
                throw new Exception("Not your Keep!");
            }
            if (foundKeep.IsPrivate != false)
            {
                throw new Exception("You can not delete public Keeps");
            }
            if (_repo.Delete(id, userId))
            {
                return "Keep deleted";
            }
            throw new Exception("KeepsService Delete");
        }

// NOTE Many => Many
        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            return _repo.GetKeepsByVaultId(id);
        }

      

        // NOTE Put Requests
  internal Keep Edit(Keep keepToUpdate, string userId)
        {
            Keep foundKeep = GetKeepById(keepToUpdate.Id);
            if (foundKeep.Keeps < keepToUpdate.Keeps)
            {
                if (_repo.AddToKeepCount(keepToUpdate));
                {
                    foundKeep.Keeps = keepToUpdate.Keeps;
                    return foundKeep;
                }
                throw new Exception("wrong way");
            }
            if (_repo.Edit(keepToUpdate, userId))
            {
                return keepToUpdate;
            }
            throw new Exception("Not your Keep to edit");
        }

        // internal Keep toggleIsPrivate(Keep keepToUpdate, string userId)
        // {
        //     Keep foundKeep = GetKeepById(keepToUpdate.Id);
        //     if (foundKeep.UserId != userId)
        //     {
        //         throw new Exception("Please log in to edit this");
        //     }
        //     if (_repo.toggleIsPrivate(keepToUpdate) && foundKeep.IsPrivate == true)
        //     {
        //         foundKeep.IsPrivate = false;
        //         return keepToUpdate;
        //     }
        //     if (_repo.toggleIsPrivate(keepToUpdate) && foundKeep.IsPrivate == false)
        //     {
        //         foundKeep.IsPrivate = true;
        //         return keepToUpdate;
        //     }
        //     throw new Exception("You can not edit this");
        // }
    }
}