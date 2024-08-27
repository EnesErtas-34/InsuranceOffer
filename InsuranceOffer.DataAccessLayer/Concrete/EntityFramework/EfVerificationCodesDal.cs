using InsuranceOffer.Core.DataAccess.EntityFramework;
using InsuranceOffer.DataAccessLayer.Abstract;
using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework.Contexts;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.DataAccessLayer.Concrete.EntityFramework
{
    public class EfVerificationCodesDal: EfEntityRepositoryBase<VerificationCodes, EurekoInsuranceContext>, IVerificationCodesDal
    {
    }
}
