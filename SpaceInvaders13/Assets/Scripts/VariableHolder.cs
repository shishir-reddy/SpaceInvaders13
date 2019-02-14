using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VariableHolder : MonoBehaviour
{
    [System.NonSerialized] public int PlayerLives;
    [System.NonSerialized] public static VariableHolder instance;
    [System.NonSerialized] public int PlayerScore;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerLives = 3;
        instance = this;
        
    }
    private void Start()
    {
        PlayerShishir.instance.OnHitPlayer.AddListener(() => ChangeLives());
        EnemyScript.OnEnemyKilled.AddListener(ChangeScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScore(GameObject ThisEnemy)
    {
        PlayerScore = PlayerScore + ThisEnemy.GetComponent<EnemyScript>().PointValue;
        Debug.Log(PlayerScore);
        ScoreText.text = string.Format("Score: {0:0000}", PlayerScore);
    }

    void ChangeLives()
    {
        PlayerLives--;
        LivesText.text = string.Format("Lives: {0:0}", PlayerLives);
        if (PlayerLives <= 0)
        {
            SceneManager.LoadScene("RetryMenu");
        }
    }
}
