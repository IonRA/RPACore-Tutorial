using System;
using System.Collections.Generic;
using System.Text;

namespace Rpa.Domain.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
