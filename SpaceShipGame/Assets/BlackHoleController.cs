using UnityEngine;
using UnityEngine.UI;

public class BlackHoleController : MonoBehaviour
{
    public GameObject PnlInputCommands;
    public float rotateSpeed = 0.1f;

    [TextArea]
    public string Text;

    public GameObject InfoPanel;
    public GameObject HeroObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Hero"))
        {
            Debug.Log(other.name);
            
            var hero = GameObject.Find("Hero");
            var ship = hero.GetComponent<GameShipController>();
            ship.ToStartPosition();
        }
    }

    public void ShowInfoPanel()
    {
        PnlInputCommands.SetActive(false);
        //HeroObject.SetActive(InfoPanel.activeSelf);
        InfoPanel.SetActive(!InfoPanel.activeSelf);
        InfoPanel.GetComponentInChildren<Text>().text = Text;
    }
}
