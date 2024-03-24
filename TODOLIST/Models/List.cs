using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODOLIST.Models
{
    public class List
    {
        public int Id {  get; set; }

        [Display(Name = "Название")]
        [StringLength(60, MinimumLength = 3), Required]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Кол-во задач")]
        public int tasksCount { 
            get
            {
                return tasksCount;
            } 
            set
            {
                tasksCount = tasks.Count;
            } }

        public List<TodoTask> tasks { get; set; }
    }
}
