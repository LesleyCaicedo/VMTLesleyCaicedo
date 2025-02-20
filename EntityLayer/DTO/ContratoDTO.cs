using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ContratoDTO
    {
        public int Contractid { get; set; }

        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public int? ServiceServiceid { get; set; }

        public int? StatuscontactStatusid { get; set; }

        public int? ClientClientid { get; set; }

        public int? MethodpaymentMethodpaymentid { get; set; }
    }
}
