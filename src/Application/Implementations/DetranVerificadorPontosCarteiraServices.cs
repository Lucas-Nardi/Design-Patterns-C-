using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public class DetranVerificadorPontosCarteiraServices : IDetranVerificadorPontosCarteiraService
    {
        private readonly IDetranVerificadorPontosCarteiraFactory _Factory;

        public DetranVerificadorPontosCarteiraServices(IDetranVerificadorPontosCarteiraFactory factory)
        {
            _Factory = factory;
        }
               
        public Task<IEnumerable<PontoCarteira>> ConsultarPontos(string cpf)
        {
            IDetranVerificadorPontosCarteiraRepository repository = _Factory.Create(cpf);
            return repository.ConsultarPontosCarteira(cpf);
        }
    }
}
