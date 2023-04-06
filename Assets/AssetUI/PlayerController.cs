using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    
    
    public float speedPlayer;
    [SerializeField] private float laneSpeed;
    public int maxLife = 3;
    public int currentLife;
    private float minSpeed = 5f; //5
    private float maxSpeed = 8f; // 8
    



    private Rigidbody rb;
    private float currentlane = 1f;
    private float jumpStar;
    public float jumpLength;
    public float jumpheight;
    
    public float sliderLenght;
    private float sliderStar;
    private static int blinkvalue;
    public float invincibleTime;
  


    private Vector3 verticalPostion;
    private Vector3 targetPostion;
    private bool jumping = false;
    private bool slider = false;
   private bool invincible = false;
    private BoxCollider _boxCollider;
   private UiManager uiManager;
    
    
  



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentLife = maxLife;
        speedPlayer = minSpeed;
        blinkvalue = Shader.PropertyToID("_BlinkingValue");
        uiManager = FindObjectOfType<UiManager>();

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changelane(-1.1f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changelane(1.1f);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            Debug.Log("dsssssssssssssssssssssssssssss");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slider();
        }

        
        if (jumping)
        {
            float ratio = (transform.position.z - jumpStar) / jumpLength;
            
            if (ratio >= 1f)
            {
                jumping = false;
                animator.SetBool("Jumping", false);
                
            }
            else
            {
               verticalPostion.y = Mathf.Sin(ratio * Mathf.PI) * jumpheight;
            }
        }
        else
        {
            verticalPostion.y = Mathf.MoveTowards(verticalPostion.y, 0, 5 * Time.deltaTime);
        }


        if (slider)
        {
            float ratio = (transform.position.z - sliderStar) / sliderLenght;
            if (ratio >= 1f)
            {
                slider = false;
                animator.SetBool("Slider", false);
                
            }
        }



        targetPostion = new Vector3(verticalPostion.x,verticalPostion.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPostion, laneSpeed);
    }



    private void Slider()
    {

        if (!jumping && !slider)
        {
            sliderStar = transform.position.z;
            animator.SetFloat("JumpSpeed", speedPlayer/ speedPlayer);
            animator.SetBool("Slider",true);
           // Vector3 newSize = _boxCollider.size;

           slider = true;

        }
    }

    private void Jump()
    {
        if (!jumping)
        {
            jumpStar = transform.position.z;
            animator.SetFloat("JumpSpeed", speedPlayer/jumpLength);
            animator.SetBool("Jumping", true);
            jumping = true;
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speedPlayer;
    }


    private void changelane(float direction)
    {
        float targetLane = currentlane + direction;
        if (targetLane < -1 || targetLane > 3)
        {
            return;
        }

        currentlane = targetLane;
        verticalPostion = new Vector3(currentlane - 1, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            FindObjectOfType<UiManager>()._Score += 1;  //////////
           Destroy(other.gameObject);
            

        }
        
        if (invincible)
        {
            return;
        }
        if (other.CompareTag("obs"))
        {
           // FindObjectOfType<UiManager>()._Score += 1;
            currentLife -= 1;
            FindObjectOfType<UiManager>().UpdateLives(currentLife);
            animator.SetTrigger("Hit");
            speedPlayer = 0;
            

            if (currentLife <= 0)
            {
              animator.SetBool("Death", true);
              speedPlayer = 0;
              
              ActionOver.isGameOver = true;
             
              
            }
            else
            {
                StartCoroutine(Blinking(invincibleTime));
            }
           
        }
    }

    IEnumerator Blinking(float time)
    {
        invincible = true;
        float timer = 0;
        float currentBlinking = 1f;
        float lastBlink = 0;
        float blinkPeriod = 0.1f;
        yield return new WaitForSeconds(1f);
        speedPlayer = minSpeed;

      
        while (time > timer && invincible)
        {
           
          Shader.SetGlobalFloat(blinkvalue, currentBlinking);
            yield return null;
            timer += Time.deltaTime;
            lastBlink += Time.deltaTime;
            if (blinkPeriod < lastBlink)
            {
                lastBlink = 0;
                currentBlinking = 1f - currentBlinking;
               

            }
        }
       
        Shader.SetGlobalFloat(blinkvalue, 0);
        invincible = false;


    }
}
