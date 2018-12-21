using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastTime { get; set; }

        public string NowPass { get; set; }

        public DateTime ModifyTime { get; set; }

        public bool IsValid { get; set; }

        public int Level { get; set; }
    }
}
