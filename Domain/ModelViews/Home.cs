using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Domain.ModelViews
{
    public struct Home
    {
        public string Doc {get => "/swagger"; }
        public string Mensagem {get => "Bem vindo a Api de veículos - minimal api"; }
    }
}