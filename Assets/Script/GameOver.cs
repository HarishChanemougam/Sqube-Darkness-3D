using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] float _stop;
    [SerializeField, Scene] int _sceneIndex;


    public void EndGame()
    {
        StartCoroutine(LoadAsynchronously(_sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        yield return new WaitForSeconds(_stop);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    }
}
