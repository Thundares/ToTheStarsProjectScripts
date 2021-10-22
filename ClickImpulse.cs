using UnityEngine;
using UnityEngine.EventSystems;

public class ClickImpulse : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] public float ForceValue = 0;
    [SerializeField] private float fLifeTime = 3;
    [SerializeField] public bool TRUEIMPULSE = false;
    [Header("Only the first")]
    [SerializeField] private bool bFirst = false;
    [Header("Animation")]
    [SerializeField] private Animator playerAnim = null;
    private Animator impulseAnim = null;

    private void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        impulseAnim = this.gameObject.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
{
        GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundsManager>().PlayEffect(0);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        // if the player is above this object.
        if (Player.transform.position.y >= this.transform.position.y) 
        {
            //do nothing
            Destroy(this.gameObject);
            return;
        }

        //else
        //direction of the Force
        Vector2 direction = new Vector2(
            this.transform.position.x - Player.transform.position.x,
            this.transform.position.y - Player.transform.position.y);

        //apply force
        Rigidbody2D playerRB = Player.GetComponent<Rigidbody2D>();
        if (TRUEIMPULSE)
        {
            //player animation
            playerAnim.SetTrigger("click");
            impulseAnim.SetTrigger("surprise");

            DifficultController dc = new DifficultController();
            playerRB.AddForce(direction * ForceValue, ForceMode2D.Impulse);
            VariablesManager.bEnableSpawn = true;
            VariablesManager.iHitNumber++;
            VariablesManager.iTotalBees++;
            
            //increase gravity
            if(VariablesManager.iHitNumber % 5 == 0)
                dc.IncrementDif();

            //set global target
            VariablesManager.eTarget = Target.right;
        }
        else 
        {
            //player animation
            playerAnim.SetTrigger("wrongClick");
            impulseAnim.SetTrigger("laugh");

            playerRB.AddForce(direction * ForceValue * -1, ForceMode2D.Impulse);

            //set global target
            VariablesManager.eTarget = Target.wrong;

            //ser global variable
            VariablesManager.iTotalWasp++;

            //click on false causes stop time:
            Player.GetComponent<TimeController>().StopTime();
        }

        Destroy(this.gameObject, 0.3f);
    }

    // despawn object
    private void FixedUpdate()
    {
        if (fLifeTime < 0)
        {
            if(!bFirst)
                Destroy(this.gameObject);
        }
        else 
        {
            fLifeTime -= 1 * Time.deltaTime;
        }
    }
}
