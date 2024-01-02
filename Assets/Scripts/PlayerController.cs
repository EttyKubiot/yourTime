using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingSpace))]

public class PlayerController : MonoBehaviour
{
    public float animationDuration = 1f;
    private float targetOffset = 8f;
    public float walkSpeed;
    public float mobileSpeed;
    public float computerSpeed;
    public float runSpeed;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    TouchingSpace touchingSpace;
    public ParticleSystem collisionParticles;
    public float jumpForce = 10f;
    public float swipeThreshold = 100f;
    public int id;

    //public GameObject check;
    private Vector2 swipeStartPosition;

    public int score = 0;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // Mobile platform, set speed to mobile speed
            walkSpeed = mobileSpeed;
        }
        else
        {
            // Computer platform, set speed to computer speed
            walkSpeed = computerSpeed;
        }

        EnhancedTouchSupport.Enable();
    }
    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving && !touchingSpace.IsOnWall)
            {
                if (IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                /// idle speed is 0
                return 0;
            }
           
        }

       
    }

[SerializeField]
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }

        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }

        private set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    
    public bool IsDown;
    public bool IsUp;
   

    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }

        private set
        {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);  

            }
            _isFacingRight = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingSpace = GetComponent<TouchingSpace>();

        
    }

    private void Update()
    {
        // Check for touch input
        // Check for touch input
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                swipeStartPosition = touch.position;
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                Vector2 swipeEndPosition = touch.position;
                Vector2 swipeDelta = swipeEndPosition - swipeStartPosition;

                // Check if the swipe is in an upward direction and exceeds the swipe threshold
                if (swipeDelta.y > swipeThreshold)
                {
                    Jump();
                }
               
            }
        }
        
         }

   

   
   

    private void Jump()
    {
        animator.SetTrigger("jump");

    
        // Apply vertical force to the Rigidbody
        rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(MyGameManager.Instance.canMove)
        {
            _isMoving = true;
            moveInput = context.ReadValue<Vector2>();
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
       
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
        
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if(context.canceled)
        {
            IsRunning = false;
        }
       
    }

    

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started )
        {
            IsDown = true;
        }
        else if (context.canceled)
        {
            IsDown = false;
        }
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started )
        {
            Debug.Log("onup");
            IsUp = true;
        }
        else if (context.canceled)
        {
            IsUp = false;
        }
    }

  


    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.started && touchingSpace.IsGrounded )
        {
           
                animator.SetTrigger("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
            
        }
    }

   
    public void OnTriggerEnter2D(Collider2D other)
    {
        //MyGameManager.Instance.canMove = false;
        //_isMoving = false;
        animator.SetBool("isMoving", false);
        if (other.CompareTag("Clock1") || other.CompareTag("Clock2") || other.CompareTag("Clock3") || other.CompareTag("Clock4"))
        {
            if (collisionParticles != null)
            {
              ParticleSystem particles = Instantiate(collisionParticles, other.transform.position, Quaternion.identity);
              Destroy(particles.gameObject, 2.0f);
            }
            Destroy(other.gameObject);

            Debug.Log("catch");

            MyGameManager.Instance.OnScorePlayer1?.Invoke(id, other.tag);
            Debug.Log(gameObject.layer);

        }
        if(other.CompareTag("Flag"))
        {
            MyGameManager.Instance.OnFlag?.Invoke(id);
            Debug.Log(gameObject.layer);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Bad"))
        {
           gameObject.transform.position = new Vector3(-52, -2, 0);
        }



    }

    
    //private IEnumerator DestroyPickUp(GameObject pick)
    //{
    //    yield return new WaitForSeconds(0.1f);

    //    if (pick == null)
    //    {
    //        yield break; // Exit the coroutine if the pick object is already destroyed
    //    }

    //    if (pick.gameObject.CompareTag("P1"))
    //    {
    //        SpriteRenderer text = Instantiate(MyGameManager.Instance.textCollect, pick.transform.position, pick.transform.rotation);
    //        if (text != null)
    //        {
    //            Vector3 targetPosition = text.transform.position + new Vector3(0f, targetOffset, 0f);

    //            text.transform.DOMove(targetPosition, animationDuration)
    //                .SetEase(Ease.OutQuad)
    //                .OnComplete(() =>
    //                {
    //                    // Animation complete, do any necessary cleanup or additional actions here
    //                    Destroy(text.gameObject);
    //                });
    //        }

    //        yield return new WaitForSeconds(0.1f);

    //        ParticleSystem particleSystem = Instantiate(MyGameManager.Instance.particleSystem, pick.transform.position, pick.transform.rotation);
    //        if (particleSystem != null)
    //        {
    //            particleSystem.Play();
    //            Destroy(particleSystem, 3);
    //        }
    //    }
    //    else if (pick.gameObject.CompareTag("P3"))
    //    {
    //        SpriteRenderer text = Instantiate(MyGameManager.Instance.textCollect1, pick.transform.position, pick.transform.rotation);
    //        if (text != null)
    //        {
    //            Vector3 targetPosition = text.transform.position + new Vector3(0f, targetOffset, 0f);

    //            text.transform.DOMove(targetPosition, animationDuration)
    //                .SetEase(Ease.OutQuad)
    //                .OnComplete(() =>
    //                {
    //                    // Animation complete, do any necessary cleanup or additional actions here
    //                    Destroy(text.gameObject);
    //                });
    //        }

    //        //yield return new WaitForSeconds(0.1f);

    //        //ParticleSystem particleSystem1 = Instantiate(MyGameManager.Instance.particleSystem1, pick.transform.position, pick.transform.rotation);
    //        //if (particleSystem1 != null)
    //        //{
    //        //    particleSystem1.Play();
    //        //    Destroy(particleSystem1);
    //        //}





    //    }

    //    yield return new WaitForSeconds(0.1f);

    //    if (pick != null)
    //    {
    //        Destroy(pick);
    //    }
    //}



}


    

