using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.api.Models;
using WebApplication1.api.Dtos.Stock;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebApplication1.api.Repository
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(int id);
        //Task<IActionResult> GetById([FromRoute] int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commentModel);
        Task<Comment?> DeleteAsync(int id);
    }
}
