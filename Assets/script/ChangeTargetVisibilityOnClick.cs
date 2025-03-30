using UnityEngine;

public class ChangeTargetVisibilityOnKeyPress : MonoBehaviour
{
    public GameObject targetObject; // Целевой объект, видимость которого нужно менять
    public string targetLayerName = "NewLayer"; // Имя целевого слоя для объекта
    public KeyCode activationKey = KeyCode.E; // Клавиша для активации
    public bool startVisible = true; //начальная видимость обьекта

    private int targetLayer;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object is not assigned!  Please assign it in the Inspector.");
            enabled = false; // Disable the script if the target object is not assigned
            return;
        }

        // Назначаем слой
        targetLayer = LayerMask.NameToLayer(targetLayerName);

        if (targetLayer == -1)
        {
            Debug.LogError("Layer '" + targetLayerName + "' not found! Please create it in Edit -> Project Settings -> Tags and Layers.");
            enabled = false; // Disable the script if the layer doesn't exist
            return;
        }
        // Стартовая видимость обьекта
        targetObject.SetActive(startVisible);
    }

    void Update()
    {
        // Проверяем нажатие клавиши
        if (Input.GetKeyDown(activationKey))
        {
            // Изменяем видимость целевого объекта
            targetObject.SetActive(!targetObject.activeSelf); // Инвертируем текущее состояние
            targetObject.layer = targetLayer; // Устанавливаем слой
        }
    }
}
