using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Dto.PoliceDto
{
    public class AddPoliceDto
    {
        public int InsuredID { get; set; }
        public int InsurerID { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Offer { get; set; }
    }
}
