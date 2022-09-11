using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Контроль управления вводом пользователя
    // false при навигации по меню и кат-сценах
    public bool isControllerEnabled = true;

    [Flags]
    public enum controlTypeEnum
    {
        MOUSE,
        TOUCH,
        KEYBOARD
    };

    public controlTypeEnum controlType = controlTypeEnum.KEYBOARD;

    // Скорость перемещения камеры
    [SerializeField]
    private float cameraMoveSpeed = 1f;

    // Увеличение или уменьшение зоны активации поворота камеры
    public float cameraMovingZoneOverdrive = 1f;

    private Transform cameraTransform;

    // Клавиши управления
    public KeyCode turnCameraLeft = KeyCode.A;
    public KeyCode turnCameraRight = KeyCode.D;

    // Поворот камеры по нажатию кнопки мыши
    public bool rotateOnlyWithRMB = true;

    void Start()
    {
        cameraTransform = gameObject.transform;
    }


    void FixedUpdate()
    {
        if (isControllerEnabled)
        {
            CameraControl();
        }
    }

    void CameraControl()
    {
        if (controlType == controlTypeEnum.TOUCH && Input.touchSupported && Input.touchCount == 1)
        {
            TouchControl();
        }
        else if (controlType == controlTypeEnum.KEYBOARD)
        {
            if (Input.GetKey(turnCameraLeft))
            {
                cameraTransform.Rotate(new Vector3(0, -cameraMoveSpeed, 0));
            }
            if (Input.GetKey(turnCameraRight))
            {
                cameraTransform.Rotate(new Vector3(0, cameraMoveSpeed, 0));
            }
        }
        else if (controlType == controlTypeEnum.MOUSE)
        {
            if (rotateOnlyWithRMB && Input.GetMouseButton(0))
            {
                MouseControl();
            }
            if (!rotateOnlyWithRMB)
            {
                MouseControl();
            }
        }
    }

    void MouseControl()
    {
        Vector2 mousePosition = Input.mousePosition;
        float inputZoneWidth = Screen.width / 8 * cameraMovingZoneOverdrive;

        if (mousePosition.x < inputZoneWidth)
        {
            cameraTransform.Rotate(new Vector3(0, -cameraMoveSpeed, 0));
        }
        if (mousePosition.x > Screen.width - inputZoneWidth)
        {
            cameraTransform.Rotate(new Vector3(0, cameraMoveSpeed, 0));
        }
    }

    void TouchControl()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        float inputZoneWidth = Screen.width / 4 * cameraMovingZoneOverdrive;

        if (touchPosition.x < inputZoneWidth)
        {
            cameraTransform.Rotate(new Vector3(0, -cameraMoveSpeed, 0));
        }
        if (touchPosition.x > Screen.width - inputZoneWidth)
        {
            cameraTransform.Rotate(new Vector3(0, cameraMoveSpeed, 0));
        }
    }
}
