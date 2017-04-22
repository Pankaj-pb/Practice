using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double delegateResult = TestClass.calAreaPointer.Invoke(2);
            TestClass.actionDelegate("this is test");
            var predicateResult = TestClass.checkGreatedThan5("checkthios");
            List<string> list = new List<string>();
            list.Add("shiv");
            list.Add("shiv123");
            var item = list.Find(TestClass.checkGreatedThan5);//list.Find(x=>x.Length>5);

            //Expression Tree (10+20_-(5+3), Expression are not delegates. they are helpful when you are creating end user languages
            //probably end user go type command in english, your expression tree is dynmaically created based on that commands.
            //In linq when you write query , it converted into expression tree,which further evaluted to Sql and any other data source
            // language.you can quick watch how linq query is translated to sql.
            BinaryExpression b1 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(10), Expression.Constant(20));
            BinaryExpression b2 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(5), Expression.Constant(3));
            BinaryExpression b3 = Expression.MakeBinary(ExpressionType.Subtract, b1, b2);

            int result = Expression.Lambda<Func<int>>(b3).Compile()();
            hy.Attributes.Add("onClick", $"window.open('WebForm2.aspx');')");
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            //WebUserControl1.Set();
        }
    }

    /// <summary>
    /// Implement IDisposable interface. if dispose is called finalize will be suppressed. If dispose is not called finalize will 
    /// automatically calls at the end when we going to stop exectuion and the method who have finalize implemented they are send
    /// into finalize queue from gen 0 by garbage collector and garbase collector has to make extra round for freeing up the gen0 resources
    /// that's why it is not good practice to use finialize. If any unmanaged code or custom class implement the IDisposeble interface
    /// they can used inside the using method. i.e.
    /// using (SqlConnection con=new SqlConnection("connectionstring");
    /// {
    /// 
    /// }
    /// using will automatically call the dispose method.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Disposeable : IDisposable
    {
        bool disposed = false;
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Disposeable()
        {

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
            }
            disposed = true;
        }
    }
    public class TestClass
    {
        //public delegate double CalAreaPointer(int r);
        //public static CalAreaPointer calAreaPointer = CaculateArea;

        //Anonymous  method
        //public static CalAreaPointer calAreaPointer = new CalAreaPointer(
        //                                            delegate (int r)
        //                                            {
        //                                                return 3.14 * r * r;
        //                                            });

        //Lambda expression
        //public static CalAreaPointer calAreaPointer = r => 3.14 * r * r;

        // Generic Delegate Func
        public static Func<double, double> calAreaPointer = r => 3.14 * r * r;

        // Generic Delegate Action without return 
        public static Action<string> actionDelegate = r => Console.WriteLine(r);

        //Predicate it just return true or false
        public static Predicate<string> checkGreatedThan5 = r => r.Length > 5;

        //Use of above deletage in c# other list
        //List<string> list = new List<string>();
        //list.Add("shiv");
        // list.Add("shiv123");
        // var item = list.Find(TestClass.checkGreatedThan5);//list.Find(x=>x.Length>5);

        public static double CaculateArea(int r)
        {
            return 3.14 * r * r;
        }
    }

}