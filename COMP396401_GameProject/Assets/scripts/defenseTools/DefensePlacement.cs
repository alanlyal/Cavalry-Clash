using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DefensePlacement : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform defensePlot;
    [SerializeField] private Button PlaceCannon;
    [SerializeField] private Button PlaceCrossbow;
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
        if (PlaceCannon != null)
        {
            PlaceCannon.gameObject.SetActive(false);
        }
        if (PlaceCrossbow != null)
        {
            PlaceCrossbow.gameObject.SetActive(false);
        }
    }
    public void LateUpdate()
    {
        if (playerCam == null || defensePlot == null)
        {
            return;
        }
        Vector3 btnsPosition = playerCam.WorldToScreenPoint(defensePlot.position);
        if (PlaceCannon != null)
        {
            PlaceCannon.transform.position = btnsPosition;
        }
        if (PlaceCrossbow != null)
        {
            PlaceCrossbow.transform.position = btnsPosition;
        }
    }

}
