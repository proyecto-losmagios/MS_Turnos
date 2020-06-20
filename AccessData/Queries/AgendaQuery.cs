using System.Collections.Concurrent;
using System.Reflection.Emit;

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

        public List<AgendaDto> SearchAgenda(DateTime from, DateTime to, int medico) {
            var db = new QueryFactory(connection, sqlKataCompiler);

            //  TODO Filtrar por fecha!
            var query = db.Query("Agendas")
                .Select("AgendaId",
                        "MedicoId",
                        "Fecha")
                .When(
                    !string.IsNullOrWhiteSpace(from.ToString()) &&
                      !string.IsNullOrWhiteSpace(to.ToString()) &&
                      !string.IsNullOrWhiteSpace(Convert.ToString(medico)), q => q
                        .Where("MedicoId", medico)
                        .WhereDate("Fecha", ">=", from)
                        .Where("Fecha", "<=", to)
                ).OrderBy("MedicoId").OrderBy("Fecha");

            var result = query.Get<AgendaDto>();

            return result.ToList();
        }

    }
}