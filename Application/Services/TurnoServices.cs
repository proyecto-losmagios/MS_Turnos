using Domain.Commands;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Queries;


namespace Application.Services {

    public interface ITurnoServices {
        Turno CreateTurno(TurnoDto turno);
        List<TurnoDto> SearchTurno(string q);
    }

    public class TurnoServices : ITurnoServices {

        private readonly IGenericsRepository _repository;
        private readonly ITurnoQuery _query;

        public TurnoServices(IGenericsRepository repository, ITurnoQuery query) {
            _repository = repository;
            _query = query;
            
        }

        public Turno CreateTurno(TurnoDto turno) {
            var entity = new Turno {
                PacienteId = turno.PacienteId,
                MedicoDerivacionId = turno.MedicoDerivacionId,
                Estado = turno.Estado,
                FechaHoraTurno = turno.FechaHoraTurno,
                AgendaId = turno.AgendaId

            };

            _repository.Add<Turno>(entity);

            return entity;
        }
               
        public List<TurnoDto> SearchTurno(string q) {
           return  _query.SearchTurno(q);
        }
    }
}