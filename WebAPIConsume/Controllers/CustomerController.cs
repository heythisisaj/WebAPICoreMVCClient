using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIConsume.Models;

namespace WebAPIConsume.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Customer> customerList = new List<Customer>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44318/api/Customer"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                }
            }
            return View(customerList);
        }

        [HttpGet] 

        public ViewResult GetCustomer()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer customer = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44318/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(customer);

        }


    }
}

