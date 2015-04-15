using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.UserData;
using SlimRay.UserData.ExpressionManager;

namespace FunctionTest.Data
{
    /// <summary>
    /// Summary description for ExpressionUsage
    /// </summary>
    [TestClass]
    public class ExpressionUsage
    {

        [TestMethod]
        public void ConstExpression()
        {
            string constValue = "5";

            Expression e = new Expression(constValue);
            Calculator c = new Calculator(e);

            Assert.AreEqual(c.Result(), constValue);
        }

        [TestMethod]
        public void IntAdd()
        {
            int a = 1, b = 2;

            Expression e1 = new Expression(a.ToString());
            Expression e2 = new Expression(b.ToString());

            Calculator c = new Calculator(e1 + e2);

            Assert.AreEqual(c.Result(), a + b);
        }

        [TestMethod]
        public void LogicCalculate()
        { 
        
        }
    }
}
