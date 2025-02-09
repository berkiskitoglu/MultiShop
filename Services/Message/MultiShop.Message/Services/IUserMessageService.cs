using MultiShop.Message.Dtos;

namespace MultiShop.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIDMessageDto> GetByIDMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverID(string id);

        
    }
}
