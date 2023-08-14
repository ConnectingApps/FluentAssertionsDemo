using FluentAssertions;
using FluentAssertionsDemo.ToAssert;

namespace FluentAssertionsDemo.Test
{
    public class HealthDescriptionTest
    {
        [Theory]
        [InlineData(70, 180, 1.80, 21.60)]
        public void RegularTest(decimal weightInKg, int lengthInCm, decimal expectedLengthInM, decimal expectedBmi)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            instance.LengthInM.Should().Be(expectedLengthInM);
            instance.Bmi.Should().Be(expectedBmi);
            instance.WeighthInKg.Should().Be(weightInKg);
        }

        [Theory]
        [InlineData(70, 180, 1.80, 21.60)]
        public void ValueTupleTest(decimal weightInKg, int lengthInCm, decimal expectedLengthInM, decimal expectedBmi)
        {
            var instance = new HealthDescription(weightInKg, lengthInCm);
            (instance.LengthInM, instance.Bmi, instance.WeighthInKg).Should()
                .Be((expectedLengthInM, expectedBmi, weightInKg));
        }
    }
}