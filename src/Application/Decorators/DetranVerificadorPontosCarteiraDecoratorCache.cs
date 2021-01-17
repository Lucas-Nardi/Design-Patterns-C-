using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;


namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosCarteiraDecoratorCache : IDetranVerificadorPontosCarteiraService
    {
        private readonly IDetranVerificadorPontosCarteiraService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorPontosCarteiraDecoratorCache(
            IDetranVerificadorPontosCarteiraService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }
              

        public Task<IEnumerable<PontoCarteira>> ConsultarPontos(string cpf)
        {

            return Task.FromResult(_Cache.GetOrCreate($"{cpf}", () => _Inner.ConsultarPontos(cpf).Result));
        }
    }
}
