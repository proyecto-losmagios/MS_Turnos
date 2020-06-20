using System;
using Domain.Entities;


namespace Domain.DTOs {

    public class AgendaDto {
        public int AgendaId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
    }
}