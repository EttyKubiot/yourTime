using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Complliment : MonoBehaviour
{
	private GameManager gameManager;
	public Image complimentImage;

	public Sprite [] complimentSpriteGirl;
	public Sprite[] complimentSpriteBoy;
	private int index;
	private void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
		gameManager.OnCorrect += SetCompliment;
	}

	public void SetCompliment()
	{

		StartCoroutine(PlayCompliment());
	}

	private IEnumerator PlayCompliment()
	{
		yield return new WaitForSeconds(1.5f);
	
		complimentImage.gameObject.SetActive(true);

		complimentImage.SetNativeSize();
		yield return new WaitForSeconds(1f);
		complimentImage.gameObject.SetActive(false);


		if (index >= complimentSpriteGirl.Length -1 || index >= complimentSpriteBoy.Length -1)
		{
			index = 0;
		}
		else
        {
			index++;

		}
	
		
		
        if(gameManager.mode == 0)
        {
			complimentImage.sprite = complimentSpriteGirl[index];
		}
		else
        {
			complimentImage.sprite = complimentSpriteBoy[index];
		}

		

		
	}
}

