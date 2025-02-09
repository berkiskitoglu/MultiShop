namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverID(string id);

    }
}
