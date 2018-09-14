using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODELS.Model;
using TEST6.DATAS.Repository;
using TEST6.DATAS.Infrastructure;
using TEST6.DATAS.Interface;
using System.Linq.Expressions;


namespace TEST6.SERVICE
{
    public interface ICustomerService
    {
        customer Add(customer CusObj);

        void Update(customer CusObj);

        customer Delete(int id);

        IQueryable<customer> GetAll();

        customer GetSingle(int id);

        IQueryable<customer> Search(string searchingstring, string searchfield , string orderbyname , bool asc);

        IQueryable<customer> Paging(IQueryable<customer> _PageContent, int pageNumber, int pageSize);
        IQueryable<customer> Sort(string orderbyname, bool asc);
        void Save();

    }
    public class CustomerService : ICustomerService
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

        public IQueryable<customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public customer GetSingle(int id)
        {
            return _customerRepository.Get(id);
        }

        public IQueryable<customer> Paging(IQueryable<customer> _PageContent, int pageNumber, int pageSize)
        {
            return _customerRepository.Paging(_PageContent, pageNumber, pageSize);
        }

        public void Save()
        {
            _unitOfWork.Commit(); 
        }

        public IQueryable<customer> Search(string searchingstring,string searchfield, string orderbyname, bool asc)
        {
            return _customerRepository.SearchSort("dbo.customers",searchingstring , searchfield , orderbyname , asc);
        }

        public IQueryable<customer> Sort(string orderbyname, bool asc)
        {
            return _customerRepository.Sort(orderbyname, "dbo.customers",asc);
        }

        public void Update(customer CusObj)
        {
            _customerRepository.Update(CusObj);
        }
    }
}
