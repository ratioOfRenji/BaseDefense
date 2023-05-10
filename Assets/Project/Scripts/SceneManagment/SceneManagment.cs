using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace StarterAssets
{
    public class SceneManagment : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(LoadSceneAssync(1));
        }
        IEnumerator LoadSceneAssync(int buildIndex)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}