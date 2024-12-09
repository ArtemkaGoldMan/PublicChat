using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class MessageDTO
    {
        public string Content { get; set; } // Message content
        public string Nickname { get; set; } // User's nickname
        public DateTime Timestamp { get; set; } // When the message was sent
    }
}
