using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSceneTransition : MonoBehaviour
{
    public float timeLimit = 120.0f; // Time limit in seconds
    private float timer = 0.0f;
    private bool isTimerRunning = true;

    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;

            if (timer >= timeLimit)
            {
                isTimerRunning = false;
                MyGameManager.Instance.OnEndA?.Invoke();
                //LoadNextScene();
            }
        }
    }

    public void LoadNextScene2()
    {
        
        SceneManager.LoadScene(3);
    }

    public void LoadNextScene3()
    {

        SceneManager.LoadScene(4);
    }

    public void LoadNextScene1()
    {

        SceneManager.LoadScene(2);
    }
}

