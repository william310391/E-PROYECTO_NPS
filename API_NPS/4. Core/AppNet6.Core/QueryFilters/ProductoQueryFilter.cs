using AppNet6.Core.CustionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Core.QueryFilters
{
    public class ProductoQueryFilter : PagedListBase
    {
        public int? idUsuario { get; set; }
        public DateTime? fecha { get; set; }
        public string? descripcion { get; set; }


    }
}
