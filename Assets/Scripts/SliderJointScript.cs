using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderJointScript : MonoBehaviour
{
    private SliderJoint2D _joint;
    private JointMotor2D _motor; //��������� ������ ��� ���������� ����� �������� � ����� �������
    private JointTranslationLimits2D _limit; //��������� ������� ��� ���������� ����� �������� � ������ �������
    [SerializeField] private float _distance = 4f; //���������� �������� �������
    [SerializeField] private float _speed = 0.5f; //�������� �������� �������

    void Start()
    {
        _joint = GetComponent<SliderJoint2D>();
        _joint.useMotor = true; //�������� ����� ���� �������� � ����������
        _joint.useLimits = true; //�������� ������ ���� ��������� � ����������
        _limit.max = _distance; //��������� UpperLimit � ���������� �������
        _joint.limits = _limit; //����������� ����� ������ � ������
        _motor = _joint.motor; //����� ����������� �������� ������ ������� � ��������� ������, �� ������ ���� � ������ ����� ����������� ��������� ����� ���������
    }


    void Update()
    {
        if (_joint.limitState == JointLimitState2D.LowerLimit) //�������� � limitState = LowerLimit, ��� �� ��� ��������� ���������� LowerLimit, ��������� ������ ��������
        {
            _motor.motorSpeed = _speed;
            _joint.motor = _motor;
        }
        else if (_joint.limitState == JointLimitState2D.UpperLimit) //��� ���������� UpperLimit ������ ���� �������� �������� ������
        {
            _motor.motorSpeed = _speed * -1f;
            _joint.motor = _motor;
        }
    }
}