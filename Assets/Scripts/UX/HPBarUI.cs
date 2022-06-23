using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Image Bar;

    public void SetHP(float HP) => Bar.fillAmount = HP;
}
