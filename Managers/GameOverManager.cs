using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] float fGameOverCondition = -16;
    public bool fallGround;

    UnityEvent eGameOver;

    Rigidbody2D rbPlayer;

    void Start()
    {
        fallGround = false;
        if (eGameOver == null) 
        {
            eGameOver = new UnityEvent();
        }
        eGameOver.AddListener(GameOver);
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rbPlayer.velocity.y < fGameOverCondition || fallGround) 
        {
            eGameOver.Invoke();
        }
    }

    void GameOver() 
    {
        VariablesManager.bGameOver = true;
        VariablesManager.iTotalRounds++;
        PlayerPrefs.SetInt("totalBees", VariablesManager.iTotalBees);
        PlayerPrefs.SetInt("totalRounds", VariablesManager.iTotalRounds);
        PlayerPrefs.SetFloat("record", (float)VariablesManager.dRecord);
        Debug.Log("GameOver event");
    }
}
