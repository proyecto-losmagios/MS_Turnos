using Domain.Commands;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Queries;


namespace Application.Services {

    public interface IAgendaServices {
        Agenda CreateAgenda(AgendaDto agenda);
        List<AgendaDto> SearchAgenda(string q);
    }

    public class AgendaServices : IAgendaServices {

        private readonly IGenericsRepository _repository;
        private readonly IAgendaQuery _query;

        public AgendaServices(IGenericsRepository repository, IAgendaQuery query) {
            _repository = repository;
            _query = query;
            
        }

        public Agenda CreateAgenda(AgendaDto agenda) {
            var entity = new Agenda {
                AgendaId = agenda.AgendaId,
                MedicoId = agenda.MedicoId,
                Fecha = agenda.Fecha,
            };

            _repository.Add<Agenda>(entity);

            return entity;
        }
               
        public List<AgendaDto> SearchAgenda(string q) {
           return  _query.SearchAgenda(q);
        }
    }
}