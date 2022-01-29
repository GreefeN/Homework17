using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen; //экран смерти
    public Image _hpLine; //полоска отображающая количество здоровья    

    /// <summary>
    /// включение экрана смерти
    /// </summary>
    public void ActivateDeathScreen()
    {
        _deathScreen.SetActive(true);
    }
}
