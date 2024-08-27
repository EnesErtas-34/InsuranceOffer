using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IPolicyService
    {
        IDataResult<Policy> GetById(int policyId);
        
        IDataResult<List<Policy>> GetAll();
        IResult Add(Policy policy);
        IResult Update(Policy policy);
        IResult Delete(Policy policy);

    }
}
