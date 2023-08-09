using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Windows
{ 
    Lunch,
    Login,
}

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] private VisualTreeAsset _lunchUIAsset;
    [SerializeField] private VisualTreeAsset _loginUIAsset;

    private UIDocument _uiDocument;

    private VisualElement _contentParent;

    private MessageSystem _messageSystem;
    public MessageSystem MessageSystem => _messageSystem;

    private Dictionary<Windows, WindowUI> _windowDictionary = new Dictionary<Windows, WindowUI>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple UIManager is running");
        }
        Instance = this;

        _uiDocument = GetComponent<UIDocument>();
        _messageSystem = GetComponent<MessageSystem>();
    }

    private void OnEnable()
    {
        VisualElement root = _uiDocument.rootVisualElement;

        Button lunchBtn = root.Q<Button>("LunchBtn");
        lunchBtn.RegisterCallback<ClickEvent>(OnOpenLunchHandle);

        Button loginBtn = root.Q<Button>("LoginBtn");
        loginBtn.RegisterCallback<ClickEvent>(OnOpenLoginHandle);

        _contentParent = root.Q("Content");

        VisualElement messageContainer = root.Q("MessageContainer");
        _messageSystem.SetContainer(messageContainer);

        #region Window

        _windowDictionary.Clear();

        // Create Lunch UI
        VisualElement lunchRoot = _lunchUIAsset.Instantiate().Q("LunchContainer");
        _contentParent.Add(lunchRoot);
        _windowDictionary.Add(Windows.Lunch, new LunchUI(lunchRoot));

        // Create Login UI
        VisualElement loginRoot = _loginUIAsset.Instantiate().Q("LoginContainer");
        _contentParent.Add(loginRoot);
        _windowDictionary.Add(Windows.Login, new LoginUI(loginRoot));

        foreach (WindowUI window in _windowDictionary.Values)
        {
            window.Close();
        }

        #endregion
    }

    private void OnOpenLunchHandle(ClickEvent evt)
    {
        foreach(WindowUI window in  _windowDictionary.Values)
        {
            window.Close();
        }
        _windowDictionary[Windows.Lunch].Open();
    }
    private void OnOpenLoginHandle(ClickEvent evt)
    {
        foreach (WindowUI window in _windowDictionary.Values)
        {
            window.Close();
        }
        _windowDictionary[Windows.Login].Open();
    }
}
