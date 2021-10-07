using UnityEngine;
using UnityEngine.EventSystems;

public class ClickImpulse : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public float ForceValue = 0;
    [SerializeField] public bool TRUEIMPULSE = false;
    [SerializeField] private float fLifeTime = 0;
    [SerializeField] private bool bFirst = false;

    public void OnPointerDown(PointerEventData eventData)
{
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
            DifficultController dc = new DifficultController();
            playerRB.AddForce(direction * ForceValue, ForceMode2D.Impulse);
            VariablesManager.bEnableSpawn = true;
            VariablesManager.iHitNumber++;
            
            //increase gravity
            if(VariablesManager.iHitNumber % 5 == 0)
                dc.IncrementDif();
        }
        else 
        {
            playerRB.AddForce(direction * ForceValue * -1, ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
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
