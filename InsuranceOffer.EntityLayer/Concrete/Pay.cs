using InsuranceOffer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.EntityLayer.Concrete
{
    public class Pay:IEntity
    {
        
        [Key]
        public int PayID { get; set; } 

        public int PolicyID { get; set; } 
        public virtual Policy Policy { get; set; } 

        public int InsuredID { get; set; } 
        public virtual Insured Insured { get; set; } 

        public long KartNo { get; set; } 
        public DateTime ExpirationDate { get; set; } 
        public int CVC { get; set; } 
    }
}
