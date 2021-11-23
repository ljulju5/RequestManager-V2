using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public interface IRequest
    {
        Request GetRequest(int id);
        IEnumerable<Request> GetAllRequests();
        Request AddRequest(Request request);
        Request UpdateRequest(Request requestChanges);
        Request DeleteRequest(int id);
    }
}
