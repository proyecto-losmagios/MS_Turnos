using System;

using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Domain.DTOs;


namespace Domain.Queries {

    public interface IAgendaQuery {
        List<AgendaDto> SearchAgenda(DateTime from, DateTime to, int medico); 
    }

}