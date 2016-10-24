using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoPOC.DAL
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public int Ramal { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
