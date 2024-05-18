using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemNotification : MonoBehaviour
{
    public List<int> ItemsOrder = new List<int>();
    public GameObject TextGameObject;
    public TextMeshProUGUI NotificationName;
    public TextMeshProUGUI NotificationText;

    public Animator Animator;

    private bool _isTextActive;

    private void Start()
    {
        Animator = TextGameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(_isTextActive == false)
        {
            StartCoroutine(ShowDescription());
        }
    }

    IEnumerator ShowDescription()
    {
        TextGameObject.SetActive(true);
        _isTextActive = true;

        while (ItemsOrder.Count != 0)
        {
            Notification();

            UnFadeTextBox();

            yield return new WaitForSeconds(3f);

            FadeTextBox();

            yield return new WaitForSeconds(0.5f);
        }

        TextGameObject.SetActive(false);
        _isTextActive = false;
    }

    private void UnFadeTextBox()
    {
        Animator.SetTrigger("UnFade");
    }
    private void FadeTextBox()
    {
        Animator.SetTrigger("Fade");
    }

    private void Notification()
    {
        var ID = ItemsOrder[0];

        if (ID == 1)
        {
            NotificationName.text = "Забытые пули";

            NotificationText.text = "Увеличивает урон, даже если урон нанесён не пулями";
        }

        if (ID == 2)
        {
            NotificationName.text = "Странная бомба";

            NotificationText.text = "Выстрел заменяется на бомбу, но безопаснее ли так?";
        }

        if (ID == 3)
        {
            NotificationName.text = "Боевой магазин";

            NotificationText.text = "Позволяет перезаряжаться быстрее";
        }

        if (ID == 4)
        {
            NotificationName.text = "Чёрный ботинок";

            NotificationText.text = "Простой шаг становится быстрее";
        }

        if (ID == 5)
        {
            NotificationName.text = "Белый ботинок";

            NotificationText.text = "Скорость бега повышается";
        }

        if (ID == 6)
        {
            NotificationName.text = "Декоративные очки";

            NotificationText.text = "Чувствительные места становятся заметнее";
        }

        if (ID == 7)
        {
            NotificationName.text = "Детская бусина";

            NotificationText.text = "Критические попадания бьют больнее";
        }

        if (ID == 8)
        {
            NotificationName.text = "ТроеШляпа";

            NotificationText.text = "...что это? Зачем?";
        }

        if (ID == 9)
        {
            NotificationName.text = "Кривое зеркало";

            NotificationText.text = "Враги видят тебя кривым и могут промахнуться";
        }

        if (ID == 10)
        {
            NotificationName.text = "Подарок";

            NotificationText.text = "Получай свои зелёные предметы!";
        }

        if (ID == 11)
        {
            NotificationName.text = "Особый подарок";

            NotificationText.text = "Тебе дарованы красные предметы";
        }

        if (ID == 12)
        {
            NotificationName.text = "Канистра с бензином";

            NotificationText.text = "Убитые враги поджигают окружающих";
        }

        if (ID == 13)
        {
            NotificationName.text = "Хлеб из запасов";

            NotificationText.text = "После перекуса всегда быстрее лечишься";
        }

        if (ID == 14)
        {
            NotificationName.text = "Зелёный ботинок";

            NotificationText.text = "Прыжки теперь выше";
        }

        ItemsOrder.Remove(ItemsOrder[0]);
    }
}
