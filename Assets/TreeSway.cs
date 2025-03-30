using UnityEngine;

public class TreeSway : MonoBehaviour
{
    public float swayAmount = 0.1f;
    public float swaySpeed = 1.0f;

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localPosition = new Vector3(sway, transform.localPosition.y, transform.localPosition.z);
    }
}
