using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUiManager : MonoBehaviour
{
    [SerializeField] Image AiHealthFill;
    public void AiHealthUI(float value)
    {
        AiHealthFill.fillAmount = value * 0.01f;
    }
}
