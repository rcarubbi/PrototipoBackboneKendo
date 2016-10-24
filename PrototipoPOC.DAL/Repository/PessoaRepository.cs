using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoPOC.DAL
{
    public class PessoaRepository 
    {

        private EntitiesContext _context = null;
        public PessoaRepository(EntitiesContext context)
        {
            if (context == null)
                throw new ArgumentException("Contexto não informado");

            _context = context;
        
        }

        public IEnumerable<Pessoa> ListarPessoas(Predicate<Pessoa> filtro)
        {
            foreach (var pessoa in _context.Pessoas)
            {
                if (filtro(pessoa)) yield return pessoa;
            }
        }

        public Pessoa GravarPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Remove(_context.Pessoas.SingleOrDefault(p => p.Id == pessoa.Id));
            _context.SaveChanges();
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            var pessoaAAlterar = _context.Pessoas.SingleOrDefault(p => p.Id == pessoa.Id);
            pessoaAAlterar = pessoa;
            _context.SaveChanges();
            return pessoa;
        }


    
    }
}
