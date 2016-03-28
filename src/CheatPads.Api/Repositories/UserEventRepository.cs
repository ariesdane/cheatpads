using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using CheatPads.Api.Model;

namespace CheatPads.Api.Repositories
{
    public class UserEventRepository : IRepository<UserEvent>
    {
        private readonly ResourceContext _context;
        private readonly ILogger _logger;

        public UserEventRepository(ResourceContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IRepository<UserEvent>");          
        }

        public List<UserEvent> GetAll()
        {
            _logger.LogCritical("Getting existing records");
            return _context.UserEvents.ToList();
        }

        public UserEvent Get(long id)
        {
            return _context.UserEvents.First(t => t.Id == id);
        }

        [HttpPost]
        public void Post(UserEvent Event)
        {
            _context.UserEvents.Add(Event);
            _context.SaveChanges();
        }

        public void Put(long id, [FromBody]UserEvent Event)
        {
            _context.UserEvents.Update(Event);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.UserEvents.First(t => t.Id == id);
            _context.UserEvents.Remove(entity);
            _context.SaveChanges();
        }
    }
}
