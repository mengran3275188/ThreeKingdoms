﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityClient
{
    public class UnitySceneService : Service
    {
        public UnitySceneService(Contexts contexts) : base(contexts)
        {
        }

        public void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        public void Tick()
        {
            float loadProgress = -1f;
            if(null != m_LoadOperation)
            {
                loadProgress = m_LoadOperation.progress;
                _contexts.gameState.ReplaceLoadingProgress(loadProgress);
            }

        }
        public void LoadSceneAsync(int sceneId, string sceneName)
        {
            m_LoadOperation = SceneManager.LoadSceneAsync(sceneName);
            m_CurrentLoadingScene = sceneId;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _contexts.gameState.ReplaceCurSceneId(m_CurrentLoadingScene);
            _contexts.gameState.isSceneLoadFinished = true;
            m_CurrentLoadingScene = -1;
        }

        private AsyncOperation m_LoadOperation;
        private int m_CurrentLoadingScene = -1;

        private const int c_LoadingSceneId = 2;
    }
}
