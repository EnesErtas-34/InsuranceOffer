using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IInsuredService
    {
        IDataResult<Insured> GetById(int insuredId);
        IDataResult<List<Insured>> GetAll();
        IResult Add(Insured insured);
        IResult Update(Insured insured);
        IResult Delete(Insured insured);
        IDataResult<Insured> GetByTC(string tc);
    }
}
