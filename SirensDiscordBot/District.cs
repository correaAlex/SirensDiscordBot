using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirensDiscordBot
{
    public class District
    {
        public DistrictStatus OldStatus  { get; set; }
        public DistrictStatus CurrentStatus { get; set; } = DistrictStatus.NoSiren;
    }
}
