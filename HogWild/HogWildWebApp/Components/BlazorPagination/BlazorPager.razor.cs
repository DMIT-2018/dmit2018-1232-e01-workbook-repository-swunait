using Microsoft.AspNetCore.Components;
// https://github.com/villainoustourist/Blazor.Pagination/tree/master

namespace HogWildWebApp.BlazorPagination
{
    public partial class BlazorPager : ComponentBase
    {
        [Parameter] public bool Visible { get; set; }
        [Parameter] public int PageCount { get; set; }

        [Parameter] public int CurrentPage { get; set; }

        [Parameter]
        public Func<int, Task> OnPageChanged { get; set; } = null;

        [Parameter] public bool ShowFirstLast { get; set; } = false;

        [Parameter] public bool ShowPageNumbers { get; set; } = true;

        [Parameter] public string FirstText { get; set; } = "First";

        [Parameter] public string LastText { get; set; } = "Last";

        [Parameter] public string PreviousText { get; set; } = "Previous";

        [Parameter] public string NextText { get; set; } = "Next";

        [Parameter] public int VisiblePages { get; set; } = 5;

        private void PagerButtonClicked(int page)
        {
            OnPageChanged?.Invoke(page);
        }
    }
}
