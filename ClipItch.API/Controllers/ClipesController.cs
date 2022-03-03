using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClipItch.API.Configuration;
using ClipItch.API.Interface;
using ClipItch.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ClipItch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClipesController : Controller
    {
        private readonly IClipeInterface _clipeInterface;
        private readonly Conexao _conexao;

        public ClipesController(IClipeInterface clipeInterface)
        {
            _clipeInterface = clipeInterface;
            _conexao = new Conexao();
        }
        
        [HttpGet("obterTodos")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                TokenViewModel tokenViewModel = await _conexao.ObterToken();

                var callback = RestService.For<IClipeInterface>("https://api.twitch.tv/", new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(tokenViewModel.access_token)
                });

                var result = callback.GetClipes(21779, _conexao.ClientId).Result;

                List<ClipesViewModel> listaClipes = result.data;

                return Ok(listaClipes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}