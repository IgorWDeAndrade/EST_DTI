using AutoMapper;
using EST.DTI.App.Api.ViewModels;
using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EST.DTI.App.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IServicoProdutos _servicoProdutos;
        private readonly IMapper _mapper;
        public ProdutosController(
            IServicoProdutos servicoProdutos,
            IMapper mapper)
        {
            _servicoProdutos = servicoProdutos;
            _mapper = mapper;
        }

        // GET: api/Produtos
        [HttpGet]
        [Route("ObterTodos")]
        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            var list = _mapper.Map<List<ProdutoViewModel>>(_servicoProdutos.ObterVarios(x => x.Ativo));
            return list;
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        public ProdutoViewModel ObterPorId(int id)
        {
            var obj = _mapper.Map<ProdutoViewModel>(_servicoProdutos.Obter(id));
            return obj;
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
