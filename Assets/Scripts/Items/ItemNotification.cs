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
            NotificationName.text = "������� ����";

            NotificationText.text = "����������� ����, ���� ���� ���� ������ �� ������";
        }

        if (ID == 2)
        {
            NotificationName.text = "�������� �����";

            NotificationText.text = "������� ���������� �� �����, �� ���������� �� ���?";
        }

        if (ID == 3)
        {
            NotificationName.text = "������ �������";

            NotificationText.text = "��������� �������������� �������";
        }

        if (ID == 4)
        {
            NotificationName.text = "׸���� �������";

            NotificationText.text = "������� ��� ���������� �������";
        }

        if (ID == 5)
        {
            NotificationName.text = "����� �������";

            NotificationText.text = "�������� ���� ����������";
        }

        if (ID == 6)
        {
            NotificationName.text = "������������ ����";

            NotificationText.text = "�������������� ����� ���������� ��������";
        }

        if (ID == 7)
        {
            NotificationName.text = "������� ������";

            NotificationText.text = "����������� ��������� ���� �������";
        }

        if (ID == 8)
        {
            NotificationName.text = "���������";

            NotificationText.text = "...��� ���? �����?";
        }

        if (ID == 9)
        {
            NotificationName.text = "������ �������";

            NotificationText.text = "����� ����� ���� ������ � ����� ������������";
        }

        if (ID == 10)
        {
            NotificationName.text = "�������";

            NotificationText.text = "������� ���� ������ ��������!";
        }

        if (ID == 11)
        {
            NotificationName.text = "������ �������";

            NotificationText.text = "���� �������� ������� ��������";
        }

        if (ID == 12)
        {
            NotificationName.text = "�������� � ��������";

            NotificationText.text = "������ ����� ��������� ����������";
        }

        if (ID == 13)
        {
            NotificationName.text = "���� �� �������";

            NotificationText.text = "����� �������� ������ ������� ��������";
        }

        if (ID == 14)
        {
            NotificationName.text = "������ �������";

            NotificationText.text = "������ ������ ����";
        }

        ItemsOrder.Remove(ItemsOrder[0]);
    }
}
