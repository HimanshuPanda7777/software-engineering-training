using System;

namespace XamXpert;

public interface IExam
{
    public double CalculateScore();
    public static String EvaluateResult(double percentage);


}
