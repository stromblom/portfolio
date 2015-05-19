using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stromblom.Portfolio.Database.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
    }
}
