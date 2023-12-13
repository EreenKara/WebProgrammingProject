using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User:IdentityUser<int>
    {
        [ForeignKey(nameof(Adult))]
        public int AdultID { get; set; }
        public Adult Adult { get; set; }
    }
}
