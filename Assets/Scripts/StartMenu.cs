using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("savedLevel", 2); // Level 1 sahnesinin Build Index'i = 2
        PlayerPrefs.Save();
        SceneManager.LoadScene(2); // Level 1 sahnesine geç
    }

    public void ContinueGame()
    {
        int savedLevel = PlayerPrefs.GetInt("savedLevel", 2); // kayýt yoksa Level 1'den baþlat
        SceneManager.LoadScene(savedLevel);
    }
}
