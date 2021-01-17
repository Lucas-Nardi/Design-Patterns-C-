using AutoMapper;
using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using DesignPatternSamples.WebAPI.Models;
using DesignPatternSamples.WebAPI.Models.Detran;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternSamples.WebAPI.Controllers.Detran
{
    [Route("api/Detran/[controller]")]
    [ApiController]
    public class PontoCarteiraController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IDetranVerificadorPontosCarteiraService _DetranVerificadorPontosCarteiraServices;

        public PontoCarteiraController(IMapper mapper, IDetranVerificadorPontosCarteiraService detranVerificadorPontosCarteiraServices)
        {
            _Mapper = mapper;
            _DetranVerificadorPontosCarteiraServices = detranVerificadorPontosCarteiraServices;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResultModel<IEnumerable<PontoCarteiraModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get([FromQuery] string cpf)
        {
            var pontos = await _DetranVerificadorPontosCarteiraServices.ConsultarPontos(_Mapper.Map<string>(cpf));
                  
            var result = new SuccessResultModel<IEnumerable<PontoCarteiraModel>>(_Mapper.Map<IEnumerable<PontoCarteiraModel>>(pontos));

            return Ok(result);
        }
    }
}
