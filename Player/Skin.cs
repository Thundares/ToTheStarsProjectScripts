using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator playAnim = null;

    [Header("ButtonsSkin")]
    [SerializeField] private Button aranhaBtn = null;

    [Header("Line Renderer")]
    int hash01 = 0;
    public void ChangeSkin(int index)
    {
        hash01 = Animator.StringToHash("aranha");
        if (index == 1)
        {
            playAnim.SetBool(hash01, true);
        }
        else 
        {
            playAnim.SetBool(hash01, false);
        }
    }

    public void CheckBtns() 
    {
        if (VariablesManager.bSpider) 
        {
            aranhaBtn.interactable = true;
        }
    }
}
