//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity curSceneIdEntity { get { return GetGroup(GameStateMatcher.CurSceneId).GetSingleEntity(); } }
    public Entitas.Data.CurSceneIdComponent curSceneId { get { return curSceneIdEntity.curSceneId; } }
    public bool hasCurSceneId { get { return curSceneIdEntity != null; } }

    public GameStateEntity SetCurSceneId(int newValue) {
        if (hasCurSceneId) {
            throw new Entitas.EntitasException("Could not set CurSceneId!\n" + this + " already has an entity with Entitas.Data.CurSceneIdComponent!",
                "You should check if the context already has a curSceneIdEntity before setting it or use context.ReplaceCurSceneId().");
        }
        var entity = CreateEntity();
        entity.AddCurSceneId(newValue);
        return entity;
    }

    public void ReplaceCurSceneId(int newValue) {
        var entity = curSceneIdEntity;
        if (entity == null) {
            entity = SetCurSceneId(newValue);
        } else {
            entity.ReplaceCurSceneId(newValue);
        }
    }

    public void RemoveCurSceneId() {
        curSceneIdEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity nextSceneIdEntity { get { return GetGroup(GameStateMatcher.NextSceneId).GetSingleEntity(); } }
    public Entitas.Data.NextSceneIdComponent nextSceneId { get { return nextSceneIdEntity.nextSceneId; } }
    public bool hasNextSceneId { get { return nextSceneIdEntity != null; } }

    public GameStateEntity SetNextSceneId(int newValue) {
        if (hasNextSceneId) {
            throw new Entitas.EntitasException("Could not set NextSceneId!\n" + this + " already has an entity with Entitas.Data.NextSceneIdComponent!",
                "You should check if the context already has a nextSceneIdEntity before setting it or use context.ReplaceNextSceneId().");
        }
        var entity = CreateEntity();
        entity.AddNextSceneId(newValue);
        return entity;
    }

    public void ReplaceNextSceneId(int newValue) {
        var entity = nextSceneIdEntity;
        if (entity == null) {
            entity = SetNextSceneId(newValue);
        } else {
            entity.ReplaceNextSceneId(newValue);
        }
    }

    public void RemoveNextSceneId() {
        nextSceneIdEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity targetSceneIdEntity { get { return GetGroup(GameStateMatcher.TargetSceneId).GetSingleEntity(); } }
    public Entitas.Data.TargetSceneIdComponent targetSceneId { get { return targetSceneIdEntity.targetSceneId; } }
    public bool hasTargetSceneId { get { return targetSceneIdEntity != null; } }

    public GameStateEntity SetTargetSceneId(int newValue) {
        if (hasTargetSceneId) {
            throw new Entitas.EntitasException("Could not set TargetSceneId!\n" + this + " already has an entity with Entitas.Data.TargetSceneIdComponent!",
                "You should check if the context already has a targetSceneIdEntity before setting it or use context.ReplaceTargetSceneId().");
        }
        var entity = CreateEntity();
        entity.AddTargetSceneId(newValue);
        return entity;
    }

    public void ReplaceTargetSceneId(int newValue) {
        var entity = targetSceneIdEntity;
        if (entity == null) {
            entity = SetTargetSceneId(newValue);
        } else {
            entity.ReplaceTargetSceneId(newValue);
        }
    }

    public void RemoveTargetSceneId() {
        targetSceneIdEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity loadingProgressEntity { get { return GetGroup(GameStateMatcher.LoadingProgress).GetSingleEntity(); } }
    public Entitas.Data.LoadingProgressComponent loadingProgress { get { return loadingProgressEntity.loadingProgress; } }
    public bool hasLoadingProgress { get { return loadingProgressEntity != null; } }

    public GameStateEntity SetLoadingProgress(float newValue) {
        if (hasLoadingProgress) {
            throw new Entitas.EntitasException("Could not set LoadingProgress!\n" + this + " already has an entity with Entitas.Data.LoadingProgressComponent!",
                "You should check if the context already has a loadingProgressEntity before setting it or use context.ReplaceLoadingProgress().");
        }
        var entity = CreateEntity();
        entity.AddLoadingProgress(newValue);
        return entity;
    }

    public void ReplaceLoadingProgress(float newValue) {
        var entity = loadingProgressEntity;
        if (entity == null) {
            entity = SetLoadingProgress(newValue);
        } else {
            entity.ReplaceLoadingProgress(newValue);
        }
    }

    public void RemoveLoadingProgress() {
        loadingProgressEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateContext {

    public GameStateEntity sceneLoadFinishedEntity { get { return GetGroup(GameStateMatcher.SceneLoadFinished).GetSingleEntity(); } }

    public bool isSceneLoadFinished {
        get { return sceneLoadFinishedEntity != null; }
        set {
            var entity = sceneLoadFinishedEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isSceneLoadFinished = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public Entitas.Data.CurSceneIdComponent curSceneId { get { return (Entitas.Data.CurSceneIdComponent)GetComponent(GameStateComponentsLookup.CurSceneId); } }
    public bool hasCurSceneId { get { return HasComponent(GameStateComponentsLookup.CurSceneId); } }

    public void AddCurSceneId(int newValue) {
        var index = GameStateComponentsLookup.CurSceneId;
        var component = CreateComponent<Entitas.Data.CurSceneIdComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurSceneId(int newValue) {
        var index = GameStateComponentsLookup.CurSceneId;
        var component = CreateComponent<Entitas.Data.CurSceneIdComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurSceneId() {
        RemoveComponent(GameStateComponentsLookup.CurSceneId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public Entitas.Data.NextSceneIdComponent nextSceneId { get { return (Entitas.Data.NextSceneIdComponent)GetComponent(GameStateComponentsLookup.NextSceneId); } }
    public bool hasNextSceneId { get { return HasComponent(GameStateComponentsLookup.NextSceneId); } }

    public void AddNextSceneId(int newValue) {
        var index = GameStateComponentsLookup.NextSceneId;
        var component = CreateComponent<Entitas.Data.NextSceneIdComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceNextSceneId(int newValue) {
        var index = GameStateComponentsLookup.NextSceneId;
        var component = CreateComponent<Entitas.Data.NextSceneIdComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveNextSceneId() {
        RemoveComponent(GameStateComponentsLookup.NextSceneId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public Entitas.Data.TargetSceneIdComponent targetSceneId { get { return (Entitas.Data.TargetSceneIdComponent)GetComponent(GameStateComponentsLookup.TargetSceneId); } }
    public bool hasTargetSceneId { get { return HasComponent(GameStateComponentsLookup.TargetSceneId); } }

    public void AddTargetSceneId(int newValue) {
        var index = GameStateComponentsLookup.TargetSceneId;
        var component = CreateComponent<Entitas.Data.TargetSceneIdComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTargetSceneId(int newValue) {
        var index = GameStateComponentsLookup.TargetSceneId;
        var component = CreateComponent<Entitas.Data.TargetSceneIdComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTargetSceneId() {
        RemoveComponent(GameStateComponentsLookup.TargetSceneId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public Entitas.Data.LoadingProgressComponent loadingProgress { get { return (Entitas.Data.LoadingProgressComponent)GetComponent(GameStateComponentsLookup.LoadingProgress); } }
    public bool hasLoadingProgress { get { return HasComponent(GameStateComponentsLookup.LoadingProgress); } }

    public void AddLoadingProgress(float newValue) {
        var index = GameStateComponentsLookup.LoadingProgress;
        var component = CreateComponent<Entitas.Data.LoadingProgressComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLoadingProgress(float newValue) {
        var index = GameStateComponentsLookup.LoadingProgress;
        var component = CreateComponent<Entitas.Data.LoadingProgressComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadingProgress() {
        RemoveComponent(GameStateComponentsLookup.LoadingProgress);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    static readonly Entitas.Data.SceneLoadFinishedComponent sceneLoadFinishedComponent = new Entitas.Data.SceneLoadFinishedComponent();

    public bool isSceneLoadFinished {
        get { return HasComponent(GameStateComponentsLookup.SceneLoadFinished); }
        set {
            if (value != isSceneLoadFinished) {
                var index = GameStateComponentsLookup.SceneLoadFinished;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : sceneLoadFinishedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherCurSceneId;

    public static Entitas.IMatcher<GameStateEntity> CurSceneId {
        get {
            if (_matcherCurSceneId == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.CurSceneId);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherCurSceneId = matcher;
            }

            return _matcherCurSceneId;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherNextSceneId;

    public static Entitas.IMatcher<GameStateEntity> NextSceneId {
        get {
            if (_matcherNextSceneId == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.NextSceneId);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherNextSceneId = matcher;
            }

            return _matcherNextSceneId;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherTargetSceneId;

    public static Entitas.IMatcher<GameStateEntity> TargetSceneId {
        get {
            if (_matcherTargetSceneId == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.TargetSceneId);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherTargetSceneId = matcher;
            }

            return _matcherTargetSceneId;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherLoadingProgress;

    public static Entitas.IMatcher<GameStateEntity> LoadingProgress {
        get {
            if (_matcherLoadingProgress == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.LoadingProgress);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherLoadingProgress = matcher;
            }

            return _matcherLoadingProgress;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherSceneLoadFinished;

    public static Entitas.IMatcher<GameStateEntity> SceneLoadFinished {
        get {
            if (_matcherSceneLoadFinished == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.SceneLoadFinished);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherSceneLoadFinished = matcher;
            }

            return _matcherSceneLoadFinished;
        }
    }
}