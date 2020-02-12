using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model.Options
{
    public class SearchCustomerOptions
    {
        public int Id { get; set; }

        public string VatBumber { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
