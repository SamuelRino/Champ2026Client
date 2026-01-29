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
        public int CurrentStock { get; set; }
        public int MinStock { get; set; }
        public int Bills { get; set; }
        public string BillsCount { get; set; }
        public int Coins { get; set; }
        public string CoinsCount { get; set; }
        public int Changes { get; set; }
        public string ChangesCount { get; set; }
        public string LastSale { get; set; }
        public string LastEncashment { get; set; }
        public string LastService { get; set; }
        public int BillValidatorOk { get; set; }
        public int CashlessOk { get; set; }
        public int CashRegisterOk { get; set; }
        public int DisplayOk { get; set; }
        public int ControleMode { get; set; }
        public int ComType { get; set; }
        public int Audit { get; set; }
        public int DifferentsSettings { get; set; }
        public int EndedTimeWork { get; set; }
        public int FarmOnline { get; set; }
    }
}
