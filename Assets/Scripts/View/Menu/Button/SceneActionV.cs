using Model;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using ViewModel;

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