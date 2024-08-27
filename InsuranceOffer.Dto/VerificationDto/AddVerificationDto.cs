using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Dto.VerificationDto
{
    public class AddVerificationDto
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}

