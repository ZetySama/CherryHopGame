using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;

    public void Register()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (PlayerPrefs.HasKey(username + "_password"))
        {
            messageText.text = "Bu kullan�c� zaten var!";
            return;
        }

        PlayerPrefs.SetString(username + "_password", password);
        PlayerPrefs.SetInt(username + "_savedLevel", 1);
        PlayerPrefs.SetString("currentUser", username);
        PlayerPrefs.Save();

        messageText.text = "Kay�t ba�ar�l�. Y�nlendiriliyor...";
        SceneManager.LoadScene("StartScene");
    }

    public void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (!PlayerPrefs.HasKey(username + "_password"))
        {
            messageText.text = "Kullan�c� bulunamad�!";
            return;
        }

        if (PlayerPrefs.GetString(username + "_password") != password)
        {
            messageText.text = "�ifre hatal�!";
            return;
        }

        PlayerPrefs.SetString("currentUser", username);
        PlayerPrefs.Save();

        messageText.text = "Giri� ba�ar�l�!";
        SceneManager.LoadScene("StartScene");
    }
}
