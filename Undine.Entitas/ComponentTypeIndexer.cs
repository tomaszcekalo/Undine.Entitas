using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Entitas
{
    public interface IComponentTypeIndexer
    {
        int GetComponentTypeId<T>();
    }

    internal class ComponentTypeIndexer : IComponentTypeIndexer
    {
        public Dictionary<Type, int> _componentTypes;

        public ComponentTypeIndexer(Dictionary<Type, int> componentTypes = null)
        {
            if (componentTypes == null)
            {
                componentTypes = new Dictionary<Type, int>();
            }
            _componentTypes = componentTypes;
        }

        public int GetComponentTypeId<T>()
        {
            var type = typeof(T);
            if (!_componentTypes.ContainsKey(type))
            {
                _componentTypes.Add(type, _componentTypes.Keys.Count);
            }
            return _componentTypes[type];
        }
    }
}