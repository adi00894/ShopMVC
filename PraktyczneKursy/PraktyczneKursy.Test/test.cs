using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PraktyczneKursy.Controllers;
using PraktyczneKursy.Infrastructure;
using Rhino.Mocks;

namespace PraktyczneKursy.Test
{
    [TestFixture]
    class test
    {
        [Test]
        public void Methond()
        {
            //commit
            var wrapper = MockRepository.GenerateMock<DefaultCacheProvider>();
            wrapper.Expect(x => x.IsSet(Consts.KategorieCacheKey));

          
        }
    }
}
