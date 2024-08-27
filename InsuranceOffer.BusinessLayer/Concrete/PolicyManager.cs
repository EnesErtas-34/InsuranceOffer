using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.DataAccessLayer.Abstract;
using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Concrete
{
    public class PolicyManager : IPolicyService
    {
        private readonly IPolicyDal _policyDal;

        public PolicyManager(IPolicyDal policyDal)
        {
            _policyDal = policyDal;
        }

        public IResult Add(Policy policy)
        {
            _policyDal.Add(policy);
            return new SuccessResult(Messages.PolicyAdded);
        }

        public IResult Delete(Policy policy)
        {
            _policyDal.Delete(policy);
            return new SuccessResult(Messages.PolicyDeleted);
        }

        public IDataResult<List<Policy>> GetAll()
        {
            return new SuccessDataResult<List<Policy>>(_policyDal.GetList().ToList());
        }

        public IDataResult<Policy> GetById(int policyId)
        {
            return new SuccessDataResult<Policy>(_policyDal.Get(p => p.PolicyID == policyId));
        }

        public IResult Update(Policy policy)
        {
            _policyDal.Update(policy);
            return new SuccessResult(Messages.PolicyUpdated);
        }
    }
}
