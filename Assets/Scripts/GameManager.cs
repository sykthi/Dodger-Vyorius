using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int player1Hp = 5;
    int player2Hp = 5;

    [SerializeField] private GameObject p1UI;
    [SerializeField] private GameObject p2UI;

    [SerializeField] private TMP_Text p1HP;
    [SerializeField] private TMP_Text p2HP;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        p1HP.text = "HP: " + player1Hp;
        p2HP.text = "HP: " + player2Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHp(bool isMe)
    {
        if (isMe)
        {
            player1Hp = player1Hp - 1;
            p1HP.text = "HP: " + player1Hp;
            if (player1Hp == 0)
            {
                WinCondition(false);
            }
        }
        else
        {
            player2Hp = player2Hp - 1;
            p2HP.text = "HP: " + player2Hp;
            if (player2Hp == 0)
            {
                WinCondition(true);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            //Debug.Log("Checking");
            CarController cc = other.gameObject.GetComponent<CarController>();
            if (cc.CheckPointCount == 2)
            {
                //Debug.Log("RED WIN");
                WinCondition(true);
            }
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            //Debug.Log("Checking");
            CarController cc = other.gameObject.GetComponent<CarController>();
            if (cc.CheckPointCount == 2)
            {
                //Debug.Log("BLUE WIN");
                WinCondition(false);
            }
        }
    }

    public void WinCondition(bool isPlayer)
    {
        if (isPlayer)
        {
            p1UI.SetActive(true);
            p2UI.SetActive(true);

            p1UI.GetComponentInChildren<TMP_Text>().text = "VICTORY";
            p2UI.GetComponentInChildren<TMP_Text>().text = "DEFEAT";
        }
        else
        {
            p1UI.SetActive(true);
            p2UI.SetActive(true);

            p2UI.GetComponentInChildren<TMP_Text>().text = "VICTORY";
            p1UI.GetComponentInChildren<TMP_Text>().text = "DEFEAT";
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}