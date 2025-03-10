using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Dashboard;
using RentFleet.Domain.Entities;

namespace RentFleet.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [Authorize(Roles = "ADM,USR")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<DashboardDTO>> GetDashboardData(int ano, int mes)
        {
            var data = await _mediator.Send(new GetDashboardDataQuery(ano, mes));
            return Ok(data);
        }

        [HttpGet("locacoes/{ano}/{mes}")]
        public async Task<ActionResult<List<LocacaoVeiculo>>> GetLocacoesPorMes(int ano, int mes)
        {
            var locacoes = await _mediator.Send(new GetLocacoesPorMesQuery(ano, mes));
            return Ok(locacoes);
        }
    }

}
