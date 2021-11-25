namespace ShopApp.Services.Abstractions
{
    public interface IActionsService
    {
        bool CreateInfoLog();
        bool CreateWarningLog();
        bool CreateErrorLog();
    }
}
