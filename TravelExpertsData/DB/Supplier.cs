using System;
using System.Collections.Generic;

#nullable disable

namespace TravelExpertsMVC.Data
{
    public partial class Supplier
    {
        public Supplier()
        {
            ProductsSuppliers = new HashSet<ProductsSupplier>();
            SupplierContacts = new HashSet<SupplierContact>();
        }

        public int SupplierId { get; set; }
        public string SupName { get; set; }

        public virtual ICollection<ProductsSupplier> ProductsSuppliers { get; set; }
        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
    }
}
