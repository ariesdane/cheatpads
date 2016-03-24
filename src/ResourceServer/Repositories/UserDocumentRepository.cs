using System.Collections.Generic;
using System.Linq;
using AspNet5SQLite.Model;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet5SQLite.Repositories
{
    public class UserDocumentRepository : IRepository<UserDocument>
    {
        private readonly ResourceContext _context;
        private readonly ILogger _logger;

        public UserDocumentRepository(ResourceContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IRepository<UserDocuent>");          
        }

        public List<UserDocument> GetAll()
        {
            _logger.LogCritical("Getting existing records");
            return _context.UserDocuments.ToList();
        }

        public UserDocument Get(long id)
        {
            return _context.UserDocuments.First(t => t.Id == id);
        }

        [HttpPost]
        public void Post(UserDocument documentRecord)
        {
            _context.UserDocuments.Add(documentRecord);
            _context.SaveChanges();
        }

        public void Put(long id, [FromBody]UserDocument documentRecord)
        {
            _context.UserDocuments.Update(documentRecord);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.UserDocuments.First(t => t.Id == id);
            _context.UserDocuments.Remove(entity);
            _context.SaveChanges();
        }
    }
}
