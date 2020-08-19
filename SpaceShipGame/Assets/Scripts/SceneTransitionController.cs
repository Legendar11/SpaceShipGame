using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    private ScenesParametrs sceneParametrs;

    // Start is called before the first frame update
    void Start()
    {
        sceneParametrs = GameObject.Find("RootGameObject").GetComponent<ScenesParametrs>();
    }

    public void LoadNextScene() => sceneParametrs.LoadNextScene();
}
