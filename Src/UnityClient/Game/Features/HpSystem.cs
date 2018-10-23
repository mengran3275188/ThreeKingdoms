using System;
using System.Collections.Generic;
using Entitas;
using Util;

namespace UnityClient
{
    public class HpSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        public HpSystem(Contexts contexts) : base(contexts.game)
        {
            m_Contexts = contexts;
        }
        public void Initialize()
        {
        }

        protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Hp);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnabled;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                if (entity.hp.Value <= 0)
                {
                }
            }
        }
        private readonly Contexts m_Contexts;
    }
}
