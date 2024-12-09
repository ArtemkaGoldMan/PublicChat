using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Service.Contracts;

namespace ServerLibrary.Service.Implementations
{
    public class ChatService : IChatService
    {
        private readonly AppDbContext _dbContext;

        public ChatService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveMessageAsync(MessageDTO messageDTO)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname == messageDTO.Nickname);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var message = new Message
            {
                Content = messageDTO.Content,
                UserId = user.Id,
                Timestamp = DateTime.UtcNow
            };

            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageDTO>> GetRecentMessagesAsync()
        {
            var messages = await _dbContext.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.Timestamp)
                .Take(50)
                .ToListAsync();

            return messages.Select(m => new MessageDTO
            {
                Content = m.Content,
                Nickname = m.User.Nickname,
                Timestamp = m.Timestamp
            });
        }
    }
}
