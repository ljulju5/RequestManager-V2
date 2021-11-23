using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class SQLRequestRepository : IRequest
    {
        private readonly AppDbContext context;

        public SQLRequestRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Request AddRequest(Request request)
        {
            context.Requests.Add(request);
            context.SaveChanges();
            return request;
        }

        public Request DeleteRequest(int id)
        {
            Request request = context.Requests.Find(id);
            if (request != null)
            {
                context.Requests.Remove(request);
                context.SaveChanges();
            }
            return request;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return context.Requests;
        }

        public Request GetRequest(int id)
        {
            return context.Requests.Find(id);
        }

        public Request UpdateRequest(Request requestChanges)
        {
            var request = context.Requests.Attach(requestChanges);
            request.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return requestChanges;
        }
    }
}
