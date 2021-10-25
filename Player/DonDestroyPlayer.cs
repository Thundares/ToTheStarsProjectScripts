
using UnityEngine;

public class DonDestroyPlayer : MonoBehaviour
{
    [SerializeField] Animator playAnim = null;
    void Awake()
    {
        if (VariablesManager.bAranha) 
        {
            int aux = Animator.StringToHash("aranha");
            playAnim.SetBool(aux, true);
        }
    }

}
