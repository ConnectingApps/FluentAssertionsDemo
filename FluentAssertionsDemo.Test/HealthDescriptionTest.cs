using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertionsDemo.ToAssert;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;


namespace FluentAssertionsDemo.Test
{
    public class HealthDescriptionTest
    {
        [Theory]
        [InlineData(70.01, 180, 1.80, 21.61)]
        public void RegularTest(decimal weightInKg, int lengthInCm, decimal expectedLengthInM, decimal expectedBmi)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            instance.LengthInM.Should().Be(expectedLengthInM);
            instance.Bmi.Should().Be(expectedBmi);
            instance.WeightInKg.Should().Be(weightInKg);
        }

        [Theory]
        [InlineData(70.01, 180, 1.80, 21.61)]
        public void ScopeTest(decimal weightInKg, int lengthInCm, decimal expectedLengthInM, decimal expectedBmi)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            using (new AssertionScope())
            {
                instance.LengthInM.Should().Be(expectedLengthInM);
                instance.Bmi.Should().Be(expectedBmi);
                instance.WeightInKg.Should().Be(weightInKg);
            }
        }

        [Theory]
        [InlineData(70.01, 180, 1.80, 21.61)]
        public void ValueTupleTest(decimal weightInKg, int lengthInCm, decimal expectedLengthInM, decimal expectedBmi)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            (instance.LengthInM, instance.Bmi, WeighthInKg: instance.WeightInKg).Should()
                .Be((expectedLengthInM, expectedBmi, weightInKg));
        }


        [Theory]
        [InlineData(70.01, 180, """
                             {
                                "Bmi" : 21.61,
                                "WeightInKg": 70.01,
                                "LengthInM" : 1.80 
                             }
                             """)]
        public void RegularJsonTest(decimal weightInKg, int lengthInCm, string expectedResult)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            JToken.FromObject(instance).Should().BeEquivalentTo(JToken.Parse(expectedResult));
        }
    }
}