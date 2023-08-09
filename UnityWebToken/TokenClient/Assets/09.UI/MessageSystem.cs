using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _messageTemplate;
    private VisualElement _container;
    private List<MessageTemplate> _messageList = new List<MessageTemplate>();

    public void SetContainer(VisualElement container)
    {
        _container = container;
    }

    private void Update()
    {
        for(int i = 0; i < _messageList.Count; i++)
        {
            _messageList[i].UpdateMessage();
            if(_messageList[i].IsComplete)
            {
                _messageList[i].Root.RemoveFromHierarchy();
                _messageList.RemoveAt(i);
                --i;
            }
        }
    }

    public void AddMessage(string text, float timer)
    {
        VisualElement msgElement = _messageTemplate.Instantiate().Q("MessageBox");
        _container.Add(msgElement);
        MessageTemplate msg = new MessageTemplate(msgElement, timer);
        msg.Text = text;
        _messageList.Add(msg);
    }
}
