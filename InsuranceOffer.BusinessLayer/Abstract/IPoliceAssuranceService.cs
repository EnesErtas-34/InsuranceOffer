using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IPoliceAssuranceService
    {
        IDataResult<PoliceAssurance> GetById(int policeAssuranceId);
        IDataResult<List<PoliceAssurance>> GetAll();
        IResult Add(PoliceAssurance policeAssurance);
        IResult Update(PoliceAssurance policeAssurance);
        IResult Delete(PoliceAssurance policeAssurance);
    }
}
