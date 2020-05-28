using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        // NOTE Post Request
        internal Keep Create(Keep newKeep)
        {

            string sql = @"
            INSERT INTO keeps
            (userid, name, description, img, isPrivate)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate);
            SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

        // NOTE Get Requests
        internal IEnumerable<Keep> GetPublicKeeps()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0";
            return _db.Query<Keep>(sql);
        }
        internal Keep GetKeepById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }


        // NOTE Delete Request
        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }

        internal IEnumerable<Keep> GetKeepsByUser(string userId)
        {
            // dont forget to select from something:
            // SELECT => _ <= FROM
            string sql = "SELECT * FROM keeps WHERE userId = @UserId";
            return _db.Query<Keep>(sql, new { userId });
        }

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
        {
            string sql = @"
            SELECT 
            k.*,
            vk.id AS vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
        }

        internal bool AddToKeepCount(Keep keepToUpdate)
        {
            string sql = @"
            UPDATE keeps
            SET
            keeps = @Keeps,
            views = @Views
            WHERE id = @Id";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows == 1;
        }

        // internal bool AddToViewCount(Keep keepToUpdate)
        // {
        //     string sql = @"
        //     UPDATE keeps
        //     SET
        //     views = @Views
        //     WHERE id = @id";
        //     int affectedRows = _db.Execute(sql, keepToUpdate);
        //     return affectedRows == 1;
        // }

        internal bool Edit(Keep keepToUpdate, string userId)
        {
            keepToUpdate.UserId = userId;
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @isPrivate
            WHERE id = @Id AND userId = @UserId";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows == 1;
        }

        // NOTE Put Requests
        //     internal bool toggleIsPrivate(Keep keepToUpdate)
        //     {
        //         string sql = @"
        //         UPDATE keeps
        //         SET
        //         isPrivate = @IsPrivate
        //         WHERE id = @Id";
        //     int affectedRows = _db.Execute(sql, keepToUpdate);
        //     return affectedRows == 1;
        //     }
    }
}