using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderJointScript : MonoBehaviour
{
    private SliderJoint2D _joint;
    private JointMotor2D _motor; //экземпляр мотора для присвоения новых значений в мотор джоинта
    private JointTranslationLimits2D _limit; //экземпляр лимитов для присвоения новых значений в лимиты джоинта
    [SerializeField] private float _distance = 4f; //расстояние движения джоинта
    [SerializeField] private float _speed = 0.5f; //скорость движения объекта

    void Start()
    {
        _joint = GetComponent<SliderJoint2D>();
        _joint.useMotor = true; //включаем мотор если отключен в компоненте
        _joint.useLimits = true; //включаем лимиты если отключены в компоненте
        _limit.max = _distance; //назначаем UpperLimit в экземпляре лимитов
        _joint.limits = _limit; //присваиваем новые лимиты в джоинт
        _motor = _joint.motor; //берем изначальные значения мотора джоинта в экземпляр мотора, на случай если в моторе будут произведены настройки через инспектор
    }


    void Update()
    {
        if (_joint.limitState == JointLimitState2D.LowerLimit) //начинаем с limitState = LowerLimit, так же при повторных достижения LowerLimit, назначаем мотору скорость
        {
            _motor.motorSpeed = _speed;
            _joint.motor = _motor;
        }
        else if (_joint.limitState == JointLimitState2D.UpperLimit) //при достижении UpperLimit меняем знак значения скорости мотора
        {
            _motor.motorSpeed = _speed * -1f;
            _joint.motor = _motor;
        }
    }
}