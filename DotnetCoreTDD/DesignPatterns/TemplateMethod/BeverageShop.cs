using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.TemplateMethod
{
    public class BeverageShop
    {
        public abstract class BeverageShopTemplate
        {
            protected string Drink { get; set; }

            public List<string> Make()
            {
                var history = new List<string>();
                history.Add(BoilWater());
                history.Add(MainMake());
                history.Add(PourIntoCup());
                history.Add(AddIngredients());
                return history;
            }

            protected string BoilWater()
            {
                var boilWater = "把水煮沸";
                return boilWater;
            }

            protected abstract string MainMake();

            protected string PourIntoCup()
            {
                return "把" + Drink + "倒進杯子";
            }

            protected abstract string AddIngredients();
        }

        public class Coffee : BeverageShopTemplate
        {
            protected override string MainMake()
            {
                Drink = "咖啡";
                return "用沸水沖泡咖啡";
            }

            protected override string AddIngredients()
            {
                return "加糖和牛奶";
            }
        }

        public class Tea : BeverageShopTemplate
        {
            protected override string MainMake()
            {
                Drink = "茶";
                return "用沸水浸泡茶葉";
            }

            protected override string AddIngredients()
            {
                return "加檸檬";
            }
        }
    }
}