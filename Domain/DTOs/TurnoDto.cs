using System;
using Domain.Entities;


namespace Domain.DTOs {

    public class TurnoDto {
        public int TurnoId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoDerivacionId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public int AgendaId { get; set; }

    }
}