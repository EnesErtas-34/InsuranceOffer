using InsuranceOffer.Core.DataAccess;
using InsuranceOffer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.DataAccessLayer.Abstract
{
    public interface IPoliceAssuranceDal:IEntityRepository<PoliceAssurance>
    {
    }
}
