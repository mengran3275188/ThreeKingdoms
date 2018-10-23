using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDelegate;
using UnityEngine;

namespace UnityClient
{
    public class CharacterViewPanelService : Service
    {
        public CharacterViewPanelService(Contexts contexts) : base(contexts)
        {
        }
        public void JumpToPlayer()
        {
            CharacterInfoPanel panel = _contexts.game.characterInfoPanel.CharacterScrollView as CharacterInfoPanel;
            panel.ScrollToPlayer();
        }
    }
}
