using Entitas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Entitas
{
    public class EntitasComponentWrapper<A> : IComponent
    {
        public A Component;

        public override string ToString()
        {
            return Component.ToString();
        }
    }
}