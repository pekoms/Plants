using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Domain.Domain.Dtos
{
    public class TokenDTO
    {
        public string? token {  get; set; }
        public string? expiration { get; set; }
    }
}
