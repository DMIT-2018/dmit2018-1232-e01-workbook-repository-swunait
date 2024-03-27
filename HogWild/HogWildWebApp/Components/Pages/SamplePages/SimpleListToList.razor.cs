#nullable disable
using HogWildSystem.BLL;
using HogWildSystem.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class SimpleListToList
    {
        #region Inject
        //  We are now injecting our service into our class using the [Inject] attribute.
        [Inject] protected PartService? PartService { get; set; }
        #endregion

        #region properties
        //  list of our current available songs
        public List<PartView> Inventory { get; set; } = new();

        //  shopping cart
        public List<InvoiceLineView> ShoppingCart { get; set; } = new();
        #endregion

        //  page load and retrieving Inventory
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Inventory = PartService.GetParts(22, "", new List<int>());
            await InvokeAsync(StateHasChanged);
        }

        //  add tracks from Inventory to shopping cart
        private async Task AddPartToCart(int partID)
        {
            PartView part = Inventory
                .Where(x => x.PartID == partID)
                .Select(x => x)
                .FirstOrDefault();
            InvoiceLineView invoiceLine = new InvoiceLineView()
            {
                PartID = part.PartID,
                Description = part.Description,
                Price = part.Price,
                Quantity = 0,
                Taxable = part.Taxable
            };
            ShoppingCart.Add(invoiceLine);
            Inventory.Remove(part);
            await InvokeAsync(StateHasChanged);
        }

        private async Task RemovePartFromCart(int partID)
        {
            Inventory.Add(PartService.GetPart(partID));
            Inventory = Inventory
                .OrderBy(x => x.Description)
                .Select(x => x)
                .ToList();
            InvoiceLineView invoiceLine =
                ShoppingCart
                    .Where(x => x.PartID == partID)
                    .Select(x => x)
                    .FirstOrDefault();
            ShoppingCart.Remove(invoiceLine);
            await InvokeAsync(StateHasChanged);
        }
    }
}
