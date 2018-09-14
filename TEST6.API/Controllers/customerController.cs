using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST6.MODELS.Model;
using TEST6.DATAS.Infrastructure;
using TEST6.DATAS.Repository;
using TEST6.SERVICE;
using TEST6.API.Models;
using AutoMapper;
using Unity.WebApi;

namespace TEST6.API.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }


        [HttpGet]
        // GET: api/Customer
        public List<CustomerDTO> Get()
        {
            var ListCus = _customerService.GetAll();
            return Mapper.Map<List<CustomerDTO>>(ListCus);
        }

        [HttpGet]
        // GET: api/Customer/5
        public CustomerDTO Get(int id)
        {
            var CusObj = _customerService.GetSingle(id);
            return Mapper.Map<CustomerDTO>(CusObj);
        }

        [HttpGet]
        public List<CustomerDTO> Search( string searchstring ,bool asc =true , int pagenumber =1 , int pagesize = 100)
        {
            var listcus = _customerService.Search(searchstring , asc , pagesize, pagenumber);
            return Mapper.Map<List<CustomerDTO>>(listcus);
        }

        [HttpPost]
        // POST: api/Customer
        public CustomerDTO Post(CustomerDTO CusObj)
        {
            customer Cus = Mapper.Map<customer>(CusObj);
            var cusDTO = _customerService.Add(Cus);
            _customerService.Save();
            return Mapper.Map<CustomerDTO>(cusDTO);
        }

        [HttpPut]
        public CustomerDTO Put(int id,CustomerDTO CusObj)
        {
            CusObj.Id = id;
            _customerService.Update(Mapper.Map<customer>(CusObj));
            _customerService.Save();
            return Mapper.Map<CustomerDTO>(_customerService.GetSingle(id));
        }

        [HttpDelete]
        public List<CustomerDTO> Delete(int id)
        {
            _customerService.Delete(id);
            _customerService.Save();
            return Mapper.Map<List<CustomerDTO>>(_customerService.GetAll());
        }
    }
}
