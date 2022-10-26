using Entitas;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.Entitas
{
    public class EntitasEntity : IUnifiedEntity
    {
        public Entity Entity { get; set; }
        public IComponentTypeIndexer Indexer { get; set; }

        public void AddComponent<A>(in A component) where A : struct
        {
            Entity.AddComponent(Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(), new EntitasComponentWrapper<A>()
            {
                Component = component
            });
        }

        public ref A GetComponent<A>() where A : struct
        {
            return ref ((EntitasComponentWrapper<A>)Entity.GetComponent(Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>())).Component;
        }
    }
}