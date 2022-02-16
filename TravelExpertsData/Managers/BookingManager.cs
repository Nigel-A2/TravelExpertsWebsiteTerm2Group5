using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsData.DBViews;
using TravelExpertsMVC.Data;

namespace TravelExpertsData.Managers
{
    public class BookingManager
    {

        public static List<CustomerBooking> GetCustomerBookings(int customerId)
        {
            List<CustomerBooking> bookingsView = new List<CustomerBooking>();
            TravelExpertsContext db = new TravelExpertsContext();

            //get details from bookings details
            var customerBookingsWithoutPackage = db.Bookings.Where(b => b.CustomerId == customerId && b.PackageId == null);

            var bookingDetails = from booking in customerBookingsWithoutPackage
                                 join details in db.BookingDetails
                                 on booking.BookingId equals details.BookingId
                                 select new { booking, details };

            var bookingWithProducts = from bd in bookingDetails
                                      join ps in db.ProductsSuppliers
                                      on bd.details.ProductSupplierId equals ps.ProductSupplierId
                                      join p in db.Products
                                      on ps.ProductId equals p.ProductId
                                      join s in db.Suppliers
                                      on ps.SupplierId equals s.SupplierId
                                      select new
                                      {
                                          BookingId = bd.booking.BookingId,
                                          BookingNo = bd.booking.BookingNo,
                                          PeopleNo = Convert.ToInt32(bd.booking.TravelerCount),
                                          BookingDate = bd.booking.BookingDate,
                                          TotalPrice = Convert.ToDecimal(bd.booking.TravelerCount.GetValueOrDefault(1))
                                          * Convert.ToDecimal(bd.details.BasePrice) + Convert.ToDecimal(bd.details.AgencyCommission),
                                          TripStart = bd.details.TripStart,
                                          TripEnd = bd.details.TripEnd,
                                          Description = bd.details.Description,
                                          ProductName = p.ProdName,
                                          SupplierName = s.SupName
                                      };

            foreach (var booking in bookingWithProducts)
            {
                CustomerBooking cb = new CustomerBooking();
                cb.BookingId = booking.BookingId;
                cb.BookingDate = booking.BookingDate;
                cb.PeopleNo = booking.PeopleNo;
                cb.BookingNo = booking.BookingNo;
                cb.TripStart = booking.TripStart;
                cb.TripEnd = booking.TripEnd;
                cb.Description = booking.Description;
                cb.TotalPrice = booking.TotalPrice;
                cb.ProductsInBooking = new List<string>();
                cb.ProductsInBooking.Add(booking.ProductName + ", " + booking.SupplierName);
                bookingsView.Add(cb);
            }


            //get details from package
            var customerBookingsWithPackage = db.Bookings.Where(b => b.CustomerId == customerId && b.PackageId != null);

            var packagesDetails = from booking in customerBookingsWithPackage
                                  join package in db.Packages
                                  on booking.PackageId equals package.PackageId
                                  select new {booking, package };

            var bookingWithPackageProducts = from pd in packagesDetails
                                             join pps in db.PackagesProductsSuppliers
                                             on pd.package.PackageId equals pps.PackageId
                                             join ps in db.ProductsSuppliers
                                             on pps.ProductSupplierId equals ps.ProductSupplierId
                                             join s in db.Suppliers
                                             on ps.SupplierId equals s.SupplierId
                                             join p in db.Products
                                             on ps.ProductId equals p.ProductId
                                             select new
                                             {
                                                 BookingId = pd.booking.BookingId,
                                                 BookingNo = pd.booking.BookingNo,
                                                 PeopleNo = Convert.ToInt32(pd.booking.TravelerCount),
                                                 BookingDate = pd.booking.BookingDate,
                                                 TotalPrice = Convert.ToDecimal(pd.booking.TravelerCount.GetValueOrDefault(1))
                                                    * Convert.ToDecimal(pd.package.PkgBasePrice) + Convert.ToDecimal(pd.package.PkgAgencyCommission),
                                                 TripStart = pd.package.PkgStartDate,
                                                 TripEnd = pd.package.PkgEndDate,
                                                 Description = pd.package.PkgDesc,
                                                 ProductName = p.ProdName,
                                                 SupplierName = s.SupName
                                             };



            foreach (var booking in bookingWithPackageProducts)
            {
                if(!bookingsView.Exists(b => b.BookingId == booking.BookingId))
                {
                    CustomerBooking cb = new CustomerBooking();
                    cb.BookingId = booking.BookingId;
                    cb.BookingDate = booking.BookingDate;
                    cb.PeopleNo = booking.PeopleNo;
                    cb.BookingNo = booking.BookingNo;
                    cb.TripStart = booking.TripStart;
                    cb.TripEnd = booking.TripEnd;
                    cb.TotalPrice = booking.TotalPrice;
                    cb.Description = booking.Description;
                    cb.ProductsInBooking = new List<string>();
                    cb.ProductsInBooking.Add(booking.ProductName + ", " + booking.SupplierName);
                    bookingsView.Add(cb);
                }
                else
                {
                    CustomerBooking cb = bookingsView.Find(b => b.BookingId == booking.BookingId);
                    cb.ProductsInBooking.Add(booking.ProductName + ", " + booking.SupplierName);
                }
                
            }

            return bookingsView;
        }
    }
}
