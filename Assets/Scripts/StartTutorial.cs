using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("BasicMovementAndAnim");
    }
}