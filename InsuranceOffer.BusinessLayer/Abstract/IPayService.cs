using InsuranceOffer.Core.Utilities.Results;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.BusinessLayer.Abstract
{
    public interface IPayService
    {
        IDataResult<Pay> Get(Expression<Func<Pay, bool>> filter);
        IDataResult<IList<Pay>> GetList(Expression<Func<Pay, bool>> filter = null);
        IResult Add(Pay pay);
    }
}
