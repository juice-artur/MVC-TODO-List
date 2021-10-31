using System.Collections.Generic;

namespace todo_rest_api.Model
{
    public  class TaskList
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks = new List<Task>();

    }
}