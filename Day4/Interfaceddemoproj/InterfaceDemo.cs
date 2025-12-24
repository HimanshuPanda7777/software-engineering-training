using System;

namespace Interfaceddemoproj
{
    public interface IAddition
    {
        int Add(int a, int b);
    }

    public interface ISubtraction : IAddition
    {
        int Subtract(int a, int b);
    }

    public interface IMultiplication : ISubtraction
    {
        int Multiply(int a, int b);
    }

    public interface IDivision : IMultiplication
    {
        double Divide(int a, int b);
    }

    public interface IAddSubtract : IAddition, ISubtraction
    {
    }

    public interface IAddProdDivide : IAddition, IMultiplication, IDivision
    {
    }

    public interface IAllOperations : IAddition, ISubtraction, IMultiplication, IDivision
    {
    }
}
