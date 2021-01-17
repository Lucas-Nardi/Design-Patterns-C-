using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran.PontosCarteira
{
    public abstract class DetranVerificadorPontosCarteiraRepositoryCrawlerBase : IDetranVerificadorPontosCarteiraRepository
    {
        public async Task<IEnumerable<PontoCarteira>> ConsultarPontosCarteira(string cpf)
        {
            var html = await RealizarAcesso(cpf);
            return await PadronizarResultado(html);
        }               

        protected abstract Task<string> RealizarAcesso(string cpf);

        protected abstract Task<IEnumerable<PontoCarteira>> PadronizarResultado(string html);
        
    }
}
