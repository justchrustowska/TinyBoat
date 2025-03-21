using UnityEngine;

public class WaterWaves : MonoBehaviour
{
    public float swayAmplitude = 5f; // Kąt kołysania w stopniach
    public float swayFrequency = 1f; // Częstotliwość kołysania

    private float initialRotationZ;

    void Start()
    {
        // Zapamiętaj początkową rotację
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        // Oblicz nową rotację na osi Z
        float swayAngle = Mathf.Sin(Time.time * swayFrequency) * swayAmplitude;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, initialRotationZ + swayAngle);
    }
}