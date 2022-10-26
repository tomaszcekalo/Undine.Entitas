using Entitas;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.Entitas
{
    public class EntitasContainer : EcsContainer
    {
        public Context<Entity> Context { get; }
        public IComponentTypeIndexer Indexer { get; }
        private List<IExecuteSystem> ExecuteSystems { get; }

        public EntitasContainer(Context<Entity> context = null, IComponentTypeIndexer indexer = null)
        {
            ExecuteSystems = new List<IExecuteSystem>();
            if (context == null)
            {
                context = new Context<Entity>(1024, () => new Entity());
            }
            Context = context;
            if (indexer == null)
            {
                indexer = new ComponentTypeIndexer();
            }
            Indexer = indexer;
        }

        public override void AddSystem<A>(UnifiedSystem<A> system)
        {
            ExecuteSystems.Add(
            new EntitasSystem<A>(Context, Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>())
            {
                System = system
            });
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            ExecuteSystems.Add(
            new EntitasSystem<A, B>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>())
            {
                System = system
            });
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            ExecuteSystems.Add(
            new EntitasSystem<A, B, C>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<C>>())
            {
                System = system
            });
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            ExecuteSystems.Add(
            new EntitasSystem<A, B, C, D>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<C>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<D>>())
            {
                System = system
            });
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            return new EntitasEntity()
            {
                Entity = Context.CreateEntity(),
                Indexer = Indexer,
            };
        }

        public override Core.ISystem GetSystem<A>(UnifiedSystem<A> system)
        {
            return
            new EntitasSystem<A>(Context, Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>())
            {
                System = system
            };
        }

        public override Core.ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            return
            new EntitasSystem<A, B>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>())
            {
                System = system
            };
        }

        public override Core.ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            return
            new EntitasSystem<A, B, C>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<C>>())
            {
                System = system
            };
        }

        public override Core.ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            return
            new EntitasSystem<A, B, C, D>(
                Context,
                Indexer.GetComponentTypeId<EntitasComponentWrapper<A>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<B>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<C>>(),
                Indexer.GetComponentTypeId<EntitasComponentWrapper<D>>())
            {
                System = system
            };
        }

        public override void Run()
        {
            foreach (var item in ExecuteSystems)
                item.Execute();
        }
    }
}