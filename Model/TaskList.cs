using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todo_rest_api.Model
{
    public  class TaskList
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<Task> Tasks { get; set; }

    }
}