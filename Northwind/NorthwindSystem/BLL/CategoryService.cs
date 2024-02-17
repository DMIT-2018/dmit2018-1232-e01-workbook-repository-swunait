using NorthwindSystem.DAL;
using NorthwindSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL
{
    public class CategoryService
    {
        private readonly NorthwindContext _northwindContext;

        internal CategoryService(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }   

        public List<CategoryQueryResultView> QueryAll()
        {
            return _northwindContext.Categories
                    .Select(c => new CategoryQueryResultView
                    {
                        CategoryID = c.CategoryID,
                        Name = c.CategoryName,
                        Description = c.Description
                    })
                    .OrderBy(x => x.Name)
                    .ToList();
        }
    }
}
