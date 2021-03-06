﻿using System;
using System.Collections.Generic;
using Entitas;

namespace UnityClient
{
    public class CleanupEntitySystem : ReactiveSystem<GameEntity>
    {
        public CleanupEntitySystem(Contexts contexts) : base(contexts.game)
        {
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Cleanup);
        }
        protected override bool Filter(GameEntity entity)
        {
            return true;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            var gameEntities = Contexts.sharedInstance.game.GetEntities();
            foreach (var entity in gameEntities)
                entity.isDestory = true;

            Contexts.sharedInstance.game.isCleanup = false;
        }
    }
}
