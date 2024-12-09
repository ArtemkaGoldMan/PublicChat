using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation property for the user who sent this message
        public User User { get; set; }
    }
}
