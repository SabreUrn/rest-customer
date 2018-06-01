using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestCustomerClient {
	class Program {
		//private static HttpClient client;

		static void Main(string[] args) {
			//client = new HttpClient();

			PutCustomer(1, "jack", "swigert", 1972);
			PutCustomer(2, "beezlebub", "baal", 666);
			Console.WriteLine();

			PrintCustomers();

			Console.WriteLine("Printing customer with ID 1");
			Customer cPrint = CRUD.GetCustomerAsync(1).Result;
			Console.WriteLine(FormatCustomer(cPrint));
			Console.WriteLine();

			Console.WriteLine("Deleting customer with ID 2");
			HttpResponseMessage deleteResponse = CRUD.DeleteCustomerAsync(2).Result;
			Console.WriteLine(deleteResponse.StatusCode);
			Console.WriteLine();

			Console.WriteLine("Updating customer with ID 1");
			Customer c1new = new Customer(1, "jack", "swogert", 666);
			HttpResponseMessage postResponse = CRUD.PostCustomerAsync(c1new).Result;
			Console.WriteLine("Customer ID {id} post response:");
			Console.WriteLine(postResponse.StatusCode);
			Console.WriteLine(postResponse.ReasonPhrase);
			Console.WriteLine(postResponse.RequestMessage);
			Console.WriteLine();

			PrintCustomers();


			PrintCustomers();

			//client.Dispose();
			Console.ReadKey();
		}

		private static HttpResponseMessage PutCustomer(int id, string firstName, string lastName, int year) {
			Console.WriteLine("Creating customer with ID " + id);
			Customer c = new Customer(id, firstName, lastName, year);
			HttpResponseMessage response = CRUD.PutCustomerAsync(c).Result;
			Console.WriteLine($"Customer ID {id} put response: " + response.StatusCode);
			return response;
		}

		private static void PrintCustomers() {
			Console.WriteLine("Printing all customers.");
			IList<Customer> list = CRUD.GetCustomersAsync().Result;
			foreach (Customer c in list) {
				string output = FormatCustomer(c);
				Console.WriteLine(output);
			}
			Console.WriteLine();
		}

		private static string FormatCustomer(Customer customer) {
			return $"Customer #{customer.ID}: {customer.FirstName} {customer.LastName} created in {customer.Year}";
		}
	}
}
