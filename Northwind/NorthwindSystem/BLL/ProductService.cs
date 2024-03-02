using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using NorthwindSystem.ViewModels;
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

        public List<ProductByCategoryViewModel> GetByCategoryId(int categoryId)
        {
            // rules: categoryId must be > 0
            if (categoryId <= 0)
            {
                throw new ArgumentNullException("CategoryId value must be greater than 0.");
            }

            return _northwindContext.Products
                    .Where(p => p.CategoryID == categoryId)
                    .Select(p => new ProductByCategoryViewModel
                    {
                        ProductId = p.ProductID,
                        ProductName = p.ProductName,
                        Price = p.UnitPrice ?? 0
                    })
                    .OrderByDescending(x => x.Price)
                    .ToList();
        }

    }
}
