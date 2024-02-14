using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {   
        [HttpGet("ListaAsync")]
        public async Task<List<Produto>> GetListaAsync()
        {
            var _dbContext = new _DbContext();

            var vLista = await _dbContext.Produto.ToListAsync();

            return vLista;
        }

        [HttpGet("{id}")]
        public async Task<Produto> GetProduto(int id)
        {
            var _dbContext = new _DbContext();

            var vLista = await _dbContext.Produto.FindAsync(id);

            return vLista;
        }


        [HttpPost]
        public async Task<Produto> Inserir(Produto produto)
        {
            var _DbContext = new _DbContext();

            await _DbContext.Produto.AddAsync(produto);
            await _DbContext.SaveChangesAsync();

            return produto;
        }

        [HttpPut]
        public async Task<Produto> Alterar(Produto produto)
        {
            var _dbContext = new _DbContext();

            _dbContext.Produto.Entry(produto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();

            //Localizar o registro encontrado
            var vProduto = _DbContext.Produto.Find(id);

            //Remover o registro encontrado
            _DbContext.Produto.Remove(vProduto);

            //Salvar alterações
            await _DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
