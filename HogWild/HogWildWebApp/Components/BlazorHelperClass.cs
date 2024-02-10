namespace HogWildWebApp.Components
{
    public static class BlazorHelperClass
    {
        public static Exception GetInnerException(Exception ex)
        {
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
