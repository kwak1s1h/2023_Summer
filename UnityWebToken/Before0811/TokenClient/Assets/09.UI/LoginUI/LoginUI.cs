using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class LoginUI : WindowUI
{
    public const string TokenKey = "token";

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
            if(type == MessageType.SUCCESS) {
                TokenResponseDTO dto = JsonUtility.FromJson<TokenResponseDTO>(json);
                GameManager.Instance.Token = dto.token;
                PlayerPrefs.SetString(TokenKey, dto.token);
                NetworkManager.Instance.DoAuth();
                Close();
            }
            else {
                UIController.Instance.MessageSystem.AddMessage(json, 3f);
                _emailField.value = "";
                _passwordField.value = "";
            }
        });
    }

    private void OnCloseButtonHandle(ClickEvent evt)
    {
        Close();
    }
}
