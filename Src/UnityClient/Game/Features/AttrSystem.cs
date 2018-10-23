﻿using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Data;
using Util;

namespace UnityClient
{
    public class AttrSystem : IExecuteSystem
    {
        public AttrSystem(Contexts contexts)
        {
            m_Context = contexts.game;
            m_AttrGroup = m_Context.GetGroup(GameMatcher.BuffAttrChanged);
        }
        public void Execute()
        {
            var entities = m_AttrGroup.GetEntities();
            foreach(var entity in entities)
            {
                entity.isBuffAttrChanged = false;

                if (!entity.hasAttr || !entity.hasBuff)
                    continue;

                AttributeConfig attrConfig = AttributeConfigProvider.Instance.GetAttributeConfig(entity.attr.Id);
                if(null != attrConfig)
                {
                    AttributeData attrData = entity.attr.Value;
                    attrData.SetAbsoluteByConfig(attrConfig);
                }
            }
        }

        public static float CalcDamage()
        {
            return 1.0f;
        }

        private GameContext m_Context;
        private IGroup<GameEntity> m_AttrGroup;
    }
}
