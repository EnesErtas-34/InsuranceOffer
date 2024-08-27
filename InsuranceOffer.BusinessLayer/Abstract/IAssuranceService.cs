using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IAssuranceService
    {
        IDataResult<Assurance> GetById(Guid assuranceId);
        IDataResult<List<Assurance>> GetAll();
        IResult Add(Assurance assurance);
        IResult Update(Assurance assurance);
        IResult Delete(Assurance assurance);
    }
}
