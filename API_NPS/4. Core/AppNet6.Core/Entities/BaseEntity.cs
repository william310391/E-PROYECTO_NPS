﻿
namespace AppNet6.Core.Entities
{
    public class BaseEntity
    {     
        public int Id { get; set; }
        public bool IndActivo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
