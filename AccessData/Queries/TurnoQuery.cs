
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain.DTOs;
using Domain.Queries;


namespace AccessData.Queries {

    public class TurnoQuery : ITurnoQuery {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public TurnoQuery(IDbConnection connection, Compiler sqlKataCompiler) {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<TurnoDto> SearchTurno(string search_q) {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Select("TurnoId",
                        "PacienteId",
                        "MedicoDerivacionId",
                        "Estado",
                        "FechaHoraTurno",
                        "AgendaId");
                // .When(!string.IsNullOrWhiteSpace(search_q), q => q
                //     .WhereLike("Nombre", $"%{search_q}%")
                //     .OrWhereLike("Apellido", $"%{search_q}%")
                    // );

            var result = query.Get<TurnoDto>();

            return result.ToList();
        }

    }
}