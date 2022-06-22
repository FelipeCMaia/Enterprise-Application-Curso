using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
            _httpClient = httpClient;
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho/");

            TratarErrosResponse(response);

            var carrinho = await DeserializarObjetoResponse<CarrinhoViewModel>(response);

            return carrinho;
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto)
        {
            var itemContent = ObterConteudo(produto);

            var response = await _httpClient.PostAsync("/carrinho/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto)
        {
            var itemContent = ObterConteudo(produto);

            var response = await _httpClient.PutAsync($"/carrinho/{produto.ProdutoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }        

        //public Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
