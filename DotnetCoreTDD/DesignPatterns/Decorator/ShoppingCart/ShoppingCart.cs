using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDD.DesignPatterns.Decorator.ShoppingCart
{
    public interface ICart
    {
        void AddProduct(Product product);
        
        /// <summary>
        /// 結算金額
        /// </summary>
        /// <returns></returns>
        public int CalculatePrice();
    }

    public class ShoppingCart: ICart
    {
        private List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        
        public int CalculatePrice()
        {
            return Products.Sum(x => x.Amount * x.Price);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }


    #region Decorators

    public abstract class ShoppingCartDecorator: ICart
    {
        protected ICart ShoppingCart { get; set; }

        protected ShoppingCartDecorator(ICart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public void AddProduct(Product product)
        {
            ShoppingCart.AddProduct(product);
        }

        public virtual int CalculatePrice()
        {
            return ShoppingCart.CalculatePrice();
        }
    }

    /// <summary>
    /// VIP 打八折優惠
    /// </summary>
    public class VipDecorator: ShoppingCartDecorator
    {
        public VipDecorator(ICart shoppingCart) : base(shoppingCart)
        {
        }

        public override int CalculatePrice()
        {
            var amount = base.CalculatePrice();
            return (int) Math.Floor(amount * 0.8);
        }
    }

    /// <summary>
    /// 折底50元禮卷
    /// </summary>
    public class CouponDecorator: ShoppingCartDecorator
    {
        public CouponDecorator(ICart shoppingCart) : base(shoppingCart)
        {
        }

        public override int CalculatePrice()
        {
            var amount = base.CalculatePrice();
            amount -= 50;
            return amount > 0 ? amount : 0;
        }
    }

    #endregion
}