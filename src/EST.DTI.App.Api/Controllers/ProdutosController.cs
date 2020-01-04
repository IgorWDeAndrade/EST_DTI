using EST.DTI.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EST.DTI.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IServicoProdutos _servicoProdutos;
        public ProdutosController(IServicoProdutos servicoProdutos)
        {
            _servicoProdutos = servicoProdutos;
        }

        // GET: api/Produtos
        [HttpGet]
        [Route("ObterTodos")]
        public IEnumerable<string> Get()
        {
            var objs = _servicoProdutos.ObterVarios(x => x.Ativo);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Produtos/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produtos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
