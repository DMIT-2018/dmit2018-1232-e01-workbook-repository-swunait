using Microsoft.AspNetCore.Components;
using HogWildSystem.BLL;    // for CustomerService

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class CustomerList
    {
        #region fields

        private string lastName;
        private string phoneNumber;
        private string feedbackMessage;
        private string errorMessage;

        private bool hasFeedback => !string.IsNullOrWhiteSpace(feedbackMessage);
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);
        private List<string> errorDetails = new();

        #endregion

        #region properties
        [Inject]
        //protected CustomerS

        #endregion
    }
}
