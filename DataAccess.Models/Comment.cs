using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string UserName { get; set; }
        
        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
