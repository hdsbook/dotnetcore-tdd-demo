using DotnetCoreTDD.DesignPatterns.Decorator.ShoppingCart;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Decorator
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void CalculatePrice_Undecorated_ReturnsCorrectly()
        {
            // given 購物車物件與商品
            var cart = new ShoppingCart();
            var refrigerator = new Product
            {
                Name = "冰箱",
                Price = 20000,
                Amount = 1,
            };
            
            // when 加入商品並計算金額
            cart.AddProduct(refrigerator);
            var price = cart.CalculatePrice();
            
            // then 驗證金額正確
            price.Should().Be(20000);
        }
        
        [Test]
        public void CalculatePrice_DecorateWithVipAndCoupon_ReturnsCorrectly()
        {
            // given 購物車物件與商品
            ICart cart = new ShoppingCart();
            var refrigerator = new Product
            {
                Name = "冰箱",
                Price = 20000,
                Amount = 1,
            };
            
            // when 加入 VIP 與 優惠卷 裝飾器
            cart = new VipDecorator(cart);
            cart = new CouponDecorator(cart);

            // when 加入商品並計算金額
            cart.AddProduct(refrigerator);
            var price = cart.CalculatePrice();
            
            // then 驗證金額正確
            price.Should().Be(15950);
        }
        
        [Test]
        public void CalculatePrice_DecorateWithCouponAndVip_ReturnsCorrectly()
        {
            // given 購物車物件與商品
            ICart cart = new ShoppingCart();
            var refrigerator = new Product
            {
                Name = "冰箱",
                Price = 20000,
                Amount = 1,
            };
            
            // when 加入 優惠卷 與 VIP 裝飾器 (順序與上一個測試不同)
            cart = new CouponDecorator(cart);
            cart = new VipDecorator(cart);

            // when 加入商品並計算金額
            cart.AddProduct(refrigerator);
            var price = cart.CalculatePrice();
            
            // then 驗證金額正確
            price.Should().Be(15960);
        }
    }
}