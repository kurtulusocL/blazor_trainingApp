using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Entities.Concrete.Dto
{
    public class ToDoItemRequest
    {
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }      
        public string PlanId { get; set; }
    }
}
