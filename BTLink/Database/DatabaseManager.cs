using MySql.Data.MySqlClient;
using ShimmyMySherbet.MySQL.EF.Core;
using ShimmyMySherbet.MySQL.EF.Models.Interfaces;
using ShimmyMySherbet.MySQL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTLink.Database.Tables;

namespace BTLink.Database
{
    public class DatabaseManager : DatabaseClient
    {
        public LinksTable Links { get; } = new LinksTable("BTLinks_Links");
        public DatabaseManager(DatabaseSettings settings) : base(settings)
        {
        }
    }
}
