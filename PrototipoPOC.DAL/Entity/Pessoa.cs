using System;
using System.Collections.Generic;

namespace PrototipoPOC.DAL
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
