using HogWildSystem.ViewModels;

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class SimpleNonIndexList
    {
        #region Fields
        protected List<CustomerEditView> Customers { get; set; } = new();
        private string customerName { get; set; }
        #endregion

        private void RemoveCustomer(int employeeId)
        {
            var selectedItem =
                Customers.FirstOrDefault(x => x.CustomerID == employeeId);
            if (selectedItem != null)
            {
                Customers.Remove(selectedItem);
            }
        }

        private async Task AddCustomerToListBad()
        {
            Customers.Add(new CustomerEditView()
            {
                CustomerID = Customers.Count() + 1,
                FirstName = customerName
            });
            await InvokeAsync(StateHasChanged);
        }

        private async Task AddCustomerToList()
        {
            int maxID = Customers.Count == 0
                ? 1
                : Customers.Max(x => x.CustomerID) + 1;
            Customers.Add(new CustomerEditView()
            {
                CustomerID = maxID,
                FirstName = customerName
            });
            await InvokeAsync(StateHasChanged);
        }
    }
}
