using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PersonalInAccount
    {
        public int Id { get; set; }
        public virtual Account Account{ get; set; }
        public virtual Personal Personal { get; set; }
        public virtual PersonalTypes PersonalTypes { get; set; }
    }
}
