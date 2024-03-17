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

    int skinID = 1;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ChangeSkin());
    }

    public void ChangeSkin()
    {
        GameManager gm = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        skinID++;
        if (skinID > 3) skinID = 1;
        switch (skinID)
        {
            default:
            case 1:
                skinName.SetText("Chicken");
                gm.skinNo = 1;
                break;
            case 2:
                skinName.SetText("Zombie Chicken");
                gm.skinNo = 2;
                break;
            case 3:
                skinName.SetText("Mecha Chicken");
                gm.skinNo = 3;
                break;

        }
    }
}
