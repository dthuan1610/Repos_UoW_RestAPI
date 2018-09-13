using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TEST6.API.Models
{
    public class CustomerDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postalcode")]
        public string Postalcode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}