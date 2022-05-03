using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Entities.Concrete
{
    public class Plan
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverPath { get; set; }

        public ToDoItem[] ToDoItems { get; set; }
    }
}
