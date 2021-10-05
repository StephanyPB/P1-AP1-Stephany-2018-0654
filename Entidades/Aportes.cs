using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Stephany_2018_0654.Entidades
{
    public class Aportes
    {
        [Key]
        public int aporteID { get; set; }
        public DateTime fecha { get; set; }
        public String persona { get; set; }
        public String concepto { get; set; }
        public float monto { get; set; }

        public Aportes()
        {
            aporteID = 0;
            fecha = DateTime.Now;
            persona = string.Empty;
            concepto = string.Empty;
            monto = 0;
        }
    }
}
