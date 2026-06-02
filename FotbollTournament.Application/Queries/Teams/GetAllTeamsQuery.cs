using FotbollTournament.Application.DTOs;
using FotbollTournament.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FotbollTournament.Application.Queries.Teams
{
    public record GetAllTeamsQuery : IRequest<IEnumerable<TeamDto>>;
    public record GetTeamByIdQuery(int Id) : IRequest<TeamDto?>;
}
