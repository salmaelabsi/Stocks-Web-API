using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.api.Data;
using WebApplication1.api.Models;
using WebApplication1.api.Dtos.Stock;
using WebApplication1.api.Mappers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.api.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.api.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.api.Controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)  //bringing in the db before we actually use it
        {
            _stockRepo = stockRepo;
            _context = context;  //inheritance
        }

        //anything that goes to the database has to be await

        [HttpGet("StockList")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stocks = await _stockRepo.GetAllAsync(query);

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();  //deferred execution

            return Ok(stockDto);
        }

        [HttpGet("GetStockById/{id:int}")] //:int is type checking. gives error 404 if the type mismatches
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(StockMappers.ToStockDto(stock));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, StockMappers.ToStockDto(stockModel));
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("DeleteStock")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //context.Stocks.Remove(stockModel); //we don't add await here cuz remove isn't an asynchronous function. Remove() only marks the entity for deletion from the db. the actual process is done by SaveChanges()
            await _stockRepo.DeleteAsync(id);
      
            return NoContent();
        }

    }
}
