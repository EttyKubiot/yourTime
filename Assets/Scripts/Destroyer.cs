using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallingObject"))
        {

            Destroy(other.gameObject);
            //Instantiate(caughtObjectPrefab, transform.position, Quaternion.identity);
            Debug.Log("fall");
        }
    }
}