using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinMove : MonoBehaviour
{

    private float _x_angle = 0f;
    private float _y_angle = 0f;
    //private float _x_pin_offset = 0f; // -155(-90) ~ 155(90) // 0.58 <-> 1.72
    public Text _txt_x_angle;
    public Transform _x_gauge;
    public Transform _x_gauge1;

    public Text _txt_y_angle;
    public Transform _y_gauge;
    public Transform _y_gauge1;

    public Text _txt_z_angle;
    private float _z_angle = 0f;
    public Transform _z_gauge;

    public Transform _cross_pin;

	void Start ()
    {
	}

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _x_angle -= Time.deltaTime * 50f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _x_angle += Time.deltaTime * 50f;
        }
        if(_x_angle > 90f)
        {
            _x_angle = 90f;
        }
        if (_x_angle < -90f)
        {
            _x_angle = -90f;
        }
        _txt_x_angle.text = _x_angle.ToString();
        AngleToOffset(_x_angle, _x_gauge);
        AngleToOffset(_x_angle, _x_gauge1);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _y_angle -= Time.deltaTime * 50f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _y_angle += Time.deltaTime * 50f;
        }
        if (_y_angle > 90f)
        {
            _y_angle = 90f;
        }
        if (_y_angle < -90f)
        {
            _y_angle = -90f;
        }
        _txt_y_angle.text = _y_angle.ToString();
        AngleToOffset(_y_angle, _y_gauge);
        AngleToOffset(_y_angle, _y_gauge1);

        if (Input.GetKey(KeyCode.A))
        {
            _z_angle += Time.deltaTime * 50f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _z_angle -= Time.deltaTime * 50f;
        }
        _txt_z_angle.text = _z_angle.ToString();
        _z_gauge.localEulerAngles = new Vector3(0f, 0f, _z_angle);

        AngleToOffset(_x_angle, _y_angle, _z_angle, _cross_pin);
    }

    private void AngleToOffset(float angle, Transform tm)
    {
        float res = angle * 1.72f;
        tm.localPosition = new Vector3(res, 0f, 0f);
    }

    private void AngleToOffset(float x_angle, float y_angle, float z_angle, Transform tm)
    {
        float modi_x = x_angle * 1.72f;
        float modi_y = y_angle * 1.72f;

        tm.localPosition = new Vector3(modi_x, modi_y, 0f);
        tm.localEulerAngles = new Vector3(0f, 0f, z_angle);
    }

}
