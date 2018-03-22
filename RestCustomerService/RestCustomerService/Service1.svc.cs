using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestCustomerService {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1 {
		private static List<Customer> customerList = new List<Customer> {
			new Customer(1, "jack", "swigert", 1972),
			new Customer(2, "jesus", "christ", 0)
		};

		public IList<Customer> GetCustomers() {
			return customerList;
		}

		public Customer GetCustomer(int id) {
			return customerList.FirstOrDefault(c => c.ID == id);
		}

		public bool DeleteCustomer(int id) {
			Customer customer = customerList.FirstOrDefault(c => c.ID == id);
			if(customer == null || !customerList.Contains(customer)) return false;

			customerList.Remove(customer);
			return true;
		}

		public bool AddCustomer(int id, string firstName, string lastName, int year) {
			Customer customer = new Customer(id, firstName, lastName, year);
			if (customerList == null) return false;
			customerList.Add(customer);
			return true;
		}

		public bool UpdateCustomer(int id, string firstName, string lastName, int year) {
			Customer customer = new Customer(id, firstName, lastName, year);
			int index = -1;
			try {
				index = customerList.FindIndex(c => c.ID == id);
			} catch(ArgumentNullException) {
				return false;
			}
			customerList[index] = customer;
			return true;
		}

		public string GetData() {
			return "returned";
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite) {
			if (composite == null) {
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue) {
				composite.StringValue += "Suffix";
			}
			return composite;
		}
	}
}
