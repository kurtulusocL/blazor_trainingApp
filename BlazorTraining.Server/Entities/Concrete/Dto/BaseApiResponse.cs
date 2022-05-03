using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Entities.Concrete.Dto
{
    public abstract class BaseApiResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
