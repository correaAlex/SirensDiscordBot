using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirensDiscordBot.Models
{
    public class DiscordServer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ulong DiscordGuid { get; set; }
        public ulong ChanelGuid { get; set; }

        public string RolesSerialization
        {
            get
            {
                return JsonConvert.SerializeObject(Roles);
            }
            set
            {
                Roles = String.IsNullOrEmpty(value) ? new Dictionary<string,ulong>() : JsonConvert.DeserializeObject<Dictionary<string,ulong>>(value);
            }
        }
        [NotMapped]
        public Dictionary<string,ulong> Roles { get; set; }
        public string Language { get; set; } = "en";
    }
}
