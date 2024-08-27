using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Dto.PoliceDto
{
    public class UpdatePoliceDto
    {

       
        public int PolicyID { get; set; }
        public int InsuredID { get; set; }
        public int InsurerID { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Offer { get; set; }
    }
}
