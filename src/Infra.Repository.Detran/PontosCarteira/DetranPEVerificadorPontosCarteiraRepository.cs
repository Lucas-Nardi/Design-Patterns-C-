using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran.PontosCarteira
{
    public class DetranPEVerificadorPontosCarteiraRepository : DetranVerificadorPontosCarteiraRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPEVerificadorPontosCarteiraRepository(ILogger<DetranPEVerificadorDebitosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<PontoCarteira>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<PontoCarteira>>(new List<PontoCarteira>() { new PontoCarteira() });
        }

        protected override Task<string> RealizarAcesso(string cpf)
        {
            _Logger.LogDebug($"Consultando pontos da carteira da pessoa com o cpf {cpf} para o estado de PE.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/PE");
        }
    }
}
