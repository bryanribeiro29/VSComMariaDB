using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public List<Pessoa> GetLista()
        {
            var _DbContext = new _DbContext();
            var vLista = _DbContext.Pessoa.ToList();

            return vLista;
        }

        ///<summary>
        /// Pegar os dados de uma pessoa especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        public Pessoa GetPessoa(int id) 
        {
            //Intanciar o banco de dados
            var _DbContext = new _DbContext();

            //Selecionar a Pessoa pelo id
            /*var vPessoa = _DbContext.Pessoa
                .Where(p => p.Id == id)
                .FirstOrDefault();*/

            var vPessoa = _DbContext.Pessoa.Find(id);

            //retornar dos dados
            return vPessoa;
        }

        [HttpPost]
        public Pessoa Inserir(Pessoa pessoa) 
        {
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Add(pessoa);
            _DbContext.SaveChanges();

            return pessoa;
        }

        [HttpPut]
        public Pessoa Alterar(Pessoa pessoa) 
        {
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            _DbContext.SaveChanges();

            return pessoa;
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();
            //localizar o registro a ser removido pelo id
            var vPessoa = _DbContext.Pessoa.Find(id);
            //Remover o registro encontrado
            _DbContext.Pessoa.Remove(vPessoa);
            //Salvar alterações
            _DbContext.SaveChanges();

            return Ok();
        }

    }
}
