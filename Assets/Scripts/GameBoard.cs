using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameBoard : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button[] NikudImageA;
    [SerializeField] private Button[] NikudImageE;
    [SerializeField] private Button[] NikudImageO;
    [SerializeField] private Button[] NikudImageU;
    [SerializeField] private Button[] NikudImageI;
    [SerializeField] private Button[] NikudImageA2;
    [SerializeField] private List<Button> BoardImage = new List<Button>();
    [SerializeField] private List<Button> buttonImage = new List<Button>();
    [SerializeField] private GameObject MyGrid;
    private float indexState = 1f;
    private string AvatrLetter;
    private Transform buttonPosition;
   
  

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnPlayClipName += GetName;
        gameManager.OnWin += EndGame;
        gameManager.OnLose += EndGame;
        LoadBoard();
    }

    private void LoadBoard()
    {
        BoardImage.Clear();
        int indexA = Random.Range(0, NikudImageA.Length);
        int indexE = Random.Range(0, NikudImageE.Length);
        int indexO = Random.Range(0, NikudImageO.Length);
        int indexU = Random.Range(0, NikudImageU.Length);
        int indexI = Random.Range(0, NikudImageI.Length);
        int indexB = Random.Range(0, NikudImageA2.Length);

        BoardImage.Add(NikudImageA[indexA]);
        BoardImage.Add(NikudImageE[indexE]);
        BoardImage.Add(NikudImageO[indexO]);
        BoardImage.Add(NikudImageU[indexU]);
        BoardImage.Add(NikudImageI[indexI]);
        BoardImage.Add(NikudImageA2[indexB]);

       
        for (int i = 0; i < BoardImage.Count; i++)
        {
            
            BoardImage[i].gameObject.SetActive(true);
           
            BoardImage[i].interactable = true;
         
        }

        for (int i = 0; i < BoardImage.Count; i++)
        {

            BoardImage[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    

    public void OnClick(ImageData imageData)
    {
        if (imageData.Sound == char.Parse(AvatrLetter))
        {
            gameManager.OnCorrect?.Invoke();
            gameManager.OnColor?.Invoke(imageData.Particles.name);
            StartCoroutine(Particals(imageData));
        }

        else
        {
            gameManager.OnMistake?.Invoke();
            indexState = indexState - 0.25f;
            gameManager.OnNewState?.Invoke(indexState);
           
        }

        gameManager.PlayAudioPressed?.Invoke(imageData.AudioClip);
       
       
        if (!gameManager.gameEnd)
        {
            StartCoroutine(LoadBoardGame());
        }
    }

    private IEnumerator LoadBoardGame()
    {
        for (int i = 0; i < BoardImage.Count; i++)
        {
            BoardImage[i].interactable = false;
        }
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < BoardImage.Count; i++)
        {
            BoardImage[i].gameObject.SetActive(false);
        }
        gameManager.OnPlayClip?.Invoke();
        LoadBoard();
    }

    private IEnumerator Particals(ImageData imageData)
    {
        yield return new WaitForSeconds(0.2f);
        ParticleSystem particleSystem = Instantiate(imageData.Particles, buttonPosition);
        particleSystem.Play();
        
    }

    public void OnClickButton(GameObject gameObject)
    {
        buttonPosition = gameObject.transform;

    }

    public void OnClickSound(ImageData imageData)
    {

        gameManager.PlayAudioPressed?.Invoke(imageData.AudioClip);
    }

    private void GetName(string letter)
    {
        AvatrLetter = letter;
    }

    private void EndGame()
    {
        gameManager.gameEnd = true;
    }

}
