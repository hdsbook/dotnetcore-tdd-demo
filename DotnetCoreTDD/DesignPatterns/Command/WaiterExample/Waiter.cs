using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Command.WaiterExample
{
    /// <summary>
    /// 服務生服務介面
    /// </summary>
    public interface IWaiterServiceCommand
    {
        public List<string> Execute(Order order);
    }

    /// <summary>
    /// 服務生服務：接收客人點餐
    /// </summary>
    public class OrderCommand : IWaiterServiceCommand
    {
        public List<string> Execute(Order order)
        {
            return new List<string> {"客人點了: " + order.Description()};
        }
    }

    /// <summary>
    /// 服務生服務：通知廚房點餐
    /// </summary>
    public class NotifyKitchenCommand : IWaiterServiceCommand
    {
        private readonly KitchenReceiver _receiver;

        public NotifyKitchenCommand(KitchenReceiver receiver)
        {
            _receiver = receiver;
        }

        public List<string> Execute(Order order)
        {
            return new List<string> {"通知" + _receiver.Cook(order)};
        }
    }

    /// <summary>
    /// 廚房：與服務生互動的其它第三方物件
    /// </summary>
    public class KitchenReceiver
    {
        public string Cook(Order order)
        {
            return "廚房準備: " + order.Description();
        }
    }

    /// <summary>
    /// 服務生
    /// </summary>
    public class Waiter
    {
        private IWaiterServiceCommand _onReceiveOrder;
        private IWaiterServiceCommand _onNotifyKitchen;

        /// <summary>
        /// 外部注入接收點餐時要做的指令
        /// </summary>
        /// <param name="command"></param>
        public void SetOnReceiveOrder(IWaiterServiceCommand command)
        {
            _onReceiveOrder = command;
        }

        /// <summary>
        /// 外部注入通知廚房準備食物的指令
        /// </summary>
        /// <param name="command"></param>
        public void SetOnNotifyKitchen(IWaiterServiceCommand command)
        {
            _onNotifyKitchen = command;
        }

        /// <summary>
        /// 服務生接收點餐
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<string> GetOrder(Order order)
        {
            var history = new List<string>();

            if (_onReceiveOrder is IWaiterServiceCommand)
            {
                history.AddRange(_onReceiveOrder.Execute(order));
            }

            history.Add("收錢");

            if (_onNotifyKitchen is IWaiterServiceCommand)
            {
                history.AddRange(_onNotifyKitchen.Execute(order));
            }

            return history;
        }
    }


    /// <summary>
    /// 餐點類別
    /// </summary>
    public class Order
    {
        /// <summary>食物品項</summary>
        public FoodType Type { get; set; }

        /// <summary>數量</summary>
        public int Count { get; set; }

        /// <summary>備註</summary>
        public string Remark { get; set; }

        public string Description()
        {
            var foodNameDic = new Dictionary<FoodType, string>
            {
                {FoodType.Beef, "牛肉"},
                {FoodType.Pork, "豬肉"},
            };
            var description = Count + "份" + foodNameDic[Type];
            if (!string.IsNullOrEmpty(Remark))
            {
                description += ", 並備註：" + Remark;
            }

            return description;
        }
    }

    public enum FoodType
    {
        Pork = 1,
        Beef = 2,
    }
}