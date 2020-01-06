using AutoMapper;
using EST.DTI.App.Api.ViewModel;
using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var list = _mapper.Map<List<ProdutoViewModel>>(_servicoProdutos.ObterVarios(x => x.Ativo).ToList().OrderBy(x => x.Descricao));
            return list;
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        public ActionResult<ProdutoViewModel> ObterPorId([FromRoute]int id)
        {
            var obj = _mapper.Map<ProdutoViewModel>(_servicoProdutos.Obter(id));
            return obj;
        }

        [HttpDelete]
        [Route("ExcluirPorId/{id}")]
        public ActionResult<ProdutoViewModel> ExcluirPorId([FromRoute]int id)
        {
            var obj = _mapper.Map<ProdutoViewModel>(_servicoProdutos.Obter(id));
            try
            {
                _servicoProdutos.Deletar(id);
                obj = _mapper.Map<ProdutoViewModel>(_servicoProdutos.Obter(id));
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public ActionResult<ProdutoViewModel> Atualizar([FromRoute]int id, [FromBody] ProdutoViewModel produto)
        {
            try
            {
                var obj = _servicoProdutos.Obter(id);
                obj.Descricao = produto.Descricao;
                obj.Quantidade = produto.Quantidade;
                obj.ValorUnidade = produto.ValorUnidade;
                _servicoProdutos.Atualizar(obj);
                return produto;
            }
            catch
            {
                return produto;
            }
        }

        [HttpPost]
        [Route("Criar/")]
        public ActionResult<ProdutoViewModel> Criar([FromBody] ProdutoViewModel vm)
        {
            var obj = _mapper.Map<Produto>(vm);
            try
            {
                _servicoProdutos.Adicionar(obj);
                return vm;
            }
            catch
            {
                return vm;
            }
        }
    }
}