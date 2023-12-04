using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayer : MonoBehaviour
{
    public CapsuleCollider2D[] player;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 6);
        Physics2D.IgnoreCollision(player[0], player[1]);
        Physics2D.IgnoreCollision(player[1].GetComponent<CapsuleCollider2D>(), player[0].GetComponent<CapsuleCollider2D>(), false);
        Physics2D.IgnoreCollision(player[0].GetComponent<CapsuleCollider2D>(), player[1].GetComponent<CapsuleCollider2D>(), false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
