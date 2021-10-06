using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] float fGameOverCondition = -16;

    UnityEvent eGameOver;

    Rigidbody2D rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (eGameOver == null) 
        {
            eGameOver = new UnityEvent();
        }
        eGameOver.AddListener(GameOver);
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rbPlayer.velocity.y < fGameOverCondition) 
        {
            eGameOver.Invoke();
        }
    }

    void GameOver() 
    {
        VariablesManager.bGameOver = true;
        Debug.Log("GameOver event");
    }
}
