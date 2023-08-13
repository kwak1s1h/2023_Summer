using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGameUI : WindowUI
{
    private List<VisualElement> _slots = new List<VisualElement>();

    private VisualElement _btns;

    public MiniGameUI(VisualElement root) : base(root)
    {
        _slots.Add(root.Q("0"));
        _slots.Add(root.Q("1"));
        _slots.Add(root.Q("2"));

        Button slot10Btn = root.Q<Button>("Slot10Btn");
        Button slot50Btn = root.Q<Button>("Slot50Btn");
        Button slot100Btn = root.Q<Button>("Slot100Btn");
        _stopBtn = root.Q<Button>("StopBtn");
        _stopBtn.SetEnabled(false);

        _btns = root.Q("Btns");

        slot10Btn.RegisterCallback<ClickEvent>(evt => OnSlotBtn(10));
        slot50Btn.RegisterCallback<ClickEvent>(evt => OnSlotBtn(50));
        slot100Btn.RegisterCallback<ClickEvent>(evt => OnSlotBtn(100));
    }

    private void OnSlotBtn(int money)
    {
        NetworkManager.Instance.GetRequest("slot", $"?used={money}", (type, msg) =>
        {
            if(type == MessageType.ERROR)
            {
                UIController.Instance.Message.AddMessage(msg, 3f);
                return;
            }

            DoSlot(true);
        });
    }

    private float _timer = 0f;
    private Button _stopBtn;

    private void DoSlot(bool value)
    {
        _btns.AddToClassList("game");
        //UIController.Instance.StartCoroutine(SlotCoroutine(value));
    }

    private IEnumerator SlotCoroutine(bool value)
    {

        while (true)
        {
            _timer += Time.deltaTime;
            if (_timer > 5f)
            {
                _stopBtn.SetEnabled(true);
            }

            yield return null;
            break;
        }

        _stopBtn.SetEnabled(false);
    }
}
