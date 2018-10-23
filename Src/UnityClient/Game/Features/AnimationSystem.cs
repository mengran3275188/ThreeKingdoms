﻿using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Data;
using UnityEngine;

namespace UnityClient
{
    public class AnimationSystem : ReactiveSystem<GameEntity>
    {
        public AnimationSystem(Contexts contexts) : base(contexts.game)
        {
            m_Context = contexts.game;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Animation, GameMatcher.Movement, GameMatcher.Dead, GameMatcher.Born));
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnabled && entity.hasMovement && !(SkillSystem.Instance.IsDisableMoveInput(entity) || BuffSystem.Instance.IsDisableRotationInput(entity));
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities)
            {
                var animation = entity.animation;

                if (entity.hasDead)
                {
                    Services.Instance.ViewService.CrossFadeAnimation(entity, GetAnimationName(animation.ActionId, animation.Prefix, AnimationType.Dead));
                }else if(entity.hasBorn)
                {
                    //Services.Instance.ViewService.CrossFadeAnimation(entity, GetAnimationName(animation.ActionId, animation.Prefix, AnimationType.Born));
                }
                else
                {
                    if( Mathf.Approximately(entity.movement.Velocity.magnitude, 0))
                    {
                        Services.Instance.ViewService.CrossFadeAnimation(entity, GetAnimationName(animation.ActionId, animation.Prefix, AnimationType.Idle));
                    }
                    else
                    {
                        Services.Instance.ViewService.CrossFadeAnimation(entity, GetAnimationName(animation.ActionId, animation.Prefix, AnimationType.Run));
                    }
                }
            }
        }
        private string GetAnimationName(int actionId, string prefix, AnimationType animationType)
        {
            string animationName = string.Empty;

            ActionConfig config = ActionConfigProvider.Instance.GetActionConfig(actionId);
            if(null != config)
            {
                switch(animationType)
                {
                    case AnimationType.Idle:
                        animationName = string.Format("{0}{1}", prefix, config.Stand);
                        break;
                    case AnimationType.Run:
                        animationName = string.Format("{0}{1}", prefix, config.Run);
                        break;
                    case AnimationType.Dead:
                        animationName = string.Format("{0}{1}", prefix, config.Dead);
                        break;
                    case AnimationType.Born:
                        animationName = string.Format("{0}{1}", prefix, config.Born);
                        break;
                }
            }
            return animationName;
        }
        private readonly GameContext m_Context;
    }
}
