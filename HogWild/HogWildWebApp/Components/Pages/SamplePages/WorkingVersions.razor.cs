using HogWildSystem.BLL; // for WorkingVersionsService
using HogWildSystem.ViewModels; // for WorkingVersionsView
using Microsoft.AspNetCore.Components; // for Inject

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class WorkingVersions
    {
        #region Fields
        //  Property for holding any feedback messages
        private string feedback;
        // This private field holds a reference to the WorkingVersionsView instance.
        private WorkingVersionsView workingVersionView = new WorkingVersionsView();
        #endregion

        #region Properties
        // This attribute marks the property for dependency injection.
        [Inject]
        // This property provides access to the 'WorkingVersionsService' service.
        protected WorkingVersionsService WorkingVersionsService { get; set; }
        #endregion

        #region Methods
        private void GetWorkingVersions()
        {
            try
            {
                workingVersionView = WorkingVersionsService.GetWorkingVersion();
            }
            catch (Exception ex)
            {
                feedback = GetInnerException(ex).Message;
            }
        }
        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
        #endregion

    }
}
