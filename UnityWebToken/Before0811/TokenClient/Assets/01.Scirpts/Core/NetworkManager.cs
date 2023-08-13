using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Networking;

public enum MessageType
{
    ERROR = 1,
    SUCCESS = 2,
    EMPTY = 3,
}

public class NetworkManager
{
    public static NetworkManager Instance;

    private string _host;
    private int _port;

    public NetworkManager(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public void GetRequest(string uri, string query, Action<MessageType, string> callback)
    {
        GameManager.Instance.StartCoroutine(GetCoroutine(uri, query, callback));
    }

    public void PostRequest(string uri, Payload payload, Action<MessageType, string> callback)
    {
        GameManager.Instance.StartCoroutine(PostCoroutine(uri, payload, callback));
    }

    public void DoAuth()
    {
        GetRequest("user", "", (type, json) => {
            if(type == MessageType.SUCCESS)
            {
                UserVO user = JsonUtility.FromJson<UserVO>(json);
                UIController.Instance.SetLogin(user);
            }
        });
    }

    private IEnumerator GetCoroutine(string uri, string query, Action<MessageType, string> callback)
    {
        string url = $"{_host}:{_port}/{uri}{query}";
        UnityWebRequest req = UnityWebRequest.Get(url);
        SetRequestToken(req);
        yield return req.SendWebRequest();

        if(req.result != UnityWebRequest.Result.Success )
        {
            callback.Invoke(MessageType.ERROR, $"{req.responseCode}_Error on Get");
            yield break;
        }

        MessageDTO msg = JsonUtility.FromJson<MessageDTO>(req.downloadHandler.text);
        callback.Invoke(msg.type, msg.message);
        Debug.Log(req.downloadHandler.text);
    }

    private IEnumerator PostCoroutine(string uri, Payload payload, Action<MessageType, string> callback)
    {
        string url = $"{_host}:{_port}/{uri}";
        UnityWebRequest req = UnityWebRequest.Post(url, payload.GetJsonString(), "application/json");
        SetRequestToken(req);
        yield return req.SendWebRequest();

        if(req.result != UnityWebRequest.Result.Success )
        {
            UIController.Instance.MessageSystem.AddMessage("��û�� �����߽��ϴ�. {req.responseCode} Error on post", 3f);
            yield break;
        }

        MessageDTO msg = JsonUtility.FromJson<MessageDTO>(req.downloadHandler.text);
        callback.Invoke(msg.type, msg.message);
    }

    private void SetRequestToken(UnityWebRequest req)
    {
        if(!string.IsNullOrEmpty(GameManager.Instance.Token))
        {
            req.SetRequestHeader("Authorization", $"Bearer{GameManager.Instance.Token}");
        }
    }
}
