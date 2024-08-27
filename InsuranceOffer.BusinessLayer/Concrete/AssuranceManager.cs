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
    public class AssuranceManager : IAssuranceService
    {
        private readonly IAssuranceDal _assuranceDal;

        public AssuranceManager(IAssuranceDal assuranceDal)
        {
            _assuranceDal = assuranceDal;
        }

        public IResult Add(Assurance assurance)
        {
            _assuranceDal.Add(assurance);
            return new SuccessResult(Messages.AssuranceAdded);

        }

        public IResult Delete(Assurance assurance)
        {
           _assuranceDal.Delete(assurance);
            return new SuccessResult(Messages.AssuranceDeleted);

        }

        public IDataResult<List<Assurance>> GetAll()
        {
            return new SuccessDataResult<List<Assurance>>(_assuranceDal.GetList().ToList());
        }

        public IDataResult<Assurance> GetById(Guid assuranceId)
        {
            return new SuccessDataResult<Assurance>(_assuranceDal.Get(p => p.AssuranceCode == assuranceId));
        }

        public IResult Update(Assurance assurance)
        {
            _assuranceDal.Update(assurance);
            return new SuccessResult(Messages.AssuranceUpdated);
        }
    }
}
