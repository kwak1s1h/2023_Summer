using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UserInfoPanel
{
    private VisualElement _root;
    private Button _infoButton;

    public string Username
    {
        get => _infoButton.text;
        set => _infoButton.text = value;
    }

    public UserInfoPanel(VisualElement root, EventCallback<ClickEvent> logoutHandler)
    {
        _root = root;
        _infoButton = _root.Q<Button>("InfoBtn");
        
        root.Q<Button>("LogoutBtn").RegisterCallback(logoutHandler);
    }

    public void Show(bool v)
    {
        if(v) _root.RemoveFromClassList("off");
        else _root.AddToClassList("off");
    }
}
