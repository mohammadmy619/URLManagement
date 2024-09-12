using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UrlModel
{
    public class Url:BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string description { get; set; }


    }
}
