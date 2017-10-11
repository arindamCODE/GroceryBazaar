using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GroceryBazaar.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller, IProduct
    {
        private readonly BazaarContext _context;

        public ProductController(BazaarContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public async Task<List<ProductInfo>> Get()
        {
            return await _context.ProductInfo.ToListAsync();
        }
        /* public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        } */

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<List<ProductInfo>> GetById(int id)
        {
            ProductInfo objectProductInfo = await _context.ProductInfo.FindAsync(id);
            List<ProductInfo> product = new List<ProductInfo>();
            try
            {
                product.Add(objectProductInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        /* public string Get(int id)
        {
            return "value";
        } */

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ProductInfo item)
        {
            try
            {
                if (IsAlphaName(item) && IsNumericRate(item))
                {
                    _context.ProductInfo.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody] ProductInfo item)
        {
            try
            {
                var result = _context.ProductInfo.FirstOrDefault(t => t.ID == id);


                if (IsAlphaName(item) && IsNumericRate(item))
                {
                    result.Name = item.Name;
                    result.Rate = item.Rate;
                    result.Description = item.Description;
                    _context.ProductInfo.Update(result);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /* public void Put(int id, [FromBody]string value)
        {
        } */

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            try
            {
                var result = _context.ProductInfo.FirstOrDefault(t => t.ID == id);
                _context.ProductInfo.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /* public void Delete(int id)
        {
        } */

        bool IsAlphaName(ProductInfo item)
        {
            string pattern = "^[A-Za-z ]+$";
            try
            {
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(item.Name) == false)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        bool IsNumericRate(ProductInfo item)
        {
            string pattern = "^[0-9 ]+$";
            string str = item.Rate.ToString();
            try
            {
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(str) == false)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
