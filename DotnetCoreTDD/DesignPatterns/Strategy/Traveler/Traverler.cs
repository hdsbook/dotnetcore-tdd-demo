using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler
{
    public class Traveler
    {
        private string _name;
        private IGotStrategy _goStrategy;

        public Traveler(string name, IGotStrategy goStrategy)
        {
            _name = name;
            _goStrategy = goStrategy;
        }

        public string Travel(string place)
        {
            return _name + _goStrategy.Go(place);
        }
    }
}
