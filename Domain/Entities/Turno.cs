using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities {

    public class Turno {
        public int TurnoId { get; set; }
        [Required]
        public int PacienteId { get; set; }
        public int MedicoDerivacionId { get; set; }
        [StringLengthAttribute(32)]
        [Required]
        public string Estado { get; set; }
        [Required]
        public DateTime FechaHoraTurno { get; set; }
 
        public int AgendaId { get; set; }
        public Agenda Agendas { get; set; }
    }
}