using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraHolder;
    public float RotationSpeedParameter = 1;
    public float MinAngle;
    public float MaxAngle;

    private void Start()
    {
        PrefsChange();
    }

    public void PrefsChange()
    {
        RotationSpeedParameter = PlayerPrefs.GetFloat("Sensitivity", 0.5f);
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            var NewAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * RotationSpeedParameter * 8;
            transform.localEulerAngles = new Vector3(0, NewAngleY, 0);

            var NewAngleX = CameraHolder.localEulerAngles.x - Input.GetAxis("Mouse Y") * RotationSpeedParameter * 5;
            if (NewAngleX > 180)
                NewAngleX -= 360;

            NewAngleX = Mathf.Clamp(NewAngleX, MinAngle, MaxAngle);

            CameraHolder.localEulerAngles = new Vector3(NewAngleX, 0, 0);
        }
    }
}
