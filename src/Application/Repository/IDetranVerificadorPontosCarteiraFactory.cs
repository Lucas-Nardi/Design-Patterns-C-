using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificadorPontosCarteiraFactory
    {
        public IDetranVerificadorPontosCarteiraFactory Register(string CPF, Type repository);
        public IDetranVerificadorPontosCarteiraRepository Create(string CPF);
    }
}
