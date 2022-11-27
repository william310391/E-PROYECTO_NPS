using AppNet6.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Interfaces
{
    public interface IUrlService
    {
        Uri PaginationUri(ProductoQueryFilter filter, string actionUrl);
    }
}
