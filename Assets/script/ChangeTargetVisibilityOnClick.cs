using UnityEngine;

public class ChangeTargetVisibilityOnKeyPress : MonoBehaviour
{
    public GameObject targetObject; // ������� ������, ��������� �������� ����� ������
    public string targetLayerName = "NewLayer"; // ��� �������� ���� ��� �������
    public KeyCode activationKey = KeyCode.E; // ������� ��� ���������
    public bool startVisible = true; //��������� ��������� �������

    private int targetLayer;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object is not assigned!  Please assign it in the Inspector.");
            enabled = false; // Disable the script if the target object is not assigned
            return;
        }

        // ��������� ����
        targetLayer = LayerMask.NameToLayer(targetLayerName);

        if (targetLayer == -1)
        {
            Debug.LogError("Layer '" + targetLayerName + "' not found! Please create it in Edit -> Project Settings -> Tags and Layers.");
            enabled = false; // Disable the script if the layer doesn't exist
            return;
        }
        // ��������� ��������� �������
        targetObject.SetActive(startVisible);
    }

    void Update()
    {
        // ��������� ������� �������
        if (Input.GetKeyDown(activationKey))
        {
            // �������� ��������� �������� �������
            targetObject.SetActive(!targetObject.activeSelf); // ����������� ������� ���������
            targetObject.layer = targetLayer; // ������������� ����
        }
    }
}
