using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler
{
    public class GoByBus: IGotStrategy
    {
        public string Go(string place)
        {
            return "搭巴士去" + place;
        }
    }
}
