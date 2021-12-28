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
        if (level <= 0) {
            if (debugging) {
                SceneManager.LoadScene(debugger, LoadSceneMode.Additive);
                level = debugger;
            } else {
                level++;
                SceneManager.LoadScene(level, LoadSceneMode.Additive);
            }
        } else {
            SceneManager.UnloadSceneAsync(level);
            level++;
            SceneManager.LoadScene(level, LoadSceneMode.Additive);
        }
        
    }
    
}
