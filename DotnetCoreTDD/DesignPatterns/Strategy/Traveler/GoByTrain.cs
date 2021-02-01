using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler
{
    public class GoByTrain: IGotStrategy
    {
        public string Go(string place)
        {
            return "搭火車去" + place;
        }
    }
}
