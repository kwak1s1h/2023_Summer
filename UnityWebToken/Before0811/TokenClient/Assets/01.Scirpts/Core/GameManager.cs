using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _host;
    [SerializeField] private int _port;

    public static GameManager Instance;

    private string _token;
    public string Token
    {
        get => _token;
        set => _token = value;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        Instance = this;

        NetworkManager.Instance = new NetworkManager(_host, _port);

        _token = PlayerPrefs.GetString(LoginUI.TokenKey, string.Empty);
        if(_token != string.Empty) 
        {
            NetworkManager.Instance.DoAuth();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            NetworkManager.Instance.GetRequest("lunch", "?date=20230704", (type, message) =>
            {
                if(type == MessageType.SUCCESS)
                {
                    LunchVO lunch = JsonUtility.FromJson<LunchVO>(message);
                    foreach(string menu in lunch.menus)
                    {
                        Debug.Log(menu);
                    }
                }
                else
                {
                    Debug.Log(message);
                }
            });
        }
    }

    internal void DestroyToken()
    {
        PlayerPrefs.DeleteKey(LoginUI.TokenKey);
        Token = string.Empty;
    }
}
