using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    /*
    public void OpenMenu(Canvas toOpen) 
    {
        toOpen.enabled = true;
    }

    public void CloseMenu(Canvas toClose) 
    {
        toClose.enabled = false;
    }
    */
    public void ToggleOpnAnimator() 
    {
        if (animator.GetBool("Open"))
        {
            animator.SetBool("Open", false);
            if (this.CompareTag("FirstMenu")) 
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
            }
        }
        else 
        {
            animator.SetBool("Open", true);
            if (this.CompareTag("FirstMenu")) 
            {
                Time.timeScale = 0;
                Time.fixedDeltaTime = 0;
            }
        }
        //Debug.Log(animator.GetBool("Open"));
;    }
}
