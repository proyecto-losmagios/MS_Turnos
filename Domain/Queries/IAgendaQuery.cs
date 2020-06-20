
using System.Collections.Generic;
using Domain.DTOs;


namespace Domain.Queries {

    public interface IAgendaQuery {
        List<AgendaDto> SearchAgenda(string q); 
    }

}