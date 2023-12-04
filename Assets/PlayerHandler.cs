using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    //public UnityAction OnScoreBlue;
    //public UnityAction OnScorePink;
    //public UnityAction OnScoreGreen;
    //public UnityAction OnScoreYellow;
    //public UnityAction OnScoreBlueMinus;
    //public UnityAction OnScorePinkMinus;
    //public UnityAction OnScoreGreenMinus;
    //public UnityAction OnScoreYellowMinus;
    //public UnityAction OnTimerOff;

    [SerializeField] private GameObject[] sircal;

    //private CardGameManager cardGameManager;
    //private PlayerControler2 playerController;
    public GameObject[] spawnPoints;
    public static PlayerHandler instance1 = null;

    public List<PlayerInput> playerList = new List<PlayerInput>();
    //public List<InputDevice> playerDevice = new List<InputDevice>();

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    [SerializeField] InputAction joinAction;

    [SerializeField] InputAction leaveAction;

    //[SerializeField] private GameObject winManager;
    //[SerializeField] private Image winImage;
    //[SerializeField] private Image groupImg;
    //[SerializeField] private Sprite[] groupImges;
    //[SerializeField] private Text scoreWinText;
    //[SerializeField] private Text nameWinText;
    //public Text screanText;
    //[SerializeField] private Image ourLogoImage;
    //[SerializeField] private Button exit;

    Vector3 currentPos;

    private int index1;
    private int index2;


    private void Awake()
    {
        if (instance1 == null)
        {
            instance1 = this;
        }
        else if (instance1 != null)
        {
            Destroy(gameObject);
        }
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");

        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);
        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
        //cardGameManager = FindObjectOfType<CardGameManager>();

        //groupImg = null;

        //StartCoroutine(Winner());
    }




    private void Start()
    {

        //PlayerInputManager.instance.JoinPlayer(0, -1, null);
        //cardGameManager = FindObjectOfType<CardGameManager>();
        //playerController = FindObjectOfType<PlayerControler2>();
        //cardGameManager.GoBack += PlayerGoBack;


    }




    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerList.Add(playerInput);
        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
            //Debug.Log(Gamepad.current);
            //playerDevice.Add(Gamepad.current);
            //Debug.Log(playerDevice);

            if (playerList.Count == 4)
            {
                sircal[0].SetActive(true);
            }
        }


        //cardGameManager.OnPlayerJoin?.Invoke();
    }

    void OnPlayerLeft(PlayerInput playerInput)
    {

    }



    void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);

    }



    void LeaveAction(InputAction.CallbackContext context)
    {
        if (playerList.Count > 1)
        {
            foreach (var player in playerList)
            {
                foreach (var device in player.devices)
                {
                    if (device != null && context.control.device == device)
                    {
                        UnregisterPlayer(player);
                        return;
                    }
                }

            }
        }

    }

    void UnregisterPlayer(PlayerInput playerInput)
    {
        playerList.Remove(playerInput);
        if (PlayerLeftGame != null)
        {
            PlayerLeftGame(playerInput);
        }
        Destroy(playerInput.transform.parent.gameObject);

    }

    
}
