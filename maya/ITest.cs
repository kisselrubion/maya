using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maya
{
    interface ITest
    {
        public int GetId { get; set; }
        public string GetAuth { get; set; }

      public string GetUsersList { get; set; }
      public bool DeleteUser { get; set; }
    }
}
