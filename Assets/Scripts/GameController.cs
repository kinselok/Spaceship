using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    const float SpeedBooster = 0.1f;
    const float SpeedIncreaseRate = 20;
    public static float Speed = 0.2f;
    float Distance = 0;

    public GameObject asteroid;
    const float SpawnRate = 3;

    private static float score = 0;
    public static float Score
    {
        get
        { return score; }
        set
        {
            score = value;
            UIController.instance.Score.text = value.ToString();
        }
    }
    
    const float YOutsideOfScreen = 37;
    const float LeftBorder = -10;
    const float RightBorder = 10;
    

   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateAsteroid", 0, SpawnRate);
        InvokeRepeating("IncreaseSpeed", SpeedIncreaseRate, SpeedIncreaseRate);
        InvokeRepeating("CalculateDistance", 0, 1);
        Time.timeScale = 1;
    }
    
    void CalculateDistance()
    {
        Distance += Speed;
        UIController.instance.Distance.text = Distance.ToString();
    }
    void CreateAsteroid()
    {
        Vector3 pos = new Vector3(Random.Range(LeftBorder, RightBorder), YOutsideOfScreen, 0);
        Instantiate(asteroid, pos, Quaternion.identity);
    }


    void IncreaseSpeed()
    {
        Speed += SpeedBooster;
    }
}
