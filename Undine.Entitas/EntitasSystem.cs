using Entitas;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.Entitas
{
    internal class EntitasSystem<A> : JobSystem<Entity>, Core.ISystem
         where A : struct
    {
        public int ComponentIndex { get; }
        public UnifiedSystem<A> System { get; set; }

        public EntitasSystem(Context<Entity> context, int index)
            : base(context.GetGroup(Matcher<Entity>.AllOf(index)))
        {
            ComponentIndex = index;
        }

        public void ProcessAll()
        {
        }

        protected override void Execute(Entity entity)
        {
            System.ProcessSingleEntity(entity.GetHashCode(), ref ((EntitasComponentWrapper<A>)entity.GetComponent(ComponentIndex)).Component);
        }
    }

    internal class EntitasSystem<A, B> : JobSystem<Entity>, Core.ISystem
         where A : struct
         where B : struct
    {
        public int AComponentIndex { get; }
        public int BComponentIndex { get; }
        public UnifiedSystem<A, B> System { get; set; }

        public EntitasSystem(Context<Entity> context, int indexA, int indexB)
            : base(context.GetGroup(Matcher<Entity>.AllOf(
                indexA,
                indexB
                )))
        {
            AComponentIndex = indexA;
            BComponentIndex = indexB;
        }

        public void ProcessAll()
        {
        }

        protected override void Execute(Entity entity)
        {
            System.ProcessSingleEntity(
                entity.GetHashCode(),
                ref ((EntitasComponentWrapper<A>)entity.GetComponent(AComponentIndex)).Component,
                ref ((EntitasComponentWrapper<B>)entity.GetComponent(BComponentIndex)).Component
                );
        }
    }

    internal class EntitasSystem<A, B, C> : JobSystem<Entity>, Core.ISystem
         where A : struct
         where B : struct
         where C : struct
    {
        public int AComponentIndex { get; }
        public int BComponentIndex { get; }
        public int CComponentIndex { get; }
        public UnifiedSystem<A, B, C> System { get; set; }

        public EntitasSystem(Context<Entity> context, int indexA, int indexB, int indexC)
            : base(context.GetGroup(Matcher<Entity>.AllOf(
                indexA,
                indexB,
                indexC
                )))
        {
            AComponentIndex = indexA;
            BComponentIndex = indexB;
            CComponentIndex = indexC;
        }

        public void ProcessAll()
        {
        }

        protected override void Execute(Entity entity)
        {
            System.ProcessSingleEntity(
                entity.GetHashCode(),
                ref ((EntitasComponentWrapper<A>)entity.GetComponent(AComponentIndex)).Component,
                ref ((EntitasComponentWrapper<B>)entity.GetComponent(BComponentIndex)).Component,
                ref ((EntitasComponentWrapper<C>)entity.GetComponent(CComponentIndex)).Component
                );
        }
    }

    internal class EntitasSystem<A, B, C, D> : JobSystem<Entity>, Core.ISystem
         where A : struct
         where B : struct
         where C : struct
         where D : struct
    {
        public int AComponentIndex { get; }
        public int BComponentIndex { get; }
        public int CComponentIndex { get; }
        public int DComponentIndex { get; }
        public UnifiedSystem<A, B, C, D> System { get; set; }

        public EntitasSystem(Context<Entity> context, int indexA, int indexB, int indexC, int indexD)
            : base(context.GetGroup(Matcher<Entity>.AllOf(
                indexA,
                indexB,
                indexC,
                indexD
                )))
        {
            AComponentIndex = indexA;
            BComponentIndex = indexB;
            CComponentIndex = indexC;
            CComponentIndex = indexD;
        }

        public void ProcessAll()
        {
        }

        protected override void Execute(Entity entity)
        {
            System.ProcessSingleEntity(
                entity.GetHashCode(),
                ref ((EntitasComponentWrapper<A>)entity.GetComponent(AComponentIndex)).Component,
                ref ((EntitasComponentWrapper<B>)entity.GetComponent(BComponentIndex)).Component,
                ref ((EntitasComponentWrapper<C>)entity.GetComponent(CComponentIndex)).Component,
                ref ((EntitasComponentWrapper<D>)entity.GetComponent(DComponentIndex)).Component
                );
        }
    }
}