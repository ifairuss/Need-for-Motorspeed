using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moto Parameters")]
    [SerializeField] private float _speedMoto;

    [Header("Controll Parameters")]
    [SerializeField] private bool _canAndroid;
    [SerializeField] private bool _canPC;

    private Rect _leftPart = new Rect(0, 0, Screen.width / 2, Screen.height);
    private Rect _righttPart = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    
    private WheelJoint2D _wheel;
    private JointMotor2D _motor;

    private void Awake()
    {
        _wheel = GetComponentInChildren<WheelJoint2D>();
        _motor = _wheel.motor;
    }

    private void Update() => ControllerByke();

    private void ControllerByke()
    {
        if (_canAndroid)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 pos = touch.position;

                    if (_righttPart.Contains(pos))
                    {
                        //print(pos + "Right");    -- Dla testa
                        _motor.motorSpeed = _speedMoto;
                    }
                    else if (_leftPart.Contains(pos))
                    {
                        //print(pos + "Left");    -- Dla testa
                        _motor.motorSpeed = -_speedMoto;
                    }

                    _wheel.motor = _motor;
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    _motor.motorSpeed = 0;
                    _wheel.motor = _motor;
                }
            }

            _canPC = false;
        }

        float DirectionMove = Input.GetAxis("Horizontal");

        if (_canPC) 
        {
            if(_wheel != null)
            {
                _motor.motorSpeed = DirectionMove * _speedMoto;

                _wheel.motor = _motor;
            }
            else
            {
                return;
            }

            _canAndroid = false;
        }
    }
}
