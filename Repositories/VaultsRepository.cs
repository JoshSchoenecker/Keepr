using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        // NOTE Post Request
        internal Vault Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return newVault;
        }

        //  NOTE Get Requests
        internal Vault GetVaultById(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @Id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }
        internal IEnumerable<Vault> GetVaultsByUser(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @UserId";
            return _db.Query<Vault>(sql, new { userId });
        }

        // NOTE Delete Request
        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}