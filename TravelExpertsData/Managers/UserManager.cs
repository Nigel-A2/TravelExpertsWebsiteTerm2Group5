using System;
using System.Linq;
using TravelExpertsMVC.Data;

// Authors: Nigel, Filip
namespace TravelExpertsData.Managers
{
	public class UserManager
	{
		/// <summary>
		/// User is authenticated based on credentials and a user returned if exists or null if not.
		/// </summary>
		
		/// <param name="password">Password as string</param>
		/// <returns>A user object or null.</returns>
		/// <remarks>
		/// Add additional for the docs for this application--for developers.
		/// </remarks>
		public static Customer Authenticate(string FirstName,string LastName, string password)
		{
			TravelExpertsContext db = new TravelExpertsContext();
			var user = db.Customers.SingleOrDefault(cust => cust.CustFirstName == FirstName && cust.CustLastName == LastName
			&& cust.CustPassword == password);
			return user;
		}

		/// <summary>
		/// add customer to db
		/// </summary>
		/// <param name="customer">customer to be added</param>
		public static void AddCustomer(Customer customer)
		{
			TravelExpertsContext db = new TravelExpertsContext();
			db.Customers.Add(customer);
			db.SaveChanges();
		}

		/// <summary>
		/// get single customer by ID
		/// </summary>
		/// <param name="customerID">id to find</param>
		/// <returns>customer matching id or null</returns>
		public static Customer GetCustomer(int customerID)
        {
			TravelExpertsContext db = new TravelExpertsContext();
			Customer customer = db.Customers.SingleOrDefault(cust => cust.CustomerId == customerID);
			return customer;
		}


		/// <summary>
		/// update customer to db
		/// </summary>
		/// <param name="customer">customer to update</param>
		/// <returns>updated customer</returns>
        public static Customer UpdateCustomer(Customer customer)
        {
			TravelExpertsContext db = new TravelExpertsContext();

            try
            {
				var customerToUpdate = db.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
				customerToUpdate.CustFirstName = customer.CustFirstName;
				customerToUpdate.CustLastName = customer.CustLastName;
				customerToUpdate.CustPassword = customer.CustPassword;
				customerToUpdate.CustEmail = customer.CustEmail;
				customerToUpdate.CustAddress = customer.CustAddress;
				customerToUpdate.CustBusPhone = customer.CustBusPhone;
				customerToUpdate.CustCity = customer.CustCity;
				customerToUpdate.CustPostal = customer.CustPostal;
				customerToUpdate.CustHomePhone = customer.CustHomePhone;
				customerToUpdate.CustCountry = customer.CustCountry;
				customerToUpdate.CustProv = customer.CustProv;
				db.SaveChanges();
			} catch (Exception exception)
			{
				Console.WriteLine("Error: " + exception.Message);
            }
			

			return customer;
		}
    }
}
