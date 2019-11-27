using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliciousRestaurant.Application.Interfaces;
using NUnit;
using NUnit.Framework;
namespace DeliciousRestaurant.Application.Test
{
    [TestFixture]
    public class TestBase
    {
        public IContext IContext { get; set; }

        
    }
}
