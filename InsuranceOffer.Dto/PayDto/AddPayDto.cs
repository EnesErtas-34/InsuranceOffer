using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Dto.PayDto
{
    public class AddPayDto
    {
        public int PolicyID { get; set; }
        public int InsuredID { get; set; }
        public long KartNo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVC { get; set; }
    }
}
