﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Data;
using UnityEngine;

namespace UnityClient
{
    // read input and write to global InputComponent
    public class InputSystem : IInitializeSystem, IExecuteSystem
    {
        internal enum KeyHit
        {
            None = 0,
            Up = 1,
            Down = 2,
            Left = 4,
            Right = 8,
            Other = 16,
        }
        public InputSystem(Contexts contexts)
        {
        }
        public void Initialize()
        {
            Services.Instance.InputService.ListenKeyPressState(
                Keyboard.Code.W,
                Keyboard.Code.A,
                Keyboard.Code.S,
                Keyboard.Code.D);

            Services.Instance.InputService.ListenKeyboardEvent(Keyboard.Code.T, this.ChangeScene);
            Services.Instance.InputService.ListenKeyboardEvent(Keyboard.Code.M, this.OpenCharacterViewPanel);
        }
        public void Execute()
        {
            Services.Instance.InputService.Tick();
            // keyboard
            KeyHit kh = GetKeyboadHit();

            float moveDir = CalcMoveDir(kh);
            bool isMoving = moveDir >= 0;

            if (!isMoving)
                isMoving = GfxSystem.GetJoyStickDir(out moveDir);

            GameContext gameContext = Contexts.sharedInstance.game;

            GameEntity mainPlayer = gameContext.mainPlayerEntity;
            if (null != mainPlayer)
            {
                if (mainPlayer.hasMovement)
                {
                    if (!(SkillSystem.Instance.IsDisableMoveInput(mainPlayer) || BuffSystem.Instance.IsDisableMoveInput(mainPlayer)))
                    {
                        if (mainPlayer.hasAttr)
                        {
                        }
                    }
                }
                if (isMoving && !Mathf.Approximately(moveDir, mainPlayer.rotation.Value))
                {
                    if (!(SkillSystem.Instance.IsDisableRotationInput(mainPlayer) || BuffSystem.Instance.IsDisableRotationInput(mainPlayer)))
                        mainPlayer.ReplaceRotation(moveDir);
                }
                if (isMoving)
                    SkillSystem.Instance.BreakSkill(mainPlayer, SkillBreakType.Move);
            }
        }

        private void ChangeScene(int keyCode, int what)
        {
            if ((int)Keyboard.Event.Down == what)
            {
                Contexts.sharedInstance.game.isCleanup = true;
                Contexts.sharedInstance.gameState.ReplaceNextSceneId(2);
                Contexts.sharedInstance.gameState.ReplaceTargetSceneId(3);
            }
        }
        private void OpenCharacterViewPanel(int keyCode, int what)
        {
            if((int)Keyboard.Event.Down == what)
            {
                RoundSystem.Instance.NextRound();
            }
        }
        private KeyHit GetKeyboadHit()
        {
            KeyHit kh = KeyHit.None;
            if (Services.Instance.InputService.IsKeyPressed(Keyboard.Code.W))
                kh |= KeyHit.Up;
            if (Services.Instance.InputService.IsKeyPressed(Keyboard.Code.A))
                kh |= KeyHit.Left;
            if (Services.Instance.InputService.IsKeyPressed(Keyboard.Code.S))
                kh |= KeyHit.Down;
            if (Services.Instance.InputService.IsKeyPressed(Keyboard.Code.D))
                kh |= KeyHit.Right;

            return kh;
        }
        private float CalcMoveDir(KeyHit kh)
        {
            return s_MoveDirs[(int)kh];
        }


        private static readonly float[] s_MoveDirs = new float[] { -1,  0, (float)Math.PI, -1, 3*(float)Math.PI/2, 7*(float)Math.PI/4, 5*(float)Math.PI/4,
                            3*(float)Math.PI/2, (float)Math.PI/2, (float)Math.PI/4, 3*(float)Math.PI/4, (float)Math.PI/2, -1, 0,   (float)Math.PI, -1 };

        private const float c_2PI = (float)Math.PI * 2;
    }
}
