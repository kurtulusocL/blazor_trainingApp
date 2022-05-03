using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Entities.Concrete.Dto
{
    public class SinglePlanResponse : BaseApiResponse
    {
        public Plan Record { get; set; }
    }
}
