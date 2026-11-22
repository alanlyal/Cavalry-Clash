using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DefensePlacement : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform defensePlot;
    [SerializeField] private Button PlaceButton;
    private GameObject currentDefense;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDefense != null)
        {
            Ray cam = playerCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(cam, out RaycastHit mouseClick, 100f))
            {
                Vector3 position = mouseClick.point;
                position.y = defensePlot.position.y + 1.5f;
            }
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                currentDefense = null;
            }
        }
    }
    public void PlaceDefense(GameObject defense)
    {
        currentDefense = Instantiate(defense, defensePlot.position + Vector3.up * 1.5f, Quaternion.identity);
        currentDefense.layer = 2;
        PlaceButton.gameObject.SetActive(false);
    }
}
