using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTest
{
    public class Postcodes
    {
        public Postcodes()
        {
            postcodesList = new List<PostcodeInfo>();
        }
        
        public List<PostcodeInfo> postcodesList { get; set; }
    }
}
