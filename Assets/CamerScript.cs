using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CamerScript : MonoBehaviour
{
    public Camera camera;
    private Transform tarans;
    private float timer = 1f;

    private float moveSpeed = 6f;
    private float rotateSpeed = 2f;

    private float mouseDeltX = 0f;
    private float mouseDeltY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.camera.transform.position = new Vector3(0, 3, 0);
        this.tarans = this.camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
        //var pos = this.camera.transform.position;
        //if (timer <= 0)
        //{
        //    timer = 1f;
        //    float z = pos.z + 0.5f;
        //    this.camera.transform.position = new Vector3(0, 3, z);
        //}

        CameraKeyMove();
        CameraRotate();
    }
    private void CameraKeyMove()
    {
        float dit = Time.deltaTime * this.moveSpeed;
        Vector3 v3 = this.tarans.position;

        if (Input.GetKey(KeyCode.W))
        {
            tarans.Translate(Vector3.forward * dit);
        }
        if (Input.GetKey(KeyCode.S))
        {
            tarans.Translate(Vector3.back * dit);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tarans.Translate(Vector3.left * dit);
        }
        if (Input.GetKey(KeyCode.D))
        {
            tarans.Translate(Vector3.right * dit);
        }
    }

    private void CameraRotate()
    {
        if (Input.GetMouseButton(1))
        {
            mouseDeltX += Input.GetAxis("Mouse X") * this.rotateSpeed;
            mouseDeltY -= Input.GetAxis("Mouse Y") * this.rotateSpeed;
        }

        mouseDeltX = ClampAngle(mouseDeltX, -360, 360);
        mouseDeltY = ClampAngle(mouseDeltY, -70, 70);

        tarans.localRotation = Quaternion.Euler(mouseDeltY, mouseDeltX, 0);
    }

    private float ClampAngle(float angle, float minAngle, float maxAngle)
    {
        if (angle <= -360)
        {
            angle += 360;
        }

        if (angle >= 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, minAngle, maxAngle);
    }

}
