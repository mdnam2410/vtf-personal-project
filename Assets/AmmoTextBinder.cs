using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextBinder : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Ammo _ammo;

    private void OnValidate()
    {
        _ammo = GetComponent<Ammo>();
    }

    void Update()
    {
        _text.text = $"{_ammo.LoadedAmmo}/{_ammo.RemainingAmmo}";        
    }
}
