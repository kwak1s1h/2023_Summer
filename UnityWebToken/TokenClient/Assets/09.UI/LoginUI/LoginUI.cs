using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class LoginUI : WindowUI
{
    private TextField _emailField;
    private TextField _passwordField;

    public LoginUI(VisualElement root) : base(root)
    {
        _emailField = _root.Q<TextField>(name: "EmailInput");
        _passwordField = _root.Q<TextField>(name: "PasswordInput");
        _root.Q<Button>(name: "OkBtn").RegisterCallback<ClickEvent>(OnLoginButtonHandle);
        _root.Q<Button>(name: "CancelBtn").RegisterCallback<ClickEvent>(OnCloseButtonHandle);
    }

    private void OnLoginButtonHandle(ClickEvent evt)
    {
        LoginDTO payload = new LoginDTO { email = _emailField.value, password = _passwordField.value };
        NetworkManager.Instance.PostRequest("user/login", payload, (type, json) =>
        {
            Debug.Log(type);
            Debug.Log(json);
        });
    }

    private void OnCloseButtonHandle(ClickEvent evt)
    {
        Close();
    }
}
