using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Data;

namespace UnityClient
{
    public class WorkSystem : ReactiveSystem<GameEntity>
    {
        public WorkSystem(Contexts contexts) : base(contexts.game)
        {
            m_Context = contexts.game;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Work);
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWork && entity.work.Value.Count > 0;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities)
            {
                foreach(int workId in entity.work.Value)
                {
                    WorksConfig workConfig = WorksConfigProvider.Instance.GetWorksConfig(workId);
                    if(null != workConfig)
                    {
                        if(entity.attr.Value.Action >= workConfig.CostAction)
                        {
                            entity.attr.Value.SetAction(Operate_Type.OT_Relative, -workConfig.CostAction);
                            entity.attr.Value.SetAttributeByType((AttrbuteEnum)workConfig.AddAttrType, Operate_Type.OT_Relative, workConfig.AddAttrValue);
                        }
                    }
                }
                entity.work.Value.Clear();
            }

            Services.Instance.CharacterPanelService.JumpToPlayer();
        }
        private readonly GameContext m_Context;
    }
}
