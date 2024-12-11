using BaseLibrary.DTOs;
using Microsoft.AspNetCore.SignalR;
using ServerLibrary.Service.Contracts;

namespace ServerLibrary.Service.Implementations
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IUserService _userService;

        public ChatHub(IChatService chatService, IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
        }

        public async Task SendMessage(MessageDTO messageDTO)
        {

            var user = await _userService.GetOrCreateUserAsync(messageDTO.Nickname);

            await _chatService.SaveMessageAsync(new MessageDTO
            {
                Content = messageDTO.Content,
                Nickname = user.Nickname,
                Timestamp = DateTime.UtcNow
            });

            await Clients.All.SendAsync("ReceiveMessage", messageDTO);
        }

        public async Task<IEnumerable<MessageDTO>> GetRecentMessages()
        {
            return await _chatService.GetRecentMessagesAsync();
        }
    }
}
