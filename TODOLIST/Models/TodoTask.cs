using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODOLIST.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [StringLength(60, MinimumLength = 3), Required]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime EndDate { get; set; }

        public int ListId { get; set; }
        public List tasklist { get; set; }
    }
}
