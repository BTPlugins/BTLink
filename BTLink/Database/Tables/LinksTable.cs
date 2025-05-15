using BTLink.Database.Models;
using ShimmyMySherbet.MySQL.EF.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLink.Database.Tables
{
    public class LinksTable : DatabaseTable<Links>
    {
        public LinksTable(string tableName) : base(tableName)
        {
        }
        public async Task<bool> AddLink(ulong playerID, string code)
        {
            var newCard = new Links()
            {
                PlayerID = playerID,
                Code = code,
            };
            try
            {
                await InsertAsync(newCard);
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
        public async Task<Links?> GetLinkedAccount(ulong playerID)
        {
            var account = await QuerySingleAsync<Links>("SELECT * FROM @TABLE WHERE PlayerID = @0", playerID);
            if (account == null) return null;
            return account;
        }
    }
}
