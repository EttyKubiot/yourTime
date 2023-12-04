using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class LoadBackGround : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite(spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
