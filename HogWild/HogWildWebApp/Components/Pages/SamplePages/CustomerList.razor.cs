using Microsoft.AspNetCore.Components;
using HogWildSystem.BLL;
using HogWildSystem.ViewModels;    // for CustomerService

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class CustomerList
    {
        #region Fields

        // The last name
        private string lastName;

        // The phone number
        private string phoneNumber;

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
        #endregion

        #region Properties
        // Injects the CustomerService dependency.
        [Inject]
        protected CustomerService CustomerService { get; set; }

        // Injects the NavigationManager dependency.
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        // Gets or sets the customers search view.
        protected List<CustomerSearchView> Customers { get; set; } = new();
        #endregion

        #region Methods

        //  search for an existing customer
        private void Search()
        {
            try
            {
                //  reset the error detail list
                errorDetails.Clear();

                //  reset the error message to an empty string
                errorMessage = string.Empty;

                //  reset feedback message to an empty string
                feedbackMessage = String.Empty;

                //  clear the customer list before we do our search
                Customers.Clear();

                if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phoneNumber))
                {
                    throw new ArgumentException("Please provide either a last name and/or phone number");
                }

                Customers = CustomerService.GetCustomers(lastName, phoneNumber);
                if (Customers.Count > 0)
                {
                    feedbackMessage = "Search for customer(s) was successful";
                }
                else
                {
                    feedbackMessage = "No customer were found for your search criteria";
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

        //  new customer
        private void New()
        {

        }

        //  edit selected customer
        private void EditCustomer(int customerID)
        {

        }

        //  new invoice for selected customer
        private void NewInvoice(int customerID)
        {

        }

        #endregion
    }
}
