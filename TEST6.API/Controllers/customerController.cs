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

        // GET: api/Customer/5
        public CustomerDTO Get(int id)
        {
            var CusObj = _customerService.GetSingle(id);
            return Mapper.Map<CustomerDTO>(CusObj);
        }

        [HttpPost]
        // POST: api/Customer
        public CustomerDTO Post(CustomerDTO CusObj)
        {
            customer Cus = Mapper.Map<customer>(CusObj);
            _customerService.Add(Cus);
            _customerService.Save();
            return CusObj;
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
