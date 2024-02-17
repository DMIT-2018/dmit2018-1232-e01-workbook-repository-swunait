using NorthwindSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL
{
    public class ProductService
    {
        private readonly NorthwindContext _northwindContext;

        internal ProductService(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

    }
}
