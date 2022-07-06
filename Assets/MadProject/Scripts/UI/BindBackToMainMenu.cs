using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindBackToMainMenu : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    private Button _backButton;

    private void OnValidate()
    {
        _backButton = GetComponent<Button>();
    }

    void Start()
    {
        _backButton.onClick.AddListener(() => SceneLoader.Instance.ReturnToMainMenu());
    }
}
