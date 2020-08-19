using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private ScenesParametrs sceneParametrs;

    // Start is called before the first frame update
    void Start()
    {
        sceneParametrs = GameObject.Find("RootGameObject").GetComponent<ScenesParametrs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        sceneParametrs.NextSceneForLoad = "GameBeginning";
        SceneManager.LoadScene("SceneLoadTransition");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
