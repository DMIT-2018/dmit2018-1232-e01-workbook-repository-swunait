using HogWildSystem.DAL;
using HogWildSystem.ViewModels;

namespace HogWildSystem.BLL
{
    public class CategoryLookupService
    {
        #region Fields

        /// <summary>
        /// The hog wild context
        /// </summary>
        private readonly HogWildContext _hogWildContext;

        #endregion

        // Constructor for the WorkingVersionService class.
        internal CategoryLookupService(HogWildContext hogWildContext)
        {
            // Initialize the _hogWildContext field with the provided HogWildContext instance.
            _hogWildContext = hogWildContext;
        }

        #region Lookup
        // Get the lookups.
        public List<LookupView> GetLookups(string categoryName)
        {
            return _hogWildContext.Lookups
                .Where(x => x.Category.CategoryName == categoryName)
                .OrderBy(x => x.Name)
                .Select(x => new LookupView
                {
                    LookupID = x.LookupID,
                    CategoryID = x.CategoryID,
                    Name = x.Name,
                    RemoveFromViewFlag = x.RemoveFromViewFlag
                }).ToList();
        }
        #endregion
    }
}
