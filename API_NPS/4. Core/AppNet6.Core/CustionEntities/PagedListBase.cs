using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Core.CustionEntities
{
    public class PagedListBase
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Url { get; set; }
    }
}
