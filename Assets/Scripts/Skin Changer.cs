using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI skinName;

    
    Button button;

    int skinID = 0;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ChangeSkin(true));
    }

    private void Start()
    {
        skinID = GameObject.FindWithTag("Manager").GetComponent<GameManager>().skinNo;
        ChangeSkin(false);
    }

    public void ChangeSkin(bool changing)
    {
        GameManager gm = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        if (changing) skinID = skinID+2;
        if (skinID > 4) skinID = 0;
        switch (skinID)
        {
            default:
            case 0:
                skinName.SetText("Chicken");
                gm.skinNo = 0;
                break;
            case 2:
                skinName.SetText("Zombie Chicken");
                gm.skinNo = 2;
                break;
            case 4:
                skinName.SetText("Mecha Chicken");
                gm.skinNo = 4;
                break;

        }
    }
}
