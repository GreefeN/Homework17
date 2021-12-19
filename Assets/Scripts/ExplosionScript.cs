using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private GameObject _objectGenerate; //������ ������� ����� ������������
    private PointEffector2D _pointEff; //��� ��������� ������� ���������� ���������
    private CircleCollider2D _selfCollider; //����������� ��������� �������(��� ��������� �������)
    private Collider2D[] _objects; //������ �������� ��� ��������

    void Start()
    {
        _pointEff = GetComponent<PointEffector2D>();
        _selfCollider = GetComponent<CircleCollider2D>();
    }

    private IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(_objectGenerate, transform);
        }
        yield return new WaitForSeconds(2);
        _pointEff.forceMagnitude = 0;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void StartBlackHole()
    {
        _pointEff.forceMagnitude = -50;
        _objects = Physics2D.OverlapCircleAll(transform.position, _selfCollider.radius);
        foreach (var e in _objects)
        {
            if (e.attachedRigidbody)
            {
                Destroy(e.gameObject, 1f);
            }
        }
        StartCoroutine("ExplosionTimer");
    }
}
