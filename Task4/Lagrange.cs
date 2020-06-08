using System;

namespace MathLR1.Task4
{
    public class Lagrange
    {
        private readonly int _polynomial;
        private readonly double[] _sourceGreed;
        private readonly double[] _sourceValues;
        private readonly double[] _resultGreed;
        private double[] ResultPolynomialValues { get; set; }
        private double[] ResultFunctionValues { get; set; }
        private double[] ResultResidual { get; set; }

        public Lagrange(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            _polynomial = polynomial;
            _sourceGreed = sourceGreed;
            _sourceValues = sourceValues;
            _resultGreed = resultGreed;

            var resultDimension = _resultGreed.Length;
            ResultPolynomialValues = new double[resultDimension];
            ResultFunctionValues = new double[resultDimension];
            ResultResidual = new double[resultDimension];

            Calculate();
        }
        
        public (double[] ResultPolynomialValues, double[] ResultFunctionValues, double[] ResultResidual) GetResult() => 
            (ResultPolynomialValues, ResultFunctionValues, ResultResidual);

        private void Calculate()
        {
            CalculateValues();
            CalculateResiduals();
        }

        void CalculateValues()
        {
            int currentResultElementPosition = 0;

            while (currentResultElementPosition < _resultGreed.Length)
            {
                var currentSourceElementPosition = GetSourceElementByResultElement(currentResultElementPosition);
                ResultPolynomialValues[currentResultElementPosition] = CalculateValuesElement(_resultGreed[currentResultElementPosition], currentSourceElementPosition);

                currentResultElementPosition++;
            }
        }

        int GetSourceElementByResultElement(int resultElementPosition)
        {
            var resultElement = _resultGreed[resultElementPosition];
            int sourceElementPosition = 0;

            for (int i = 0; i < _sourceGreed.Length; i++)
            {
                if (_sourceGreed[i] <= resultElement) 
                    sourceElementPosition = i;
            }

            if (sourceElementPosition + _polynomial >= _sourceGreed.Length)
                return _sourceGreed.Length - _polynomial - 1;

            return sourceElementPosition;
        }

        double CalculateValuesElement(double currentCalculateElement, int currentSourceElementPosition)
        {
            double sum = 0;
            for (int i = currentSourceElementPosition; i <= currentSourceElementPosition + _polynomial; i++)
            {
                double temp = _sourceValues[i];
                for (int j = currentSourceElementPosition; j <= currentSourceElementPosition + _polynomial; j++)
                {
                    if (i == j) continue;
                    temp *= (currentCalculateElement - _sourceGreed[j]);
                    temp /= (_sourceGreed[i] - _sourceGreed[j]);
                }
                sum += temp;
            }

            return sum;
        }

        private void CalculateResiduals()
        {
            for (int i = 0; i < _resultGreed.Length; i++)
            {
                ResultFunctionValues[i] = SourceData.InvokeSourceFunction(_resultGreed[i]);
                ResultResidual[i] = Math.Abs(ResultFunctionValues[i] - ResultPolynomialValues[i]);
            }
        }
    }
}