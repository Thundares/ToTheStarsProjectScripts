using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] float pauseTime = 0.5f;
    [SerializeField] float recoverSpeed = 1;
    [SerializeField] float slowSpeed = 0.2f;
    private bool paused = false;

    private void Start()
    {
        paused = false;
    }

    private void Update()
    {
        if (paused) 
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * recoverSpeed;
                Time.fixedDeltaTime += Time.deltaTime * recoverSpeed * 0.02f;
            }
            else 
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
                paused = false;
            }
        }
    }

    public void StopTime()
    {
        StopCoroutine(RestartTime());
        StartCoroutine(RestartTime());
    }

    IEnumerator RestartTime() 
    {
        Time.fixedDeltaTime = 0.0f;
        Time.timeScale = 0.0f;
        //Debug.Log("Time scale before = " + Time.timeScale);
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.fixedDeltaTime = slowSpeed * 0.02f;
        Time.timeScale = slowSpeed;
        //Debug.Log("Time scale after = " + Time.timeScale);
        paused = true;
    }

}
