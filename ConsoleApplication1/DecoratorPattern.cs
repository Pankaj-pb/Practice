namespace ConsoleApplication1
{
    public interface IOrder
    {
        string PrepareOrder();
        double CalculateCost();
    }

    public class Bread : IOrder
    {
        public double CalculateCost()
        {
            return 200.30;
        }

        public string PrepareOrder()
        {
            string strPrepare = "";
            strPrepare = "Bake the bread in oven\n";
            strPrepare = strPrepare + "Serve the bread";
            return strPrepare;
        }
    }

    public abstract class OrderDecorator : IOrder
    {
        protected IOrder order;

        public OrderDecorator(IOrder order)
        {
            this.order = order;
        }
        public virtual double CalculateCost()
        {
            return order.CalculateCost();
        }

        public virtual string PrepareOrder()
        {
            return order.PrepareOrder();
        }
    }


    public class OrderChicken : OrderDecorator
    {
        public OrderChicken(IOrder order) : base(order)
        {
        }

        public string PrepareChicken()
        {
            string strPrepare = "";
            strPrepare = "\nGrill the chicken\n";
            strPrepare = strPrepare + "Stuff in the bread";
            return strPrepare;
        }
        public override double CalculateCost()
        {
            return base.CalculateCost() + 100.00;
        }

        public override string PrepareOrder()
        {
            return base.PrepareOrder() + PrepareChicken();
        }
    }

    public class OrderDrink : OrderDecorator
    {
        public OrderDrink(IOrder order) : base(order)
        {
        }

        public string PrepareDrink()
        {
            string strPrepare = "";
            strPrepare = "\nGet the drink from fridge\n";
            return strPrepare;
        }
        public override double CalculateCost()
        {
            return base.CalculateCost() + 120.00;
        }

        public override string PrepareOrder()
        {
            return base.PrepareOrder() + PrepareDrink();
        }
    }
}
