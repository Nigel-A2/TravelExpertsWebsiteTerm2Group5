using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsMVC.Data;

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

		public static void AddCustomer(Customer customer)
		{
			TravelExpertsContext db = new TravelExpertsContext();
			db.Customers.Add(customer);
			db.SaveChanges();
		}
	}
}
