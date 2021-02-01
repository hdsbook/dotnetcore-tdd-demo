using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Traveler
{
    public interface IGotStrategy
    {
        public string Go(string place);
    }
}
