using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] _arrows;
    [SerializeField] private float _pauseTime = 1f; //����� �������� ����� ����������� ���� �������� ����

    /// <summary>
    /// ���������� ������� �����
    /// </summary>
    public void ActivateArrowTrap()
    {
        StartCoroutine("ActivateArrow");
    }

    /// <summary>
    /// ���������� ������ ��� �������� ���� � �����
    /// </summary>
    /// <returns></returns>
    private IEnumerator ActivateArrow()
    {
        foreach(Rigidbody2D e in _arrows)
        {
            e.bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSeconds(_pauseTime);
        }        
    }
}
