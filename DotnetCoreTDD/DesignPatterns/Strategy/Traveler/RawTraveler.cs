using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler
{
    /// <summary>
    /// Traveler without using strategy
    /// </summary>
    public class RawTraveler
    {
        private string _name;

        public RawTraveler(string name)
        {
            _name = name;
        }

        public string Travel(string place, string goby)
        {
            IGotStrategy goStrategy = null;
            switch (goby)
            {
                case "bus":
                    goStrategy = new GoByBus();
                    break;
                case "train":
                default:
                    goStrategy = new GoByTrain();
                    break;
            }
            return _name + goStrategy.Go(place);
        }
    }
}
