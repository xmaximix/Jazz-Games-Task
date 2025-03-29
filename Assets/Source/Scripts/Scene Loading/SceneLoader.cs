    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using VContainer;
    using VContainer.Unity;

    namespace Source.Scripts.Scene_Loading
    {
        public class SceneLoader
        {
            private readonly LifetimeScope parentScope;

            public SceneLoader(LifetimeScope parent)
            {
                parentScope = parent; 
            }

            public IEnumerator LoadSceneAsync(string sceneName)
            {
                using (LifetimeScope.EnqueueParent(parentScope))
                {
                    var loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                    while (!loading.isDone)
                    {
                        yield return null;
                    }
                }
            }
        }
    }