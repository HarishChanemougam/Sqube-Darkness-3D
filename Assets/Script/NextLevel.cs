using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] Collider _collider;
    [SerializeField, Scene] int _sceneIndex;
    [SerializeField] Rigidbody _rb;

    private void OnTriggerEnter(Collider collision)
    {
        // Verifier si collision est bien le joueur
        if (collision.attachedRigidbody == null) return;
        if (collision.attachedRigidbody.TryGetComponent<PlayerTag>(out var pt))
        {
            LoadLevel();
            Debug.Log("NextLevel");
        }
    }

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

}
