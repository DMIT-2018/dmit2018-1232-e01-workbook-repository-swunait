using Microsoft.AspNetCore.Components;

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class RadioButtonCheckBoxTextAreaDemo
    {
        #region Radio Buttons, Checkboxes & Text Area
        //  selected meal
        private string meal;
        private string[] meals = new string[] { "breakfast", "lunch", "dinner", "snacks" };
        //  used to hold the value of the acceptance
        private bool acceptanceBox;
        // used to hold the value for the message body
        private string messageBody;
        #endregion

        //  used to display any feedback to the end user.
        private string feedback = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            meal = meals[2]; // dinner
        }

        // Handle the selection of the loop meal
        private void HandleMealSelection(ChangeEventArgs e)
        {
            meal = e.Value.ToString();
        }

        //  This method is called when a user submits radio, check box and area text.
        private void RadioCheckAreaSubmit()
        {
            // Combine various values and store them in the 'feedback' variable as a formatted string.
            feedback = $"Meal {meal}; Acceptance {acceptanceBox}; Message {messageBody}";

            // Trigger a UI update to reflect the changes made to the 'feedback' variable.
            //InvokeAsync(StateHasChanged);
        }
    }
}
