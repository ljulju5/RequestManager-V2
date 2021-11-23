using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class RequestRepository : IRequest
    {
        private List<Request> _requestList;
        public RequestRepository()
        {
            _requestList = new List<Request>()
            {
                new Request()
                {
                    Id = 1, RequestName = "Zahtev 1",  Department = Department.HR
                },
                new Request()
                {
                    Id = 2, RequestName = "Zahtev 2", Department = Department.IT
                }
            };
        }

        public Request AddRequest(Request request)
        {
            request.Id =_requestList.Max(r => r.Id) + 1;
            _requestList.Add(request);
            return request;
        }

        public Request DeleteRequest(int id)
        {
            Request request = _requestList.FirstOrDefault(r => r.Id == id);
            if (request != null)
            {
                _requestList.Remove(request);
            }
            return request;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _requestList;
        }

        public Request GetRequest(int id)
        {
            return _requestList.FirstOrDefault(r => r.Id == id);
        }

        public Request UpdateRequest(Request requestChanges)
        {
            Request request = _requestList.FirstOrDefault(r => r.Id == requestChanges.Id);
            if (request != null)
            {
                request.RequestName = requestChanges.RequestName;
                request.Department = requestChanges.Department;
            }
            return request;
        }
    }
}
