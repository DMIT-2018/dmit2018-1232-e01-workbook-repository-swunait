using Microsoft.AspNetCore.Components;
using NorthwindSystem.BLL;
using NorthwindSystem.ViewModels;

namespace NorthwindBlazorApp.Components.Pages.Query
{
    public partial class ProductsByCategory
    {
        // The feedback message
        private string feedbackMessage;

        // The error message
        private string errorMessage;

        // has feedback
        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);

        // has error
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);

        // error details
        private List<string> errorDetails = new();

        [Inject]
        protected ProductService ProductService { get; set; }

        private List<ProductByCategoryViewModel> queryResultList = new();

        private int categoryIdSearchValue;

        private void onSearch()
        {
            try
            {
                //  reset the error detail list
                errorDetails.Clear();

                //  reset the error message to an empty string
                errorMessage = string.Empty;

                //  reset feedback message to an empty string
                feedbackMessage = String.Empty;

                queryResultList = ProductService.GetByCategoryId(categoryIdSearchValue); ;

                if (queryResultList.Count == 0)
                {
                    feedbackMessage = $"There are no products with category id of {categoryIdSearchValue}";
                }
            }
            catch (ArgumentNullException ex)
            {
                errorMessage = BlazorHelperClass.GetInnerException(ex).Message;
            }
            catch (ArgumentException ex)
            {
                errorMessage = BlazorHelperClass.GetInnerException(ex).Message;
            }
            catch (AggregateException ex)
            {
                //  have a collection of errors
                //  each error should be place into a separate line
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessage = $"{errorMessage}{Environment.NewLine}";
                }
                errorMessage = $"{errorMessage}Unable to search for customer";
                foreach (var error in ex.InnerExceptions)
                {
                    errorDetails.Add(error.Message);
                }
            }

        }

    }
}
