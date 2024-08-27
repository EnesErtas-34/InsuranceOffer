using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IVerificationCodesService
    {
        IResult Add(VerificationCodes verificationCode);
        IDataResult<VerificationCodes> GetByCode(string code);
    }
}
