using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIConsume.Models;

namespace WebAPIConsume.Controllers
{
  
        public class OrderController : Controller
        {
            public async Task<IActionResult> Index()
            {
                List<Order> orderList = new List<Order>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44378/api/Order"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        orderList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                    }
                }
                return View(orderList);
            }

              [HttpGet]

              public ViewResult GetOrder()
              {
                  return View(); 
              }

               [HttpPost]

                public async Task<IActionResult> GetOrder(int id)
        {
            Order order = new Order();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44378/api/Order/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    order = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return View(order);

        }


        //    [HttpGet]
        //    public ViewResult AddOrder()
        //    {
        //        return View();

        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> AddCustomer(Order customer)
        //    {
        //        if (ModelState.IsValid)  //server side validation
        //        {
        //            using (var httpClient = new HttpClient())
        //            {

        //                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
        //                using (var response = await httpClient.PostAsync("https://localhost:44378/api/Customer/", content))
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
        //                }
        //            }
        //            return View(customer);  //if valid
        //        }

        //        return View(); //empty view


        //    }


        //    [HttpGet]
        //    public async Task<IActionResult> UpdateCustomer(int id)

        //    {
        //        Customer customer = new Customer();
        //        using (var httpClient = new HttpClient())
        //        {
        //            using (var response = await httpClient.GetAsync("https://localhost:44378/api/customer/" + id))

        //            {

        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
        //            }

        //        }
        //        return View(customer);  //if valid

        //    }
        //    [HttpPost]
        //    public async Task<IActionResult> UpdateCustomer(Customer customer)
        //    {
        //        Customer receivedCustomer = new Customer();
        //        if (ModelState.IsValid)
        //        {
        //            using (var httpClient = new HttpClient())
        //            {
        //                var content = new MultipartFormDataContent();
        //                content.Add(new StringContent(customer.Id.ToString()), "Id");
        //                content.Add(new StringContent(customer.Name), "Name");
        //                content.Add(new StringContent(customer.Address), "Address");
        //                content.Add(new StringContent(customer.Telephone), "Telephone");
        //                content.Add(new StringContent(customer.Email), "Email");
        //                using (var response = await httpClient.PutAsync("https://localhost:44378/api/customer/", content))

        //                {

        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    ViewBag.Result = "Success!";
        //                    receivedCustomer = JsonConvert.DeserializeObject<Customer>(apiResponse);
        //                }

        //            }
        //        }

        //        return View(receivedCustomer);
        //    }




        //    [HttpPost]
        //    public async Task<IActionResult> DeleteCustomer(int id)

        //    {

        //        using (var httpClient = new HttpClient())
        //        {
        //            using (var response = await httpClient.DeleteAsync("https://localhost:44378/api/customer/" + id))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();


        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }


        //}
    }
}

