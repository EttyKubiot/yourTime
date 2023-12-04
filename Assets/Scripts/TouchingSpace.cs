using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingSpace : MonoBehaviour
{
    public ContactFilter2D contactFilter;
    public float groundDistance = 0.05f;
    public float CeilingCheckDistance = 0.2f;
     public float wallCheckDistance = 0.05f;
    CapsuleCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] CeilingHits = new RaycastHit2D[5];
    Animator animator;
    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded
    {  
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            animator.SetBool("isGrounded", value);
        }
            
    }

    [SerializeField]
    private bool _isOnWall;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            animator.SetBool("isOnWall", value);
        }

    }

    [SerializeField]
    private bool _isOnCeiling;
    private Vector2 wallChackDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool("isOnCeiling", value);
        }

    }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallChackDirection, contactFilter, wallHits, wallCheckDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, contactFilter, CeilingHits, CeilingCheckDistance) > 0;
    }
}
