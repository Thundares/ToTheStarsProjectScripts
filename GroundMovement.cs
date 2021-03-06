using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    // script that always let the ground under the player.

    [SerializeField] private GameObject Player = null;
    [SerializeField] private GameOverManager gmOver = null;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision: "+ collision.gameObject.tag.ToString());
        if (collision.gameObject.CompareTag("Player") && VariablesManager.iHitNumber > 0) 
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("fall");
            gmOver.fallGround = true;
            //Debug.Log("Fall ground: " + gmOver.fallGround);
        }
    }
}
