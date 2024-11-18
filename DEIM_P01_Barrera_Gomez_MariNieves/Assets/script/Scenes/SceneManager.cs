using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using SceneManagementUnity = UnityEngine.SceneManagement.SceneManager;

namespace GestionEscenas
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager instance;

        [SerializeField] private CanvasGroup fade;

        [SerializeField] private float fadeDuration;

        private bool isLoadingScene;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

        }

        public static void LoadScene(string sceneName)
         {
            instance.StartCoroutine(instance.LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {

            isLoadingScene = true;

            yield return instance.fade.DOFade(1, fadeDuration).SetEase(Ease.InOutBounce).WaitForCompletion();

            AsyncOperation load0p = SceneManagementUnity.LoadSceneAsync(sceneName);
            while (!load0p.isDone)
            {
                yield return null;
            }
            
            instance.fade.DOFade(0, fadeDuration).SetEase(Ease.InOutBounce);

           isLoadingScene = false;

        }
    }
}
