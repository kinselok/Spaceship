using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public ProgressBar cooldownBar;
    public Text Score;
    public Text Distance;
    public GameObject EndOfGameWindow;
    public Text ResultScore;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);

        cooldownBar.BarValue = 0;


    }
    public void StartCooldown(float cooldown) // I don't really like this method, but i don't how to improve it
    {
        float IncreaseRate = cooldown / 100;
        cooldownBar.BarValue = 0;
        for (int i = 0; i < 100; i++)
        {
            Invoke("InceaseCooldownBar", IncreaseRate * i);
        }
    }
    void InceaseCooldownBar()
    {
        cooldownBar.BarValue += 1;
    }
    public void EndGame()
    {
        ResultScore.text = Score.text;
        EndOfGameWindow.SetActive(true);
}
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
