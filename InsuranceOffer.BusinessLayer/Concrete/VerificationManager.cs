using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.DataAccessLayer.Abstract;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Concrete
{
    public class VerificationManager : IVerificationCodesService
    {
        private readonly IVerificationCodesDal _verificationCodesDal;

        public VerificationManager(IVerificationCodesDal verificationCodesDal)
        {
            _verificationCodesDal = verificationCodesDal;
        }

        public IResult Add(VerificationCodes verificationCode)
        {
            _verificationCodesDal.Add(verificationCode);
            return new SuccessResult("Verification code added successfully.");
        }

        public IDataResult<VerificationCodes> GetByCode(string code)
        {
           
            var result = _verificationCodesDal.Get(v => v.Code == code);
            if (result != null)
            {

                _verificationCodesDal.Delete(result);//doğru girmiş demekki sil
                return new SuccessDataResult<VerificationCodes>(result, "Verification code found.");
            }
            return new ErrorDataResult<VerificationCodes>("Verification code not found.");
        }
        
    }
}

