namespace HogWildWebApp.Components.SamplePages
{
    public partial class TextBoxesDemo
    {
        #region Text Boxes
        //  email address
        private string emailText;
        //  password
        private string passwordText;
        //  date 
        private DateTime? dateText = DateTime.Today;
        #endregion

        //  used to display any feedback to the end user.
        private string feedback;

        //  This method is called when a user submits text input.
        private void TextSubmit()
        {
            // Combine the values of emailText, passwordText, and dateText into a feedback message.
            feedback = $"Email {emailText}; Password {passwordText}; Date {dateText}";

            // Trigger a re-render of the component to reflect the updated feedback.
            //InvokeAsync(StateHasChanged);
        }

    }
}
