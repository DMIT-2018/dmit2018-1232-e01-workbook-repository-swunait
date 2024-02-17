using Microsoft.AspNetCore.Components;
using NorthwindSystem.BLL;
using NorthwindSystem.ViewModels;

namespace NorthwindBlazorApp.Components.Pages.Query
{
    public partial class CategoryList
    {
        [Inject]
        protected CategoryService CurrentCategoryService { get; set; }

        private List<CategoryQueryResultView> queryResultList;

        private string feedback;

        public void OnSearch()
        {
            try
            {
                queryResultList = CurrentCategoryService.QueryAll();
                feedback = $"Query returned {queryResultList.Count} results.";
            }
            catch (Exception ex)
            {
                feedback = ex.Message;
            }
        }
    }
}
