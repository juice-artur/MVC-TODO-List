using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todo_rest_api.Model
{
    public  class TaskList
    {

        [Key]
        public int TaskListId { get; set; }
        public string Title { get; set; }
        public virtual List<Task> Tasks { get; set; }

    }
}