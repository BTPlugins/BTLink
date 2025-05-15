using ShimmyMySherbet.MySQL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLink.Database.Models
{
    public class Links
    {
        [SQLPrimaryKey, SQLAutoIncrement]
        public int Id { get; set; }
        public ulong PlayerID {  get; set; }
        public string Code { get; set; }
        public bool Linked { get; set; } = false;
        public ulong DiscordID { get; set; }
        public DateTime LinkedDate { get; set; }
    }
}
