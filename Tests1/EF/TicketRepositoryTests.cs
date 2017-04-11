using Microsoft.VisualStudio.TestTools.UnitTesting;
using SC.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DAL;
using Xunit;

namespace Tests.EF
{
    public class TicketRepositoryTests: IDisposable
    {
        private ITicketRepository repo;

        public TicketRepositoryTests()
        {
            repo = new TicketRepository();
            Console.WriteLine("In construct");
        }

        [Theory, MemberData(nameof(GetTestData))]
        public void someTest(object i)
        {
            Console.WriteLine("Run test sequence: " + ((TestDto)i).Value);
            var result = ((TestDto)i).Value == 1;
            Xunit.Assert.Equal(((TestDto)i).Result, result);
        }

        public void Dispose()
        {
            repo = null;
            Console.WriteLine("In dispose");
        }

        private static IEnumerable<object> GetTestData()
        {
            yield return new TestDto(true, 1);
            yield return new TestDto(false,2);
            yield return new TestDto(false, 3);
            yield return new TestDto(false, 4);
        }

        private class TestDto
        {
            internal TestDto(bool b, int i)
            {
                Result = b;
                Value = i;
            }

            internal int Value { get;}

            internal bool Result { get;}
        }
    }
}