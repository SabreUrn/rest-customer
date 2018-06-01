using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestCustomerClient {
	public static class CRUD {
		private static string customersUri = "http://localhost:26649/Service1.svc/customers/";
		private static string customersUriQuery = "http://localhost:26649/Service1.svc/customers?id=";

		public static async Task<IList<Customer>> GetCustomersAsync() {
			using (HttpClient client = new HttpClient()) {
				string content = await client.GetStringAsync(customersUri + "/");
				IList<Customer> customerList = JsonConvert.DeserializeObject<IList<Customer>>(content);
				return customerList;
			}
		}

		public static async Task<Customer> GetCustomerAsync(int id) {
			using (HttpClient client = new HttpClient()) {
				string content = await client.GetStringAsync(customersUriQuery + id);
				Customer customer = JsonConvert.DeserializeObject<Customer>(content);
				return customer;
			}
		}

		public static async Task<HttpResponseMessage> DeleteCustomerAsync(int id) {
			using (HttpClient client = new HttpClient()) {
				HttpResponseMessage response = await client.DeleteAsync(customersUriQuery + id);
				return response;
			}
		}

		public static async Task<HttpResponseMessage> PostCustomerAsync(Customer customer) {
			using (HttpClient client = new HttpClient()) {
				string json = JsonConvert.SerializeObject(customer);
				//byte[] buffer = Encoding.UTF8.GetBytes(json);
				//ByteArrayContent content = new ByteArrayContent(buffer);
				StringContent content = new StringContent(json);
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				HttpResponseMessage response = await client.PostAsync(customersUri, content);
				return response;
			}
		}

		public static async Task<HttpResponseMessage> PutCustomerAsync(Customer customer) {
			using (HttpClient client = new HttpClient()) {
				string json = JsonConvert.SerializeObject(customer);
				//byte[] buffer = Encoding.UTF8.GetBytes(json);
				//ByteArrayContent content = new ByteArrayContent(buffer);
				StringContent content = new StringContent(json);
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				HttpResponseMessage response = await client.PutAsync(customersUri, content);
				return response;
			}
		}
	}
}
