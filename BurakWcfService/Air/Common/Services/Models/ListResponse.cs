
using System.Collections.Generic;

namespace BurakWcfService.Air.Services
{
       public class ListResponse<T> : ServiceResponse
    {
        public List<T> Entities { get; set; }
        public int TotalCount;
        public int Skip;
        public int Take;
    }
}
