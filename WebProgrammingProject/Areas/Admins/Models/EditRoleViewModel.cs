using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Areas.Admins.Models
{
    public class EditRoleViewModel
    {
        public string ID { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

    }
}
