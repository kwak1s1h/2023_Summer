using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Reflection;
using UnityEngine.SceneManagement;
using System;

public enum LoadingState
{
    None,
    Unload,
    GotoScene,
    Done,
}

public class UILoading : MonoBehaviour
{
    private AsyncOperation _unloadDone, _loadLevelDone;
    private LoadingState _myState;
    private StringBuilder _sb;

    private float _timeLimit; // minimun loading time

    private readonly string MainSceneName = "MainScene";

    private void Awake()
    {
        _sb = new StringBuilder();
    }

    private void Start()
    {
        _myState = LoadingState.None;
        NextState();
    }

    private void NextState()
    {
        _sb.Remove(0, _sb.Length);
        _sb.Append(_myState.ToString());
        _sb.Append("State");
        
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        MethodInfo methodInfo = GetType().GetMethod(_sb.ToString(), flags);
        StartCoroutine((IEnumerator)methodInfo.Invoke(this, null));
    }

    // Coroutines
    private IEnumerator NoneState()
    {
        _myState = LoadingState.Unload;
        while(_myState == LoadingState.None)
        {
            yield return null;
        }

        NextState();
    }

    private IEnumerator UnloadState()
    {
        _unloadDone = Resources.UnloadUnusedAssets();
        GC.Collect();

        while(_myState == LoadingState.Unload)
        {
            if(_unloadDone.isDone)
            {
                _myState = LoadingState.GotoScene;
            }
            yield return null;
        }
        NextState();
    }

    private IEnumerator GotoSceneState()
    {
        _loadLevelDone = SceneManager.LoadSceneAsync(MainSceneName);
        _timeLimit = 3.0f;

        while(_myState == LoadingState.GotoScene)
        {
            _timeLimit -= Time.deltaTime;
            if(_loadLevelDone.isDone && _timeLimit <= 0)
            {
                _myState = LoadingState.Done;
            }
            yield return null;
        }
        NextState();
    }

    private IEnumerator DoneState()
    {
        MGScene.Instance.LoadingDone();

        while(_myState == LoadingState.Done)
        {
            yield return null;
        }
    }
}
