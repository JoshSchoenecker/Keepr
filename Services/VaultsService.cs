using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        // NOTE Post Request
        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        // NOTE Get Requests
        internal IEnumerable<Vault> GetVaultsByUser(string userId)
        {
            return _repo.GetVaultsByUser(userId);
        }
        public Vault GetVaultById(int id)
        {
            Vault foundVault = _repo.GetVaultById(id);
            if (foundVault == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundVault;
        }

        // NOTE Delete Request
        internal bool Delete(int id, string userId)
        {
            Vault foundVault = GetVaultById(id);
            if (foundVault.UserId != userId)
            {
                throw new Exception("Not your Vault!");
            }
            return _repo.Delete(id, userId);
        }
    }
}