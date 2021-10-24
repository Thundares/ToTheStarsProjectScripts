using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    int openHash = Animator.StringToHash("Open");

    public void ToggleOpnAnimator()
    {
        if (animator.GetBool(openHash))
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
; }

    // function used to wait for animation
    public void LateDisableGameObject(float time)
    {
        StartCoroutine(enumerator(time));
    }

    private IEnumerator enumerator(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        this.gameObject.SetActive(false);
    }

    // functionalities to open and close
    private void OpenMenu()
    {
        animator.SetBool(openHash, false);
        if (this.CompareTag("FirstMenu"))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    private void CloseMenu() 
    {
        animator.SetBool(openHash, true);
        if (this.CompareTag("FirstMenu"))
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }
    }
}
