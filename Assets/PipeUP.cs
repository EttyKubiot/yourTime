using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipeUP : MonoBehaviour
{
    [SerializeField] private Transform [] connection;
   
    [SerializeField] private Keyboard enterkeycode;
    [SerializeField] private Vector3 enterDirection = Vector3.down;
    [SerializeField] private Vector3 exitDirection = Vector3.zero;
    [SerializeField] private bool toggle;
    //[SerializeField] private PlayerController playerController;



    void OnTriggerStay2D(Collider2D other)
    {
        if (connection != null && other.gameObject.CompareTag("Player"))
        {
            //if (playerController.IsUp == true)
            //{

                StartCoroutine(Enter(other.transform));
            //}

        }
    }

    IEnumerator Enter(Transform player)
    {

        player.GetComponent<PlayerController>().enabled = false;
        Color color = Color.white;
        color.a = 0f;
        player.GetComponent<SpriteRenderer>().color = color;
        //player.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //player.GetComponent<Transform>().position = connection[0].position;
        //yield return new WaitForSeconds(1f);
        //player.GetComponent<Transform>().position = connection[0].position;
        yield return new WaitForSeconds(0.2f);
        color.a = 1f;
        player.GetComponent<SpriteRenderer>().color = color;
        //player.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
        player.GetComponent<Transform>().position = connection[1].position;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
