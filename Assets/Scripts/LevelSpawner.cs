using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawner : MonoBehaviour
{

    public static LevelSpawner instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private int debugger = 0;
    
    public int level = 0;
    public bool switchReady = false;
    [SerializeField]
    private bool debugging;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void nextScene() {
        StartCoroutine("switchScene");
    }

    private IEnumerator switchScene() {
        if (level <= 0) {
            if (debugging) {
                AsyncOperation operation = SceneManager.LoadSceneAsync(debugger, LoadSceneMode.Additive);
                yield return new WaitUntil(() => operation.isDone);
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(debugger));
                level = debugger;
            } else {
                level++;
                AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
                yield return new WaitUntil(() => operation.isDone);
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(level));
            }
        } else {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
            SceneManager.UnloadSceneAsync(level);
            level++;
            AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
            yield return new WaitUntil(() => operation.isDone);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(level));
        }
        Handheld.Vibrate();
        StopCoroutine("switchScene");
        
    }

    //reset level
    public void resetLevel() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        SceneManager.UnloadSceneAsync(level);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        operation.completed += delegate {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(level));
        };
    }
    
}
