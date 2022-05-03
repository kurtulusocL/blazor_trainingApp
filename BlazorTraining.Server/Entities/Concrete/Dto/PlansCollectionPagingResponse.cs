using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Entities.Concrete.Dto
{
    public class PlansCollectionPagingResponse : BaseApiResponse
    {
        public Plan[] Records { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? NextPage { get; set; }
        public int Count { get; set; }
    }
}
