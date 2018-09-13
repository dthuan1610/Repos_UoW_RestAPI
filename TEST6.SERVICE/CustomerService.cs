using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODE;
using TEST6.DATA.Infrastructure;
using TEST6.DATA.Repository;

namespace TEST6.SERVICE
{
    public interface ICustomerService
    {
        customer Add(customer CusObj);

        void Update(customer CusObj);

        customer Delete(int id);

        List<customer> GetAll();

        customer GetSingle(int id);

        void Save();

    }
    class CustomerService : ICustomerService
    {
        private IcustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public CustomerService(IcustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public customer Add(customer CusObj)
        {
            return _customerRepository.Add(CusObj);
        }

        public customer Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public List<customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public customer GetSingle(int id)
        {
            return _customerRepository.Get(id);
        }

        public void Save()
        {
            _unitOfWork.commit();
        }

        public void Update(customer CusObj)
        {
            _customerRepository.Update(CusObj);
        }
    }
}
