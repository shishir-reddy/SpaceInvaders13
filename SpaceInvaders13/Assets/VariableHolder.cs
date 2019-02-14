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
    public TextMeshProUGUI LivesText;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerLives = 3;
        instance = this;
    }
    private void Start()
    {
        Debug.Log(PlayerShishir.instance);
        PlayerShishir.instance.OnHitPlayer.AddListener(() => ChangeLives());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLives()
    {
        PlayerLives--;
        LivesText.text = string.Format("Score: {0:0}", PlayerLives);
        if (PlayerLives <= 0)
        {
            SceneManager.LoadScene(RetryMenu);
        }
    }
}
