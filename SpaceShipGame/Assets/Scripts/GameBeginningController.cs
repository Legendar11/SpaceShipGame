using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBeginningController : MonoBehaviour
{
    private bool isInputedCommand = false;

    public GameObject tutorial;
    public GameObject inputCode;
    public GameObject pnlWarning;
    public GameObject pnlSucsess;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommandWasInputed()
    {
        if (!isInputedCommand)
        {
            isInputedCommand = true;
            pnlSucsess.SetActive(true);
        }
        else
        {
            pnlSucsess.SetActive(false);
        }

        isInputedCommand = true;
    }

    public void BtnGoToInputCode()
    {
        tutorial.SetActive(false);
        inputCode.SetActive(true);
    }

    public void GoToNextLevel()
    {
        if (!isInputedCommand)
        {
            isInputedCommand = true;
            pnlWarning.SetActive(true);
            return;
        }

        SceneManager.LoadScene("GameLevel1");
    }

    public void CodeInputed()
    {
       
    }
}
