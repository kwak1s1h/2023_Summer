using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class LunchUI : WindowUI
{
    private TextField _dateTextField;
    private Label _lunchLabel;

    public LunchUI(VisualElement root) : base(root)
    {
        _lunchLabel = _root.Q<Label>(name: "LunchLabel");
        _dateTextField = _root.Q<TextField>(name: "DateTextField");
        _root.Q<Button>(name: "LoadBtn").RegisterCallback<ClickEvent>(OnLoadButtonHandle);
        _root.Q<Button>(name: "CloseBtn").RegisterCallback<ClickEvent>(OnCloseButtonHandle);
    }

    private void OnLoadButtonHandle(ClickEvent evt)
    {
        string dateStr = _dateTextField.value;
        Regex regex = new Regex(@"20[0-9]{2}[0-1][0-9][0-3][0-9]");
        if(!regex.IsMatch(dateStr))
        {
            UIController.Instance.MessageSystem.AddMessage("이러시는 이유가 있을 거 아니에요", 2);
            return;
        }


        NetworkManager.Instance.GetRequest("lunch", $"?date={dateStr}", (type, msg) =>
        {
            if(type == MessageType.SUCCESS)
            {
                LunchVO lunch = JsonUtility.FromJson<LunchVO>(msg);
                string menuStr = "";
                foreach(string menu in lunch.menus)
                {
                    menuStr += menu;
                    menuStr += "\n";
                }
                _lunchLabel.text = menuStr;
            }
            else
            {
                UIController.Instance.MessageSystem.AddMessage(msg, 2);
            }
        });
    }

    private void OnCloseButtonHandle(ClickEvent evt)
    {
        Close();
    }
}
