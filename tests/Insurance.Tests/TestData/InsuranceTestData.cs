using System.Collections.Generic;

namespace Insurance.Tests
{
    public class InsuranceTestData
    {
        public static IEnumerable<object[]> InsuranceWith1000 = new List<object[]>
        {
            new object[]
            {
                1,
                1000
            }
        };

        public static IEnumerable<object[]> InsuranceWith500 = new List<object[]>
        {
            new object[]
            {
                2,
                500
            }
        };
    }
}
