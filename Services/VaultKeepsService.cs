using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{

    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        // NOTE Post Request
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);
        }

        // NOTE Get Requests
        public VaultKeep GetVaultKeepById(int id)
        {
            VaultKeep foundVaultKeep = _repo.GetVaultKeepById(id);
            if (foundVaultKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundVaultKeep;
        }

        // NOTE Delete Request
        internal bool Delete(int id, string userId)
        {
            VaultKeep foundVaultKeep = GetVaultKeepById(id);
            if (foundVaultKeep.UserId != userId)
            {
                throw new Exception("This is not yours");
            }
            return _repo.Delete(id, userId);
        }
    }
}