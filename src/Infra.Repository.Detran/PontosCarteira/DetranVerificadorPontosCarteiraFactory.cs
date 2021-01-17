using DesignPatternSamples.Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Infra.Repository.Detran.PontosCarteira
{
   public class DetranVerificadorPontosCarteiraFactory : IDetranVerificadorPontosCarteiraFactory
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly IDictionary<string, Type> _Repositories = new Dictionary<string, Type>();


        public DetranVerificadorPontosCarteiraFactory(IServiceProvider serviceProvider)
        {
            this._ServiceProvider = serviceProvider;
        }

        public IDetranVerificadorPontosCarteiraRepository Create(string CPF)
        {
            IDetranVerificadorPontosCarteiraRepository result = null;

            if (_Repositories.TryGetValue(CPF, out Type type))
            {
                result = _ServiceProvider.GetService(type) as IDetranVerificadorPontosCarteiraRepository;
            }

            return result;
        }

        public IDetranVerificadorPontosCarteiraFactory Register(string CPF, Type repository)
        {
            if (!_Repositories.TryAdd(CPF, repository))
            {
                Console.WriteLine("REGISTREI UMA CPF -----------------------------------------------------------");

                _Repositories[CPF] = repository;
            }
            return this;
        }
    }
}
