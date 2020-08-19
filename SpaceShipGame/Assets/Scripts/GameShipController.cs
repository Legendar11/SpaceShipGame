using LearnCSharpGameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameShipController : MonoBehaviour
{
    private Executor shipExecutor = new Executor();

    public InputField inputField;

    private Animator GameShipAnimator;
    public GameObject GameShip;
    
    public GameObject GameInforamtionMessage;

    private Queue<Action> queueActions = new Queue<Action>();

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameShipAnimator = GameShip.GetComponent<Animator>();
        shipExecutor.ship.AnimationStateChanged += AnimationStateChanged;
        shipExecutor.ship.PositionChanged += PositionChanged;
        shipExecutor.ship.SendedMessage += SendedMessage;
        
        startPosition = GameShip.transform.localPosition;
        ToStartPosition(false);

        RectTransform rt = GameShip.transform.GetComponent<RectTransform>();
        var width = rt.sizeDelta.x * rt.localScale.x;
        shipExecutor.ship.ScalePosition = width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (queueActions.Count > 0)
        {
            queueActions.Peek()();
        }
    }

    public void ToStartPosition(bool withAuch = true)
    {
        queueActions.Clear();
        shipExecutor.ship.SetInitialPosition(startPosition.x, startPosition.y);
        GameShip.transform.localPosition = startPosition;

        if (withAuch)
            SendedMessage("Ой!");
    }

    public void InputCode()
    {
        var scene = SceneManager.GetActiveScene();
        if (scene.name == "GameLevel4")
        {
            if (!shipExecutor.GameLeve2If(inputField.text, out var errMessage))
            {
                SendedMessage(errMessage);
                return;
            }
        }
        if (scene.name == "GameLevel2")
        {
            if (!shipExecutor.GameLeve3If(inputField.text, out var errMessage))
            {
                SendedMessage(errMessage);
                return;
            }
        }
        if (scene.name == "GameLevel3")
        {
            if (!shipExecutor.GameLeve4If(inputField.text, out var errMessage))
            {
                SendedMessage(errMessage);
                return;
            }
        }

        shipExecutor.Execute(inputField.text);

        if (scene.name == "GameLevel2")
        {
            if (inputField.text.Contains("5"))
            {
                var goDown1 = String.Concat(Enumerable.Repeat("ship.GoDown();", 6));
                var goRight1 = String.Concat(Enumerable.Repeat("ship.GoRight();", 10));
                var goDown2 = String.Concat(Enumerable.Repeat("ship.GoDown();", 4));
                var goRight2 = String.Concat(Enumerable.Repeat("ship.GoRight();", 6));
                shipExecutor.Execute(goDown1 + goRight1 + goDown2 + goRight2);
            }
            else
            {
                SendedMessage("Неверно посчитан кол-во планет и их спутников");
            }
        }
        if (scene.name == "GameLevel3")
        {
            var goDown1 = String.Concat(Enumerable.Repeat("ship.GoDown();", 15));
            var goRight1 = String.Concat(Enumerable.Repeat("ship.GoRight();", 17));
            var goUp1 = String.Concat(Enumerable.Repeat("ship.GoUp();", 4));
            shipExecutor.Execute(goDown1 + goRight1 + goUp1);
        }
    }

    public void SendRandomText()
    {
        var result = string.Empty;

        var messages = new[]
        {
            "Команда находится в кружочке.",
            "Запуск ракеты откладывается!",
            "Сколько можно ждать?!",
            "Вперед, в неизвестность!",
            "Хватит в меня тыкать!",
            "Мне нужно в черную дыру, срочно!",
            "Самые лучшие подскази на MSDN!",
            "Ни пуха, ни винта!",
            "У меня тоже есть решетка!",
            "Кто тут самый-самый лучший корабль во всей Вселенной и за ее пределами?",
            "Когда мы уже полетим?",
            "А космические корабли ходят или летают?",
            "Я летаю в кастрюле! В галактической кастрюле!",
            "У меня самая лучшая галактическая реактивная кастрюля N-182!",
            "У меня закончились фразы..."
        };
        result = messages[UnityEngine.Random.Range(0, messages.Length)];
        SendedMessage(result);
    }

    private void PositionChanged(float x, float y)
    {
        queueActions.Enqueue(() =>
        {
            var targetPoint = GameShip.transform.localPosition;
            targetPoint.x = x;
            targetPoint.y = y;
            GameShip.transform.localPosition = Vector3.MoveTowards(GameShip.transform.localPosition, targetPoint, 2.2f);

            if (GameShip.transform.localPosition == targetPoint)
            {
                queueActions.Dequeue();
            }
        });
    }

    private void AnimationStateChanged(bool isAnimationWork)
    {
        if (isAnimationWork)
        {
            if (GameShipAnimator.speed == 0)
                GameShipAnimator.speed = 1;
        }
        else
        {
            if (GameShipAnimator.speed == 1)
                GameShipAnimator.speed = 0;
        }
    }

    private void SendedMessage(string message)
    {
        queueActions.Enqueue(() =>
        {
            GameInforamtionMessage.GetComponent<TextTyper>().SetTextAndPlay(message, true, true);

            queueActions.Dequeue();
        });
    }
}
