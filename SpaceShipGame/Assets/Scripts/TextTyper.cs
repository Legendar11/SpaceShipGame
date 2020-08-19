using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour
{
    Image image;
    Text txtInput;
    string storedText;

    public float Offset;

    public float Interval;

    private bool WithReverse = false;
    private float WithReverseInterval = 2.5f;

    private bool WithHide = false;

    private bool isStarted = false;

    void Awake()
    {
        txtInput = GetComponent<Text>() ?? GetComponentInChildren<Text>();
        image = GetComponent<Image>();
        storedText = txtInput.text;
        txtInput.text = string.Empty;
    }

    void Start()
    {
        StartCoroutine(nameof(PlayText));
    }

    public void SetTextAndPlay(string text, bool withReverse = false, bool withHide = false)
    {
        WithReverse = withReverse;
        WithHide = withHide;

        storedText += " " + text;
        StartCoroutine(nameof(PlayText));
        isStarted = true;
    }

    IEnumerator PlayText()
    {
        if (isStarted)
            yield break;

        yield return new WaitForSeconds(Offset);


        if (WithHide)
        {
            var color = image.color;
            color.a = 1;
            image.color = color;
        }

        while (storedText.Length > 0)
        {
            txtInput.text += storedText[0];
            storedText = storedText.Substring(1);
            yield return new WaitForSeconds(Interval);

            if (WithReverse && txtInput.text.Length >= 50)
            {
                txtInput.text = txtInput.text.Substring(1);
                yield return new WaitForSeconds(Interval / 2);
            }
        }

        if (WithReverse)
        {
            yield return new WaitForSeconds(WithReverseInterval);
            while (txtInput.text.Length > 0)
            {
                txtInput.text = txtInput.text.Substring(0, txtInput.text.Length - 1);
                yield return new WaitForSeconds(Interval / 2);
            }
        }

        if (WithHide)
        {
            var color = image.color;
            color.a = 0;
            image.color = color;
        }

        storedText = string.Empty;
        isStarted = false;
    }
}
