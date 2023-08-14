using System;

namespace FluentAssertionsDemo.ToAssert
{
    public class HealthDescription
    {
        public decimal LengthInM { get; }

        public decimal WeighthInKg { get; }

        public decimal Bmi { get;  }

        public HealthDescription(decimal weightInKg, int lengthInCm)
        {
            WeighthInKg = weightInKg;
            LengthInM = (decimal)lengthInCm / 100;
            Bmi = Math.Round(weightInKg / (LengthInM * LengthInM), 2);
        }
    }
}
