using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDD.DesignPatterns.Decorator.ShoppingCart
{
    /// <summary>
    /// 購物車介面
    /// </summary>
    public interface ICart
    {
        void AddProduct(Product product);
        
        public int CalculatePrice();
    }

    /// <summary>
    /// 購物車類別
    /// </summary>
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

    /// <summary>
    /// 商品類別
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }


    #region Decorators

    /// <summary>
    /// 抽象裝飾器類別
    /// </summary>
    public abstract class ShoppingCartDecorator: ICart
    {
        protected ICart ShoppingCart { get; set; }

        protected ShoppingCartDecorator(ICart shoppingCart)
        {
            ShoppingCart = shoppingCart; // 將被裝飾者做為私有成員
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