using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BallPhysics : MonoBehaviour
{
    //declaring global variables
    private Rigidbody2D rigidb = null;
    private Vector2 lastVelocity = Vector2.zero;
    private float angleVar;
    private static int lives = 1;

    public static GameObject go;
    

    public static int Lives { get => lives; }

    void Start()
    {
        //intializing rigid body and making it unaffected by gravity
        go = this.gameObject;
        rigidb = gameObject.GetComponent<Rigidbody2D>();
        rigidb.velocity = Vector2.down * 10;
        rigidb.gravityScale = 0;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //updating last velocity before collisions happen
        lastVelocity = rigidb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Bounce(collision);
        
    }
    void Bounce(Collision2D coll)
    {
        if(Mathf.Abs(rigidb.velocity.x - lastVelocity.x) <=1f || Mathf.Abs(rigidb.velocity.y - lastVelocity.y) <= 1f)
            angleVar= 20; 
        var speed = lastVelocity.magnitude;
        //rotate the ball according to the angle given
        transform.Rotate(0,0, angleVar);
       
        //reflect the direction on collision so we get bounce velocity using normal velocity and the point of contact normal
        var direction = Vector2.Reflect(lastVelocity.normalized, coll.GetContact(0).normal);
        //applying the velocity to where the ball is facing in the real position in the game
        rigidb.velocity = transform.TransformDirection(direction) * Mathf.Max(speed, 7f);
        
        //rotating back so it doesn't keep increasing
        transform.Rotate(0, 0, -angleVar);
        angleVar = 0;
    }
    private void OnDestroy()
    {
        lives--;
    }
}
