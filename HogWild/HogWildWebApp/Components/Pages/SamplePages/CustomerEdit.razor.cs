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
        //  list of invoices
        private List<InvoiceView> invoices = new List<InvoiceView>();
        //  Disable the new/edit buttons if we have unsave changes
        //  NOTE: This should be call disableAddEditInvoice buttons
        //          button the PowerPoint slides had already
        //          been created
        private bool disableViewButton => !disableSaveButton;

        #endregion

        #region Validation
        private string closeButtonText = "Close";
        // the edit context
        private EditContext editContext;

        //  disable save button
        private bool disableSaveButton => !editContext.IsModified() || !editContext.Validate();

        //  used to store the validation message
        private ValidationMessageStore messageStore;


        #endregion

        #region Feedback & Error Messages
        //  placeholder for feedback message
        private string feedbackMessage;

        //  placeholder for error messasge
        private string? errorMessage;

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

        //  The invoice service
        [Inject] protected InvoiceService InvoiceService { get; set; }

        //   Injects the NavigationManager dependency
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        // the dialog service
        //[Inject]
        //protected IDialogService DialogService { get; set; }

        //  Customer ID used to create or edit a customer
        [Parameter] public int CustomerID { get; set; } = 0;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            try
            {
                //  edit context needs to be setup after data has been initialized
                //  setup of the edit context to make use of the payment type property
                editContext = new EditContext(customer);

                //  set the validation to use the HandleValidationRequest event
                editContext.OnValidationRequested += HandleValidationRequested;

                //  setup the message store to track any validation messages
                messageStore = new ValidationMessageStore(editContext);

                //  this event will fire each time the data in a property has change.
                editContext.OnFieldChanged += EditContext_OnFieldChanged;

                //  reset the error detail list
                errorDetails.Clear();

                //  reset the error message to an empty string
                errorMessage = string.Empty;

                //  reset feedback message to an empty string
                feedbackMessage = String.Empty;


                //  check to see if we are navigating using a valid customer CustomerID.
                //      or are we going to create a new customer.
                if (CustomerID > 0)
                {
                    customer = CustomerService.GetCustomer(CustomerID);
                    invoices = InvoiceService.GetCustomerInvoices(CustomerID);
                }

                // lookups
                provinces = CategoryLookupService.GetLookups("Province");
                countries = CategoryLookupService.GetLookups("Country");
                statusLookup = CategoryLookupService.GetLookups("Customer Status");

                await InvokeAsync(StateHasChanged);
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

        // Handles the validation requested.        
        private void HandleValidationRequested(object sender, ValidationRequestedEventArgs e)
        {
            //  clear the message store if there is any existing validation errors.
            messageStore?.Clear();

            //  custom validation logic
            //  first name is required
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                messageStore?.Add(() => customer.FirstName, "First Name is required!");
            }
            //  last name is required
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                messageStore?.Add(() => customer.LastName, "Last Name is required!");
            }
            //  phone is required
            if (string.IsNullOrWhiteSpace(customer.Phone))
            {
                messageStore?.Add(() => customer.Phone, "Phone is required!");
            }
            //  email is required
            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                messageStore?.Add(() => customer.Email, "Email is required!");
            }
        }

        // Handles the OnFieldChanged event of the EditContext control.
        private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            //  the "editContext.Validate()" should not be needed
            //    but if the "HandleValidationRequested" does not fire on it own
            //    you will need to add it.  
            editContext.Validate();
            closeButtonText = editContext.IsModified() ? "Cancel" : "Close";
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
            NavigationManager.NavigateTo("/SamplePages/CustomerList");
        }

        /// New invoice.
        private void NewInvoice()
        {
            //  NOTE:   we will hard code employee ID (1)            
            NavigationManager.NavigateTo($"/SamplePages/InvoiceEdit/0/{CustomerID}/1");
        }

        /// <summary>
        /// Edit the invoice.
        /// </summary>
        /// <param name="invoiceID">The invoice identifier.</param>
        private void EditInvoice(int invoiceID)
        {
            //  NOTE:   we will hard code employee ID (1)            
            NavigationManager.NavigateTo($"/SamplePages/InvoiceEdit/{invoiceID}/{CustomerID}/1");
        }
    }
}
