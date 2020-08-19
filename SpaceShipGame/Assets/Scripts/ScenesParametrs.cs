using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesParametrs : MonoBehaviour
{
    public string NextSceneForLoad { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneForLoad);
    }
}
