using System;

namespace PizzaBox.Domain.Abstracts
{

    public abstract class AStore
    {
        public string name { get; protected set; }

        public override string ToString()
        {
            return name;
        }
    }
}