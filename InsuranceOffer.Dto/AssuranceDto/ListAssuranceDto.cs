using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Dto.AssuranceDto
{
    public class ListAssuranceDto
    {
        [Key]
        public Guid AssuranceCode { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isRequired { get; set; }
    }
}
