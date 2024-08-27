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
    public class PoliceAssuranceManager : IPoliceAssuranceService
    {
        private readonly IPoliceAssuranceDal _policeAssuranceDal;

        public PoliceAssuranceManager(IPoliceAssuranceDal policeAssuranceDal)
        {
            _policeAssuranceDal = policeAssuranceDal;
        }

        public IResult Add(PoliceAssurance policeAssurance)
        {
            _policeAssuranceDal.Add(policeAssurance);
            return new SuccessResult(Messages.PoliceAssuranceAdded);
        }

        public IResult Delete(PoliceAssurance policeAssurance)
        {
            _policeAssuranceDal.Delete(policeAssurance);
            return new SuccessResult(Messages.PoliceAssuranceDeleted);
        }

        public IDataResult<List<PoliceAssurance>> GetAll()
        {
            return new SuccessDataResult<List<PoliceAssurance>>(_policeAssuranceDal.GetList().ToList());
        }

        public IDataResult<PoliceAssurance> GetById(int policeAssuranceId)
        {
            return new SuccessDataResult<PoliceAssurance>(_policeAssuranceDal.Get(p => p.PoliceAssuranceID == policeAssuranceId));
        }

        public IResult Update(PoliceAssurance policeAssurance)
        {
            _policeAssuranceDal.Update(policeAssurance);
            return new SuccessResult(Messages.PoliceAssuranceUpdated);
        }
    }
}
