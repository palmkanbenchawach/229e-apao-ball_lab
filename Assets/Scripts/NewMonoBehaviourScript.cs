using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("mainGame"); // หรือชื่อ scene เกมจริง
    }

    public void ExitGame()
    {
        Debug.Log("EXIT CLICKED");

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // ?? หยุด Play Mode
#else
        Application.Quit(); // ?? ออกเกมจริง
#endif
    }

    public void LoadMenu()
    {
        Debug.Log("CLICK MENU");
        SceneManager.LoadScene("UI_Menu");
    }

}