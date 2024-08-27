using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
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
    public class InsuredManager : IInsuredService
    {
        private readonly IInsuredDal _insuredDal;


        public InsuredManager(IInsuredDal insuredDal)
        {
            _insuredDal = insuredDal;
        }


        public IResult Add(Insured insured)
        {
            _insuredDal.Add(insured);
            return new SuccessResult(Messages.InsuredAdded);
        }

        public IResult Delete(Insured insured)
        {
            _insuredDal.Delete(insured);
            return new SuccessResult(Messages.InsuredDeleted);
        }

        public IDataResult<List<Insured>> GetAll()
        {
            return new SuccessDataResult<List<Insured>>(_insuredDal.GetList().ToList());
        }

        public IDataResult<Insured> GetById(int insuredId)
        {
            return new SuccessDataResult<Insured>(_insuredDal.Get(p => p.InsuredID == insuredId));
        }

        public IDataResult<Insured> GetByTC(string tc)
        {
            return new SuccessDataResult<Insured>(_insuredDal.Get(p => p.TC == tc));
        }

        public IResult Update(Insured insured)
        {
            _insuredDal.Update(insured);
            return new SuccessResult(Messages.InsuredUpdated);
        }
    }
}
