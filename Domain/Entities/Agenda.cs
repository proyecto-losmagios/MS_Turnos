using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Domain.Entities {

    public class Agenda {
        public int AgendaId { get; set; }
        [Required]
        public int MedicoId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<Turno> Turnos { get; set; }
    }
}