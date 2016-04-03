using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Entity.Stores;
    using CheatPads.Api.Entity.Models;

    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {

        private CategoryStore _categoryStore;

        public CategoriesController(CategoryStore categoryStore)
        {
            _categoryStore = categoryStore;
        }

        // GET: api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryStore.List();
        }

        // GET api/categories/1
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryStore.Get(id);
        }

        // DELETE api/categories/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryStore.Delete(id);
        }

        // PUT api/categories/1
        [HttpPut("{id}")]
        public Category Put(int id, Category category)
        {
            _categoryStore.Update(category, id);
            return category;
        }

        // POST api/categories/1
        [HttpPost()]
        public Category Post(Category category)
        {
            _categoryStore.Create(category);
            return category;
        }

    }
}