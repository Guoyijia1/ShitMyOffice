using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFirstWinOrOverPanel : MonoBehaviour
{
    public Text m_Str;
    public Button m_ReStartBtn;
    public Button m_ReStartBtn1;
    // Start is called before the first frame update
    void Start()
    {
        m_ReStartBtn.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        });

        m_ReStartBtn1.onClick.AddListener(() => {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI(string _tile)
    {
        m_Str.text = _tile;
        gameObject.SetActive(true);
    }
}
