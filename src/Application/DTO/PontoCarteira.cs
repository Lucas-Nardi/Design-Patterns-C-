using System;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class PontoCarteira
    {
        public string Cpf_Motorista { get; set; }
        public double Valor { get; set; }
    }
}