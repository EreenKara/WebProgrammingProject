using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Areas.Admins.Models
{
    public class EditUsersInRoleViewModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
