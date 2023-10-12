using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public LayerMask jord;
    public LayerMask medspillerlag;
    public float raylength = 1;
    public KeyCode leaft;
    public KeyCode right;
    public KeyCode up;
    public float Speed = 1f;
    public float JumpPower = 0f;
    public float JumpMaxpower = 1f;
    public float Jumpminpower = 1f;
    public float Jumpbuildupspeed = 1f;
    private bool jump = false;
    public float JumpPowerX = 0.2f;
    public float JumpPowerY = 0.8f;
    private float diretion = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //jump input
        if (Input.GetKey(up)&& isgrounded() && JumpPower<JumpMaxpower)
        {
           
         JumpPower += Jumpbuildupspeed * Time.deltaTime;
            
            
        }
        if (Input.GetKeyUp(up)&& isgrounded())
        {
            jump = true;
        }
    }
    //check if grounded 
    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f,raylength,0), Vector2.right, (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, jord);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f, raylength, 0), Vector2.right, (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, medspillerlag);
        Debug.DrawRay(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f, raylength, 0), Vector2.right * (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, Color.red, 1);
        if (hit == true)
        {
            if (hit.collider.tag == "ground")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        else if(hit2==true)
        {
            if (hit2.collider.tag == "dog"|| hit2.collider.tag == "cat")
            {
                return true;
            }
            else {
                Debug.Log("okay");
            return false; }
            
        }
        else
        {
            return false;
        }

    }
    
    
        
    


    //reset jump 


    private void FixedUpdate()
    {

        //movment leaft right
        if (Input.GetKey(leaft)&& isgrounded())
        {
            rb.velocity = new Vector3(-Speed, rb.velocity.y, 0);
            diretion = -1;
        }

        if (Input.GetKey(right)&&isgrounded())
        {
            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
            diretion = 1;
        }

        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(JumpPower* JumpPowerX * diretion, JumpPower*JumpPowerY), ForceMode2D.Impulse);
            jump = false;
            JumpPower = Jumpminpower;
        }
    }
}
