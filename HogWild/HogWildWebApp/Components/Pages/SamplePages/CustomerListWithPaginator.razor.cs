using Microsoft.AspNetCore.Components;
using HogWildSystem.BLL;
using HogWildSystem.ViewModels;
using DMIT2018.Paginator;
using System.Security.Cryptography;    // for CustomerService

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class CustomerListWithPaginator
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

        #region Paginator
        private const int PAGE_SIZE = 10;
        protected string SortField { get; set; } = "Owner";
        protected string Direction { get; set; } = "desc";
        protected int CurrentPage { get; set; } = 1;
        protected PagedResult<CustomerSearchView> PaginatorCustomerSearch { get; set; } = new();

        private async void Sort(string column)
        {
            Direction = SortField == column ? Direction == "asc" ? "desc" : "asc" : "asc";
            SortField = column;
            await Search();
        }
        private string GetSortColumn(string x)
        {
            return x == SortField ? Direction == "desc" ? "desc" : "asc" : "";
        }
        private string SetSortIcon(string columnName)
        {
            if (SortField != columnName)
            {
                return "fa fa-sort";
            }
            if (Direction == "asc")
            {
                return "fa fa-sort-up";
            }
            else
            {
                return "fa fa-sort-down";
            }
        }

        #endregion

        #region Properties
        // Injects the CustomerService dependency.
        [Inject]
        protected CustomerService CustomerService { get; set; }

        // Injects the NavigationManager dependency.
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        // Gets or sets the customers search view.
        //protected List<CustomerSearchView> Customers { get; set; } = new();
        #endregion

        #region Methods

        //  search for an existing customer
        private async Task Search()
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
                //Customers.Clear();
            

                if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phoneNumber))
                {
                    throw new ArgumentException("Please provide either a last name and/or phone number");
                }

                PaginatorCustomerSearch = await CustomerService.GetCustomers(
                    lastName, phoneNumber,
                    CurrentPage, PAGE_SIZE, SortField, Direction);
                await InvokeAsync(StateHasChanged);

                if (PaginatorCustomerSearch.Results.Length > 0)
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
            NavigationManager.NavigateTo("/SamplePages/CustomerEdit/0");
        }

        //  edit selected customer
        private void EditCustomer(int customerID)
        {
            NavigationManager.NavigateTo($"/SamplePages/CustomerEdit/{customerID}");
        }

        //  new invoice for selected customer
        private void NewInvoice(int customerID)
        {

        }

        #endregion
    }
}
