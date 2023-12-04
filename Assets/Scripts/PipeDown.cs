using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PipeDown : MonoBehaviour
{
    //[SerializeField] private PlayerController playerController;
    [SerializeField] private Transform connection;
    [SerializeField] private Transform connection1;
    [SerializeField] private Keyboard enterkeycode;
    [SerializeField] private Vector3 enterDirection = Vector3.down;
    [SerializeField] private Vector3 exitDirection = Vector3.zero;
    [SerializeField] private bool toggle;



    private void Start()
    {
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (connection != null && other.gameObject.CompareTag("Player"))
        {
           
            //if (playerController.IsDown == true )
            //{
              
                StartCoroutine(Enter(other.transform));
            //}

        }
    }
    IEnumerator Enter(Transform player)
    {

        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        Color color = Color.white;
        color.a = 0f;
        player.GetComponent<SpriteRenderer>().color = color;
        player.GetComponent<Transform>().position = connection1.position;
        yield return new WaitForSeconds(1f);
        color.a = 1f;
        player.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Transform>().position = connection.position;
        player.GetComponent<PlayerController>().enabled = true;
    }

    //IEnumerator Enter(Transform player)
    //{

    //    player.GetComponent<PlayerController>().enabled = false;
    //    Vector3 enteredPosition = transform.position + enterDirection;
    //    Debug.Log(enteredPosition);
    //    Vector3 enterScale = new Vector3(0.1f, 0.1f, 0.1f);

    //    Debug.Log("enterScale" + enterScale);
    //    yield return Move(player, enteredPosition, enterScale);
    //    //yield return new WaitForSeconds(1f);

    //        //if (exitDirection != Vector3.zero)
    //        //{
    //        //    Debug.Log("aaaaaaaaaaaaaaaaaaaa");
    //        //    player.position = connection.position - exitDirection;
    //        //    yield return Move(player, connection.position + exitDirection, enterScale);
    //        //}

    //    //else
    //    //{
    //        Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbb");
    //        player.position = connection.position;
    //        player.localScale = new Vector3(0.3f, 0.3f, 0.3f);

    //    //}

    //    player.GetComponent<PlayerController>().enabled = true;

    //}

    //IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    //{
    //    float elapsed = 0.1f;
    //    float duration = 1.1f;

    //    Vector3 startPosition = player.position;
    //    Vector3 startScale = player.localScale;
    //    //Debug.Log("startPosition" + startPosition);
    //    while (elapsed < duration)
    //    {
    //        float t = elapsed / duration;
    //        //Debug.Log("t" + t);
    //        player.position = Vector3.Lerp(startPosition, endPosition, t);
    //        player.localScale = Vector3.Lerp(startScale, endScale, t);
    //        elapsed += Time.deltaTime;
    //        yield return null;

    //    }
    //    player.position = endPosition;
    //    player.localScale = endScale;
       
    //}
}
