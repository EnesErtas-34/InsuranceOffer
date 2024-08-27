using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.DataAccessLayer.Abstract;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Concrete
{
    public class PayManager : IPayService
    {
        private readonly IPayDal _payDal;

        public PayManager(IPayDal payDal)
        {
            _payDal = payDal;
        }

        public IResult Add(Pay pay)
        {
            _payDal.Add(pay);
            return new SuccessResult(Messages.PayAdded);
        }

        public IDataResult<Pay> Get(Expression<Func<Pay, bool>> filter)
        {
            var pay = _payDal.Get(filter);
            if (pay == null)
            {
                return new ErrorDataResult<Pay>(Messages.PayNotFound);
            }
            return new SuccessDataResult<Pay>(pay, Messages.PayFetched);
        }

        public IDataResult<IList<Pay>> GetList(Expression<Func<Pay, bool>> filter = null)
        {
            var pays = _payDal.GetList(filter);
            return new SuccessDataResult<IList<Pay>>(pays, Messages.PayListFetched);
        }
    }

}
