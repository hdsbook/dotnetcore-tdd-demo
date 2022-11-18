using System.Collections.Generic;
using DotnetCoreTDD.DesignPatterns.Command;
using DotnetCoreTDD.DesignPatterns.Command.WaiterExample;
using FluentAssertions;
using NUnit.Framework;

namespace DotnetCoreTDDTests.DesignPatterns.Command
{
    [TestFixture]
    public class WaiterTests
    {
        [Test]
        public void GivenWaiter_SetHooksWithCommands_WorksCorrectly()
        {
            // given 服務生 (invoker)
            var waiter = new Waiter();

            // given 廚房 (receiver)
            var kitchen = new KitchenReceiver();

            // given 服務生 接到此二命令時要做的動作，並進行教育訓練，告訴服務生這兩件事怎麼做
            var orderCommand = new OrderCommand();
            var notifyCommand = new NotifyKitchenCommand(kitchen);
            waiter.SetOnReceiveOrder(orderCommand);
            waiter.SetOnNotifyKitchen(notifyCommand);

            // given orders
            var orders = new List<Order>
            {
                new Order
                {
                    Type = FoodType.Beef,
                    Count = 1,
                    Remark = ""
                },
                new Order
                {
                    Type = FoodType.Beef,
                    Count = 1,
                    Remark = "加辣"
                },
                new Order
                {
                    Type = FoodType.Pork,
                    Count = 1,
                    Remark = "不要萊豬"
                }
            };


            // when 服務生接收點餐
            var executeHistory = new List<string>();
            foreach (var order in orders)
            {
                var result = waiter.GetOrder(order);
                executeHistory.AddRange(result);
            }


            // then
            var expected = new List<string>
            {
                "客人點了: 1份牛肉",
                "收錢",
                "通知廚房準備: 1份牛肉",

                "客人點了: 1份牛肉, 並備註：加辣",
                "收錢",
                "通知廚房準備: 1份牛肉, 並備註：加辣",

                "客人點了: 1份豬肉, 並備註：不要萊豬",
                "收錢",
                "通知廚房準備: 1份豬肉, 並備註：不要萊豬",
            };
            executeHistory.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}