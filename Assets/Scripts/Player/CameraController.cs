using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraHolder;
    public float RotationSpeedParameter = 1;
    public float MinAngle;
    public float MaxAngle;

    private void Start()
    {
        RotationSpeedParameter = PlayerPrefs.GetFloat("Sensitivity", 1);
    }

    void Update()
    {
        var NewAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeedParameter * 1100;
        transform.localEulerAngles = new Vector3(0, NewAngleY, 0);

        var NewAngleX = CameraHolder.localEulerAngles.x - Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSpeedParameter * 600;
        if (NewAngleX > 180)
            NewAngleX -= 360;

        NewAngleX = Mathf.Clamp(NewAngleX, MinAngle, MaxAngle);

        CameraHolder.localEulerAngles = new Vector3(NewAngleX, 0, 0);
    }
}
