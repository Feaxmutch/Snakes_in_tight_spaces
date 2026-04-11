using Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActionV : ButtonActionV
{
    [SerializeField] private SceneAsset _sceneAsset;

    public override void Perform()
    {
        if (Level.IsActive())
        {
            Level.Stop();
        }

        SceneManager.LoadScene(_sceneAsset.name);
    }
}