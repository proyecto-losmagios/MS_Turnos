
using System.Collections.Generic;
using Domain.DTOs;


namespace Domain.Queries {

    public interface ITurnoQuery {
        List<TurnoDto> SearchTurno(string q); 
    }

}