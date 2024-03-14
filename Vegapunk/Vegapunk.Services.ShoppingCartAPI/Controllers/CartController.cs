using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vegapunk.Services.ShoppingCartAPI.Data;
using Vegapunk.Services.ShoppingCartAPI.Models.Dto;

namespace Vegapunk.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ResponseDto responseDto;
        private IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public CartController(AppDbContext _appDbContext, IMapper _mapper)
        {
            this._appDbContext = _appDbContext;
            this._mapper = _mapper;
            this.responseDto = new ResponseDto();
        }

        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto) 
        {
            return new ResponseDto();
        }
    }
}
