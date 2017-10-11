using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IProduct
    {
        Task<List<ProductInfo>> Get();
        Task<List<ProductInfo>> GetById(int id);
        Task Post([FromBody] ProductInfo item);
        Task Put(long id, [FromBody] ProductInfo item);
        Task Delete(long id);
    }
}