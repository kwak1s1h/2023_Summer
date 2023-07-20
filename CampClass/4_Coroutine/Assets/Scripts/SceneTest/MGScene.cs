using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    None = -1,
    Loading,
    Logo,
    Title,
    Game,
}

public class MGScene : MonoBehaviour
{
    private static MGScene _instance = null;
    public static MGScene Instance 
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(MGScene)) as MGScene;
                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<MGScene>();
                }
            }
            return _instance;
        }
    }

    private StringBuilder _sb;

    private SceneName _currentScene;

    public GameObject _uiRootPrefab; // This is Hard Coding
    public GameObject _loadingUIPrefab;
    public GameObject _logoUIPrefab;
    public GameObject _titleUIPrefab;
    public GameObject _gameUIPrefab;

    private Transform _uiRootTrm; // Root of each scene's UI;
    private Transform _addUITrm; // UI exist each scene

    public void Generate()
    {

    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        _sb = new StringBuilder();
        GameObject uiRoot = GameObject.Instantiate(_uiRootPrefab);
        _uiRootTrm = uiRoot.transform;

        InitScene();
    }

    private void InitScene()
    {
        ChangeScene(SceneName.Logo);
    }

    public void ChangeScene(SceneName scene)
    {
        _currentScene = scene;

        _sb.Remove(0, _sb.Length);
        _sb.AppendFormat("{0}Scene", SceneName.Loading);

        SceneManager.LoadScene(_sb.ToString());

        ChangeUI(SceneName.Loading);
    }

    private void ChangeUI(SceneName scene)
    {
        if(_addUITrm != null)
        {
            _addUITrm.SetParent(null);
            GameObject.Destroy(_addUITrm.gameObject);
        }

        GameObject obj = null;

        if(scene == SceneName.Loading)
        {
            obj = GameObject.Instantiate(_loadingUIPrefab);
        }
        else if(scene == SceneName.Logo)
            obj = GameObject.Instantiate(_logoUIPrefab) as GameObject;
        else if(scene == SceneName.Title)
            obj = GameObject.Instantiate(_titleUIPrefab) as GameObject;
        else if(scene == SceneName.Game)
            obj = GameObject.Instantiate(_gameUIPrefab) as GameObject;

        _addUITrm = obj.transform;
        _addUITrm.SetParent(_uiRootTrm);

        _addUITrm.localPosition = Vector3.zero;
        _addUITrm.localScale = Vector3.one;

        RectTransform rectTrm = obj.GetComponent<RectTransform>();
        rectTrm.offsetMax = Vector2.zero;
        rectTrm.offsetMin = Vector2.zero;
    }

    public void LoadingDone()
    {
        ChangeUI(_currentScene);
        Debug.Log("Loading Complete");
    }
}
