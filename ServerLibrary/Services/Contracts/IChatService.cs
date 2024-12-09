using BaseLibrary.DTOs;

namespace ServerLibrary.Service.Contracts
{
    public interface IChatService
    {
        Task SaveMessageAsync(MessageDTO messageDTO);
        Task<IEnumerable<MessageDTO>> GetRecentMessagesAsync();
    }
}
