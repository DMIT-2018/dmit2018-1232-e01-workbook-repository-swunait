namespace HogWildWebApp.Data.ViewModels
{
    /// <summary>
    /// Represents a selection view item, typically used in user interfaces.
    /// </summary>
    public class SelectionView
    {
        /// <summary>
        /// Gets or sets the unique identifier for this selection view item.
        /// </summary>
        public int ValueID { get; set; }

        /// <summary>
        /// Gets or sets the text displayed for this selection view item.
        /// </summary>
        public string DisplayText { get; set; }
    }
}
