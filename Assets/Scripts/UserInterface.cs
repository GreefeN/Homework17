using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen; //����� ������
    public Image _hpLine; //������� ������������ ���������� ��������    

    /// <summary>
    /// ��������� ������ ������
    /// </summary>
    public void ActivateDeathScreen()
    {
        _deathScreen.SetActive(true);
    }
}
