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
		private static List<Customer> customerList = new List<Customer>();

		public IList<Customer> GetCustomers() {
			return customerList;
		}

		public Customer GetCustomer(int id) {
			return customerList.FirstOrDefault(c => c.ID == id);
		}

		public void DeleteCustomer(int id) {
			Customer customer = customerList.FirstOrDefault(c => c.ID == id);
			if(customer != null || customerList.Contains(customer)) customerList.Remove(customer);
		}

		public void AddCustomer(Customer customer) {
			if (customerList != null) customerList.Add(customer);
		}

		public void UpdateCustomer(Customer customer) {
			try {
				int index = customerList.FindIndex(c => c.ID == customer.ID);
				customerList[index].ID = customer.ID;
				customerList[index].FirstName = customer.FirstName;
				customerList[index].LastName = customer.LastName;
				customerList[index].Year = customer.Year;

			} catch (ArgumentNullException) {
			}
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
