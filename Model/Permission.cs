using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Permission
    {
        public int Id { get; set; }

        public int FK_User { get; set; }

        public int FK_State { get; set; }

        public int StateReason { get; set; }
    }
}
