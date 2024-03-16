using HogWildSystem.BLL;
using HogWildSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class CustomerEdit
    {
        #region Fields
        // The customer
        private CustomerEditView customer = new();
        //  The provinces
        private List<LookupView> provinces = new();
        //  The countries
        private List<LookupView> countries = new();
        //  The status lookup
        private List<LookupView> statusLookup = new();
        // the edit context
        private EditContext editContext;

        private string closeButtonText = "Close";
        #endregion

        #region Feedback & Error Messages
        //  placeholder for feedback message
        private string feedbackMessage;

        //  placeholder for error messasge
        private string errorMessage;

        //  return has feedback
        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);

        //  return has error
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);

        //  used to display any collection of errors on web page
        //  whether the errors are generated locally or come from the class library
        private List<string> errorDetails = new();
        #endregion

        #region Properties
        //  The customer service
        [Inject] protected CustomerService CustomerService { get; set; }

        //  The category lookup service
        [Inject] protected CategoryLookupService CategoryLookupService { get; set; }

        // Inject the  NavigationManager depdency.
        [Inject] protected NavigationManager NavigationManager { get; set; }

        //  Customer ID used to create or edit a customer
        [Parameter] public int CustomerID { get; set; } = 0;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            try
            {
                //  reset the error detail list
                errorDetails.Clear();

                //  reset the error message to an empty string
                errorMessage = string.Empty;

                //  reset feedback message to an empty string
                feedbackMessage = String.Empty;

                //  edit context needs to be setup after data has been initialized
                //  setup of the edit context to make use of the payment type property
                editContext = new EditContext(customer);

                //  check to see if we are navigating using a valid customer CustomerID.
                //      or are we going to create a new customer.
                if (CustomerID > 0)
                {
                    customer = CustomerService.GetCustomer(CustomerID);
                }

                // lookups
                provinces = CategoryLookupService.GetLookups("Province");
                countries = CategoryLookupService.GetLookups("Country");
                statusLookup = CategoryLookupService.GetLookups("Customer Status");

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
        // save the customer
        private void Save()
        {
            //  reset the error detail list
            errorDetails.Clear();

            //  reset the error message to an empty string
            errorMessage = string.Empty;

            //  reset feedback message to an empty string
            feedbackMessage = String.Empty;
            try
            {
                customer = CustomerService.Save(customer);
                feedbackMessage = "Data was successfully saved!";
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
                errorMessage = $"{errorMessage}Unable to save the customer";
                foreach (var error in ex.InnerExceptions)
                {
                    errorDetails.Add(error.Message);
                }
            }
        }

        private async void Cancel()
        {
            NavigationManager.NavigateTo($"/SamplePages/CustomerList");
        }
    }
}
