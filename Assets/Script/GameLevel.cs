using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "LevelReference")]
public class GameLevel : MonoBehaviour
{
    Level _currentLevel;

    [SerializeField, Scene] int _sceneIndex;


    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(_sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
   
      /*   public Level CurrentLevel
        {
           get => _currentLevel;
           Set => _currentLevl = value;
        }*/


}