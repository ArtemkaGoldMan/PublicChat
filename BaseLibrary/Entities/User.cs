using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        // Navigation property for the messages this user has sent
        public ICollection<Message> Messages { get; set; }
    }
}
