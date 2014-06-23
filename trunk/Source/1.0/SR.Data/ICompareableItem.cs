using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    public interface IExpression
    {
        void Execute();

        void Sub(IExpression expression);

        void And(IExpression expression);
        void Or(IExpression expression);

        void Not(IExpression expression);
    }

    public enum Operator
    {
        ValueAdd,

        ValueEqual,
        ValueNotEqual,
        ValueBiggerThan,
        ValueSmallerThan,

        LogicAnd,
        LogicOr,
        LogicNot
    }

    public class Expression : IExpression
    {
        private Operator _operator;
        private string _value;

        public Expression(Operator op, string val)
        {
            _operator = op;
            _value = val;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Sub(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public void And(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Or(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Not(IExpression expression)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// An object that can be compared with other.
    /// it keep only 1 pair of operator-value,
    /// the compare mothods change the operator and value.
    /// </summary>
    public interface ICompareMethod
    {
        IExpression Equal(string obj);
        IExpression NotEqual(string obj);

        IExpression BiggerThan(string obj);
        IExpression SmallerThan(string obj);
    }

    public class CompareMethod : ICompareMethod
    {
        public IExpression Equal(string obj)
        {
            return new Expression(Operator.ValueEqual, obj);
        }

        public IExpression NotEqual(string obj)
        {
            return new Expression(Operator.ValueNotEqual, obj);
        }

        public IExpression BiggerThan(string obj)
        {
            return new Expression(Operator.ValueBiggerThan, obj);
        }

        public IExpression SmallerThan(string obj)
        {
            return new Expression(Operator.ValueSmallerThan, obj);
        }
    }
}
