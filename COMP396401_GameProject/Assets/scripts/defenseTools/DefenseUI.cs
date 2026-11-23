using UnityEngine;
using UnityEngine.UI;
public class DefenseUI : MonoBehaviour


{
    [Header("UI Panels")]

    [SerializeField] private GameObject CrossBowUI;
    [SerializeField] private GameObject CannonUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OpenCrossBowUI()
    {
        CrossBowUI.SetActive(true);
        CannonUI.SetActive(false);
    }
    public void CloseCrossBowUI() 
    {
        CrossBowUI.SetActive(false);
    }
    public void OpenCanonUI()
    {
        CannonUI.SetActive(true);
        CrossBowUI.SetActive(false);
    }
    public void CloseCanonUI()
    {
        CannonUI.SetActive(false);
    }
    public void CloseBothBuyUI()
    {
        CannonUI.SetActive(false);
        CrossBowUI.SetActive(false);
    }
}
