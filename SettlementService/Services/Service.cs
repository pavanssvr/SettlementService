using System;
using Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Services
{
    public class Service : IService
    {
        private IMemoryCache _cache;
        public Service(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<(bool, string)> BookForSettlement(Request request)
        {
            (bool, string) response = await AddSettlementRequest(request);
            if (response.Item1)
            {
                Guid obj = Guid.NewGuid();
                return (true, obj.ToString());
            }
            else
                return response;
        }

        private async Task<(bool, string)> AddSettlementRequest(Request request)
        {
            string name;
            if (!_cache.TryGetValue<string>(request.BookingTime, out name))
            {
                if (((MemoryCache)_cache).Count < 4)
                {
                    _cache.Set(request.BookingTime, request.Name, DateTimeOffset.Now.AddMinutes(60));
                    return (true, "Settlement request successfully added");
                }
                else
                    return (false, "Can serve only 4 request simultaniously");
            }
            else
            {
                return (false, "Request is already in process for settlement");
            }
        }
    }
}
