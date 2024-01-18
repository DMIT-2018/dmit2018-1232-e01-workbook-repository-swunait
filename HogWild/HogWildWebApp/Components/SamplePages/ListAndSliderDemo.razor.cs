using HogWildWebApp.Data.ViewModels;

namespace HogWildWebApp.Components.SamplePages
{
    public partial class ListAndSliderDemo
    {
        #region List and Sliders

        //  pretend tat the following collection is data from a database
        //  The collection is based on a 2 property class called SelectionList
        //  The data for the list will be created in a separate method.
        /// <summary>
        /// Gets or sets a list of SelectionView objects representing various rides.
        /// </summary>
        private List<SelectionView> rides;

        /// <summary>
        /// Gets or sets the ID of the selected ride from the rides list.
        /// </summary>
        private int myRide;

        /// <summary>
        /// Gets or sets the user's chosen vacation spot as a string.
        /// </summary>
        private string vacationSpot;

        /// <summary>
        /// Gets or sets a list of strings representing various vacation spots.
        /// </summary>
        private List<string> vacationSpots;

        /// <summary>
        /// Gets or sets the review rating.
        /// </summary>
        //  The review rating
        private int reviewRating = 5;
        #endregion

        //  used to display any feedback to the end user.
        private string feedback;

        protected override Task OnInitializedAsync()
        {
            // Call the 'PopulatedList' method to populate predefined data for the list.
            PopulatedList();

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// Populates the 'rides' list and 'vacationSpots' list with predefined data.
        /// </summary>
        private void PopulatedList()
        {
            int i = 1;

            // Create a pretend collection from the database representing different types
            // of transportation (rides).
            rides = new List<SelectionView>();
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Car" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Bus" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Bike" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Motorcycle" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Boat" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Plane" });

            // Sort the 'rides' list alphabetically based on the 'DisplayText' property.
            rides.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

            // Initialize and populate the 'vacationSpots' list with predefined vacation destinations.
            vacationSpots = new List<string>();
            vacationSpots.Add("California");
            vacationSpots.Add("Caribbean");
            vacationSpots.Add("Cruising");
            vacationSpots.Add("Europe");
            vacationSpots.Add("Florida");
            vacationSpots.Add("Mexico");
        }

        /// <summary>
        /// This method is called when the user submits the list and slider form.
        /// It gathers user selections for 'myRide,' 'vacationSpot,' and 'reviewRating,'
        /// and generates feedback based on these selections.
        /// </summary>
        private void ListSliderSubmit()
        {
            // Generate feedback string incorporating the selected values.
            feedback = $"Ride {myRide}; Vacation {vacationSpot}; Review Rating {reviewRating}";

            // Invoke asynchronous method 'StateHasChanged' to trigger a re-render of the component.
            InvokeAsync(StateHasChanged);
        }
    }
}
