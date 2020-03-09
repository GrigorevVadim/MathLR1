using System;

namespace MathLR1.Task4
{
    public class Newton
    {
        private readonly int _polynomial;
        private readonly double[] _sourceGreed;
        private readonly double[] _sourceValues;
        private readonly double[] _resultGreed;
        private double[] ResultValues { get; set; }
        private double[] ResultResidual { get; set; }
        
        public Newton(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            CheckArgs(polynomial, sourceGreed.Length, sourceValues.Length, resultGreed.Length);
            
            _polynomial = polynomial;
            _sourceGreed = sourceGreed;
            _sourceValues = sourceValues;
            _resultGreed = resultGreed;

            ResultValues = new double[_resultGreed.Length];
            ResultResidual = new double[_resultGreed.Length];
            
            Calculate();
        }
        
        public (double[] ResultValues, double[] ResultResidual) GetResult() => (ResultValues, ResultResidual);

        private void Calculate()
        {
            int currentSourceElement = 0;

            while (currentSourceElement < _sourceGreed.Length)
            {
                var deltasRow = CalculateDeltasRow(currentSourceElement);
                var range = CalculateResultGreedRange(currentSourceElement, out var startResultElement);
                var qRow = CalculateQRow(currentSourceElement, startResultElement, range);

                for (int i = 0; i < range; i++)
                {
                    CalculatePn(startResultElement + i, i, currentSourceElement, qRow, deltasRow);
                    CalculateRn(startResultElement + i, i, qRow, deltasRow);
                }
                
                if (currentSourceElement + _polynomial == _sourceGreed.Length)
                    currentSourceElement = _sourceGreed.Length;
                else if (currentSourceElement + _polynomial * 2 > _sourceGreed.Length)
                    currentSourceElement = _sourceGreed.Length - _polynomial;
                else
                    currentSourceElement += _polynomial;
            }
        }

        private void CalculatePn(int currentResultElement, int qElement, int currentSourceElement, double[] qRow, double[] deltasRow)
        {
            var resultValue = _sourceValues[currentSourceElement];

            for (int j = 0; j < _polynomial; j++)
            {
                double qFactor = 1;

                for (int k = 0; k <= j; k++)
                {
                    qFactor *= (qRow[qElement] - k);
                }

                resultValue += qFactor * deltasRow[j] / CalculateFactorial(j + 1);
            }

            ResultValues[currentResultElement] = resultValue;
        }

        private void CalculateRn(int currentResultElement, int qElement, double[] qRow, double[] deltasRow)
        {
            double qFactor = 1;

            for (int j = 0; j < _polynomial; j++)
            {
                qFactor *= (qRow[qElement] - j);
            }

            ResultResidual[currentResultElement] = qFactor * deltasRow[_polynomial] / CalculateFactorial(_polynomial + 1);
        }

        private static int CalculateFactorial(int value)
        {
            int result = 1;
            for (int i = 2; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }

        private int CalculateResultGreedRange(int currentSourceElement, out int currentResultElement)
        {
            var count = 0;
            currentResultElement = _resultGreed.Length;
            
            for (int i = 0; i < _resultGreed.Length; i++)
            {
                if (_resultGreed[i] >= _sourceGreed[currentSourceElement]
                    && _resultGreed[i] <= _sourceGreed[currentSourceElement + _polynomial - 1])
                {
                    count++;
                    if (currentResultElement > i)
                        currentResultElement = i;
                }
            }
            
            if (currentResultElement == _resultGreed.Length)
                throw new ArithmeticException("Неверно вычислен действующий элемент");

            return count;
        }

        private double[] CalculateQRow(int startSourceElement, int startElement, int range)
        {
            var qRow = new double[range];
            var h = _sourceGreed[startSourceElement + 1] - _sourceGreed[startSourceElement];
            
            for (int i = 0; i < qRow.Length; i++)
            {
                qRow[i] = (_resultGreed[startElement + i] - _resultGreed[startElement]) / h;
            }

            return qRow;
        }

        private double[] CalculateDeltasRow(int startElement)
        {
            var deltaRow = new double[_polynomial + 1];
            var deltaTable = new double[_polynomial + 1, _polynomial + 1];

            for (int i = 0; i < _polynomial + 1; i++)
            {
                if (startElement + i + 1 >= _sourceValues.Length)
                {
                    continue;
                }
                
                deltaTable[i, 0] = _sourceValues[startElement + i + 1] - _sourceValues[startElement + i];
            }
            
            for (int j = 1; j < _polynomial + 1; j++)
            {
                for (int i = 0; i < _polynomial + 1 - j; i++)
                {
                    deltaTable[i, j] = deltaTable[i + 1, j - 1] - deltaTable[i, j - 1];
                }
            }

            for (int i = 0; i < _polynomial + 1; i++)
            {
                deltaRow[i] = deltaTable[0, i];
            }

            return deltaRow;
        } 

        private void CheckArgs(int polynomial, int sourceGreedDimension, int sourceValuesDimension, int resultGreedDimension)
        {
            if (sourceGreedDimension != sourceValuesDimension
                || sourceGreedDimension >= resultGreedDimension
                || polynomial >= sourceGreedDimension)
                throw new ArgumentException("Ошибка в исходных данных");
        }
    }
}