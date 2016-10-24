using PrototipoPOC.DAL;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototipoPOC.Web
{
    public class PessoaService : Service
    {
        public PessoaRepository Repository { get; set; }

        

        public object Get(Pessoa request)
        {
            base.Response.ContentType = ContentType.Json;
            var context = new EntitiesContext();
            var rep = new PessoaRepository(context);

            if (!string.IsNullOrEmpty(request.Nome))
            {
                return new HttpResult(rep.ListarPessoas(p => p.Nome.Contains(request.Nome)), ContentType.Json); 
            }
            else if (request.Id > 0)
            {
                return new HttpResult(rep.ListarPessoas(p => p.Id == request.Id).FirstOrDefault(), ContentType.Json);
            }
            else
                return new HttpResult(rep.ListarPessoas(p => true), ContentType.Json); ;
        }

        public object Post(Pessoa pessoa)
        {
            return Repository.GravarPessoa(pessoa);
        }

        public object Put(Pessoa todo)
        {
            return Repository.AtualizarPessoa(todo);
        }

        public void Delete(Pessoa request)
        {
            Repository.ExcluirPessoa(request);
        }

      
    }
}