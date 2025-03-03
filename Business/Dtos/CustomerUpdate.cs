using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class CustomerUpdate
    {

        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}