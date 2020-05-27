
using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{

    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        // NOTE Post Request
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (keepId, vaultId, userId)
            VALUES
            (@KeepId, @VaultId, @UserId);
            SELECT LAST_INSERT_ID()";
            newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            return newVaultKeep;
        }

        // NOTE Get Requests
        internal VaultKeep GetVaultKeepById(int id)
        {
            string sql = "SELECT * vaultkeeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        // NOTE Delete Request
        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }

    }

}