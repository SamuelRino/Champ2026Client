using Champ2026Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ2026Client.ModelsDTO
{
    public class DisplayVmDTO
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = null!;
        public int StatusId { get; set; }
        public string Model { get; set; }
        public string Location { get; set; } = null!;
        public string OperatorName { get; set; } = null!;
        public int CommunicationQuality { get; set; }
        public DateTime LastRefreshTime { get; set; }
    }
}
