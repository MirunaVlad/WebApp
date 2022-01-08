using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Models
{
    public class Reviews
    {
        public List<Antrenor> Antrenors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Client> Clients { get; set; }
    }
}