using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FancyScrollView;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Data;

namespace UnityClient
{
    public class CharacterInfo
    {
        public uint Id;
        public string Message;
    }
    public class CharacterInfoPanel : FancyScrollView<CharacterInfo, CharacterInfoPanelContext>, IScrollView
    {
        [SerializeField]
        ScrollPositionController scrollPositionController;
        [SerializeField]
        Text characterInfo;
        [SerializeField]
        Text RoundInfo;
        [SerializeField]
        Button LearnButton;
        [SerializeField]
        Button ExerciseButton;
        [SerializeField]
        Button DressingButton;
        [SerializeField]
        Button NextDayButton;

        void Awake()
        {
            scrollPositionController.OnUpdatePosition(p => UpdatePosition(p));
            SetContext(new CharacterInfoPanelContext { OnPressedCell = OnPressedCell });
        }
        public void Start()
        {
            LearnButton.onClick.AddListener(OnPressLearnButton);
            ExerciseButton.onClick.AddListener(OnPressExerciseButton);
            DressingButton.onClick.AddListener(OnPressDressingButton);
            NextDayButton.onClick.AddListener(OnPressNextDayButton);

            List<CharacterInfo> characterInfos = new List<CharacterInfo>();

            var entities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Character).GetEntities();
            foreach(GameEntity entity in entities)
            {
                characterInfos.Add(new CharacterInfo() { Message = entity.name.Value, Id = entity.id.value});
            }
            UpdateData(characterInfos);

            Contexts.sharedInstance.game.SetCharacterInfoPanel(this);
        }
        public void UpdateData(List<CharacterInfo> data)
        {
            cellData = data;
            scrollPositionController.SetDataCount(cellData.Count);
            UpdateContents();
        }
        public void OnPressedCell(CharacterInfoCell cell)
        {
            scrollPositionController.ScrollTo(cell.DataIndex, 0.4f);
            Context.SelectedIndex = cell.DataIndex;
            string characterDescription = GetCharacterDescription(cell.id);
            characterInfo.text = characterDescription;
            UpdateContents();
        }
        public void ScrollToPlayer()
        {
            var entity = Contexts.sharedInstance.game.mainPlayerEntity;
            int index = -1;
            foreach(var cell in cellData)
            {
                if(cell.Id == entity.id.value)
                {
                    index = cellData.IndexOf(cell);
                    break;
                }
            }

            scrollPositionController.ScrollTo(index, 0.4f);
            Context.SelectedIndex = index;
            string characterDescription = GetCharacterDescription(entity.id.value);
            characterInfo.text = characterDescription;
            UpdateContents();
        }
        private string GetCharacterDescription(uint id)
        {
            string result = string.Empty;

            var entity = Contexts.sharedInstance.game.GetEntityWithId(id);
            if(null != entity)
            {
                string name = entity.name.Value;
                float intelligence = entity.attr.Value.Intelligence;
                float charm = entity.attr.Value.Charm;
                float strength = entity.attr.Value.Strength;
                float action = entity.attr.Value.Action;
                float maxAction = entity.attr.Value.ActionMax;
                result = string.Format("姓名：{0}\n智力：{1}\n魅力：{2}\n力量：{3}\n行动力：{4}/{5}", name, intelligence, charm, strength, action, maxAction);
            }
            return result;
        }
        private void OnPressLearnButton()
        {
            Util.LogUtil.Debug("OnPressLearnButton");
            if(CheckCanDoWork(1, Contexts.sharedInstance.game.mainPlayerEntity))
            {
                Contexts.sharedInstance.game.mainPlayerEntity.ReplaceWork(new List<int> { 1 });
            }
            else
            {
                Services.Instance.UIService.ShowMessageBox("没有体力了！", MessageBox.Style.OnlyOK);
            }
        }
        private void OnPressExerciseButton()
        {
            Util.LogUtil.Debug("OnPressExerciseButton");
            if(CheckCanDoWork(1, Contexts.sharedInstance.game.mainPlayerEntity))
            {
                Contexts.sharedInstance.game.mainPlayerEntity.ReplaceWork(new List<int> { 2 });
            }
            else
            {
                Services.Instance.UIService.ShowMessageBox("没有体力了！", MessageBox.Style.OnlyOK);
            }
        }
        private void OnPressDressingButton()
        {
            Util.LogUtil.Debug("OnPressDressingButton");
            if(CheckCanDoWork(1, Contexts.sharedInstance.game.mainPlayerEntity))
            {
                Contexts.sharedInstance.game.mainPlayerEntity.ReplaceWork(new List<int> { 3 });
            }
            else
            {
                Services.Instance.UIService.ShowMessageBox("没有体力了！", MessageBox.Style.OnlyOK);
            }
        }
        private void OnPressNextDayButton()
        {
            Util.LogUtil.Debug("OnPressNextDayButton");
        }
        private bool CheckCanDoWork(int workId, GameEntity entity)
        {
            WorksConfig workConfig = WorksConfigProvider.Instance.GetWorksConfig(workId);
            if (null != workConfig && workConfig.CostAction <= entity.attr.Value.Action)
                return true;
            return false;
        }
    }
    public class CharacterInfoCell : FancyScrollViewCell<CharacterInfo, CharacterInfoPanelContext>
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Text message;
        [SerializeField]
        Image image;
        [SerializeField]
        Button button;

        public uint id;

        private float currentPosition = 0;

        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");

        public override void UpdateContent(CharacterInfo itemData)
        {
            message.text = itemData.Message;
            id = itemData.Id;
            if(Context != null)
            {
                var isSelected = Context.SelectedIndex == DataIndex;
                image.color = isSelected
                    ? new Color32(0, 255, 255, 100)
                    : new Color32(255, 255, 255, 77);
            }
        }
        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }
        void Start()
        {
            button.onClick.AddListener(OnPressedCell);
        }
        void OnPressedCell()
        {
            if (Context != null)
                Context.OnPressedCell(this);
        }
    }
    public class CharacterInfoPanelCreator : MonoBehaviour
    {
        [SerializeField]
        CharacterInfoPanel scrollView;

        void Start()
        {
            var cellData = Enumerable.Range(0, 20).Select(i => new CharacterInfo { Message = "Cell" + i }).ToList();

            scrollView.UpdateData(cellData);
        }
    }
    public class CharacterInfoPanelContext
    {
        public Action<CharacterInfoCell> OnPressedCell;
        public int SelectedIndex;
    }
}
