using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum Windows{
    Lunch = 1,
    Login = 2,
    Inven = 3,
    Slot = 4,
}
public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public List<ItemSO> ItemList;

    [SerializeField] private VisualTreeAsset _lunchUIAsset; //UI의 프리팹
    [SerializeField] private VisualTreeAsset _loginUIAsset; //UI의 프리팹
    [SerializeField] private VisualTreeAsset _invenUIAsset;
    [SerializeField] private VisualTreeAsset _invenItemUIAsset;
    [SerializeField] private VisualTreeAsset _slotUIAsset;

    private UIDocument _uiDocument;
    private VisualElement _contentParent;
    private MessageSystem _messageSystem;
    public MessageSystem Message => _messageSystem;
    
    private Dictionary<Windows, WindowUI> _windowDictionary = new Dictionary<Windows, WindowUI>();

    private Button _loginBtn;
    private UserInfoPanel _userInfoPanel;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple UI Manager is running");
        }
        Instance = this;

        _uiDocument = GetComponent<UIDocument>();
        _messageSystem = GetComponent<MessageSystem>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        Button lunchBtn = root.Q<Button>("LunchBtn");
        lunchBtn.RegisterCallback<ClickEvent>(OnOpenLunchHandle);
        
        _loginBtn = root.Q<Button>("LoginBtn");
        _loginBtn.RegisterCallback<ClickEvent>(OnOpenLoginHandle);
        _contentParent = root.Q<VisualElement>("Content");
        
        var popOverElem = root.Q<VisualElement>("UserPopOver");
        var userInfoElem = root.Q<VisualElement>("UserInfoPanel");
        _userInfoPanel = new UserInfoPanel(userInfoElem, popOverElem, e => SetLogout());

        Button slotBtn = root.Q<Button>("SlotBtn");
        slotBtn.RegisterCallback<ClickEvent>(OnOpenSlotHandle);

        Button invenBtn = root.Q<Button>("InventoryBtn");
        invenBtn.RegisterCallback<ClickEvent>(OnOpenInvenHandle);
        
        var messageContainer = root.Q<VisualElement>("MessageContainer");
        _messageSystem.SetContainer(messageContainer);
        
        
        #region 윈도우 추가하는 부분
        _windowDictionary.Clear();
        
        VisualElement lunchRoot = _lunchUIAsset.Instantiate().Q<VisualElement>("LunchContainer");
        _contentParent.Add(lunchRoot);
        LunchUI lunchUI = new LunchUI(lunchRoot);
        lunchUI.Close();
        _windowDictionary.Add(Windows.Lunch, lunchUI );

        VisualElement slotRoot = _slotUIAsset.Instantiate().Q<VisualElement>("SlotContainer");
        _contentParent.Add(slotRoot);
        MiniGameUI slotUI = new MiniGameUI(slotRoot);
        slotUI.Close();
        _windowDictionary.Add(Windows.Slot, slotUI);

        VisualElement loginRoot = _loginUIAsset.Instantiate().Q<VisualElement>("LoginWindow");
        _contentParent.Add(loginRoot);
        LoginUI loginUI = new LoginUI(loginRoot);
        loginUI.Close();
        _windowDictionary.Add(Windows.Login, loginUI );
        
        VisualElement invenRoot = _invenUIAsset.Instantiate().Q<VisualElement>("InventoryBody");
        _contentParent.Add(invenRoot);
        InventoryUI invenUI = new InventoryUI(invenRoot,_invenItemUIAsset);
        invenUI.Close();
        _windowDictionary.Add(Windows.Inven, invenUI );
        
        #endregion
    }

    private void OnOpenLoginHandle(ClickEvent evt)
    {
        foreach (var kvPair in _windowDictionary)
        {
            kvPair.Value.Close();
        }
        _windowDictionary[Windows.Login].Open();
    }

    private void OnOpenLunchHandle(ClickEvent evt)
    {
        foreach (var kvPair in _windowDictionary)
        {
            kvPair.Value.Close();
        }
        _windowDictionary[Windows.Lunch].Open();
    }

    private void OnOpenSlotHandle(ClickEvent evt)
    {
        foreach (var kvPair in _windowDictionary)
        {
            kvPair.Value.Close();
        }
        _windowDictionary[Windows.Slot].Open();
    }

    private void OnOpenInvenHandle(ClickEvent evt)
    {
        foreach (var kvPair in _windowDictionary)
        {
            kvPair.Value.Close();
        }
        _windowDictionary[Windows.Inven].Open();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            int idx = Random.Range(0, ItemList.Count);
            InventoryUI inven = _windowDictionary[Windows.Inven] as InventoryUI;
            inven.AddItem(ItemList[idx], 3);
        }
    }

    public void SetLogin(UserVO user)
    {
        _loginBtn.style.display = DisplayStyle.None;
        //로그인이 되었을 SetLogin을 실행시켜라
        //_userInfoPanel 을 보이게 만들고
        _userInfoPanel.Show(true);
        // UserInfoPanel에 있는 버튼중에서 InfoBtn에 text로 유저의 이름을 넣어줘라.
        _userInfoPanel.User = user;
    }

    public void SetLogout()
    {
        _loginBtn.style.display = DisplayStyle.Flex;
        _userInfoPanel.Show(false);
        GameManager.Instance.DestroyToken();
    }
}
