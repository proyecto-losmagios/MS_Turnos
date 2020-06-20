
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain.DTOs;
using Domain.Queries;


namespace AccessData.Queries {

    public class AgendaQuery : IAgendaQuery {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public AgendaQuery(IDbConnection connection, Compiler sqlKataCompiler) {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<AgendaDto> SearchAgenda(string search_q) {
            var db = new QueryFactory(connection, sqlKataCompiler);

            //  TODO Filtrar por fecha!
            var query = db.Query("Agendas")
                .Select("AgendaId",
                        "MedicoId",
                        "Fecha");
                // .When(!string.IsNullOrWhiteSpace(search_q), q => q
                //     .WhereLike("Nombre", $"%{search_q}%")
                //     .OrWhereLike("Apellido", $"%{search_q}%")
                    // );

            var result = query.Get<AgendaDto>();

            return result.ToList();
        }

    }
}