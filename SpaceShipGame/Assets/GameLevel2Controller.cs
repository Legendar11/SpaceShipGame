using UnityEngine;

public class GameLevel2Controller : MonoBehaviour
{
    public GameObject PnlInfo;
    public GameObject PnlInputCommands;
    public GameObject HeroObject;
    private SpriteRenderer imgHero;

    // Start is called before the first frame update
    void Start()
    {
        imgHero = HeroObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPlanet1Lune1Info()
    {

    }

    public void ShowPnlInputCommands()
    {
        var color = imgHero.color;
        if (PnlInputCommands.activeSelf)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.3f;
        }
        imgHero.color = color;
        PnlInputCommands.SetActive(!PnlInputCommands.activeSelf);
    }

    public void HidePnlInfo()
    {
        PnlInfo.SetActive(false);
        PnlInputCommands.SetActive(true);
    }
}
