using UnityEngine;
using UnityEngine.UI;

public class RotateHorizontalController : MonoBehaviour
{
    public GameObject PnlInputCommands;
    public GameObject RootPosition;
    public float speed = 25;
    public float rotateSpeed = 0.1f;

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
        Vector3 point = RootPosition.transform.position;
        Vector3 axis = new Vector3(0, 1, 0);
        transform.RotateAround(point, axis, Time.deltaTime * speed);
        transform.localRotation = Quaternion.identity;

        var asd = GetComponent<Image>().color;
        float d = Time.time * speed;
        asd.a = Mathf.Clamp(d, 0, 1);
        GetComponent<Image>().color = asd;

        //transform.Rotate(0, 0, 0);
    }


    public void ShowInfoPanel()
    {
        PnlInputCommands.SetActive(false);
        //HeroObject.SetActive(InfoPanel.activeSelf);
        InfoPanel.SetActive(!InfoPanel.activeSelf);
        InfoPanel.GetComponentInChildren<Text>().text = Text;
    }
}
