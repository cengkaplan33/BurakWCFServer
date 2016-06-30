using BurakWcfService.Air.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Services
{
    public class RetrieveResponse<T> : ServiceResponse
    {
        public T Entity { get; set; }
    }
}