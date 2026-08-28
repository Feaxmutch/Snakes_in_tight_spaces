using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
}