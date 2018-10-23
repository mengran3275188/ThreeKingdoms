using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Data;
using Util;

namespace UnityClient
{
    public class RoundSystem : Singleton<RoundSystem>, IInitializeSystem
    {
        public RoundSystem()
        {
        }
        public void Initialize()
        {
        }
        public void NextRound()
        {
            int workCount = WorksConfigProvider.Instance.GetWorksConfigCount();

            var entities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Character).GetEntities();
            foreach(GameEntity entity in entities)
            {
                int actionCost = 0;
                List<int> works = new List<int>();
                while(entity.attr.Value.Action > actionCost)
                {
                    int workId = Util.RandomUtil.Next(1, workCount);
                    WorksConfig workConfig = WorksConfigProvider.Instance.GetWorksConfig(workId);
                    if(null != workConfig)
                    {
                        actionCost += workConfig.CostAction;
                        works.Add(workConfig.Id);
                    }
                }
                entity.ReplaceWork(works);
            }
        }
    }
}
