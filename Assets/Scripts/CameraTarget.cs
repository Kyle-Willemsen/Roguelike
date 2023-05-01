using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    //[SerializeField] Camera cam;
    //[SerializeField] Transform player;
    //[SerializeField] float threshhold;
    //PlayerMovement pMove;
    //
    //rivate void Start()
    //
    //   pMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
    //
    //
    //rivate void Update()
    //{
    //   
    //   Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    //   Vector3 targetPos = (player.position + mousePos) / 2f;
    //   
    //   targetPos.x = Mathf.Clamp(targetPos.x, -threshhold + player.position.x, threshhold + player.position.x);
    //   targetPos.y = Mathf.Clamp(targetPos.y, -threshhold + player.position.y, threshhold + player.position.y);
    //   this.transform.position = targetPos;
    //}

    public Transform player;

    Vector3 target, mousePos, refvel, shakeOffset;

    float cameraDistance = 35f;

    float smoothTime = 0.2f, zStart;

    private void Start()
    {
        target = player.position;
        zStart = transform.position.z;
    }

    private void Update()
    {
        mousePos = CaptureMousePos();
        target = UpdateTargetPos();
        UpdateCameraPosition();
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized;
        }
        return ret;
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDistance;
        Vector3 ret = player.position + mouseOffset;
        ret.z = zStart;
        return ret;

    }

    private void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refvel, smoothTime);
        transform.position = tempPos;
    }
}
