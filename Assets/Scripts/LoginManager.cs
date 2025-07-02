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
            messageText.text = "Bu kullanýcý zaten var!";
            return;
        }

        PlayerPrefs.SetString(username + "_password", password);
        PlayerPrefs.SetInt(username + "_savedLevel", 1);
        PlayerPrefs.SetString("currentUser", username);
        PlayerPrefs.Save();

        messageText.text = "Kayýt baþarýlý. Yönlendiriliyor...";
        SceneManager.LoadScene("StartScene");
    }

    public void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (!PlayerPrefs.HasKey(username + "_password"))
        {
            messageText.text = "Kullanýcý bulunamadý!";
            return;
        }

        if (PlayerPrefs.GetString(username + "_password") != password)
        {
            messageText.text = "Þifre hatalý!";
            return;
        }

        PlayerPrefs.SetString("currentUser", username);
        PlayerPrefs.Save();

        messageText.text = "Giriþ baþarýlý!";
        SceneManager.LoadScene("StartScene");
    }
}
