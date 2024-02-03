namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class RandomValue
    {
        #region Define data fields
        private string? myName;
        private int oddEvenValue;

        #endregion

        private void GenerateRandomValue()
        {
            oddEvenValue = Random.Shared.Next(0, 25);
            if (oddEvenValue % 2 == 0)
            {
                myName = $"James is even {oddEvenValue}";
            } 
            else
            {
                myName = null;
            }

            //InvokeAsync(StateHasChanged);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            GenerateRandomValue();
        }

    }
}
