using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private GameObject placeableObject;

    private Vector3 pos;
    public float rotateAmount;

    private RaycastHit hit;
    private RaycastHit checkHit;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obtsacleLayer;

    private Camera mainCam;

    public float gridSize = 1;
    public bool gridOn = true;

    public TextMeshProUGUI trap1Miktar;
    public TextMeshProUGUI trap2Miktar;
    public TextMeshProUGUI trap3Miktar;
    public TextMeshProUGUI trap4Miktar;

    public int trap1StartAmount = 0;
    private int _trap1Amount;
    public int trap2StartAmount = 0;
    private int _trap2Amount;
    public int trap3StartAmount = 0;
    private int _trap3Amount;
    public int trap4StartAmount = 0;
    private int _trap4Amount;

    public Button trap1;
    public Button trap2;
    public Button trap3;
    public Button trap4;

    int selecetedObjIndex;

    public List<GameObject> obstacles = new List<GameObject>();

    bool canPlace = true;

    public GameObject b1L;
    public GameObject b2L;
    public GameObject b3L;
    public GameObject b4L;

    private void Start()
    {
        mainCam = Camera.main;

        _trap1Amount = trap1StartAmount;
        _trap2Amount = trap2StartAmount;
        _trap3Amount = trap3StartAmount;
        _trap4Amount = trap4StartAmount;
        ButtonControl();

    }

    private void Update()
    {
        if (placeableObject != null)
        {
            if (gridOn)
            {
                placeableObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                    );
            }
            else
            {
                placeableObject.transform.position = pos;
            }

            PlaceObject();

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }

    public void SetTraps(int _trap, int _amount)
    {
        if (_trap == 1)
        {
            trap1StartAmount = _amount;
        }

        if (_trap == 2)
        {
            trap2StartAmount = _amount;
        }

        if (_trap == 3)
        {
            trap3StartAmount = _amount;
        }

        if (_trap == 4)
        {
            trap4StartAmount = _amount;
        }

        _trap1Amount = trap1StartAmount;
        _trap2Amount = trap2StartAmount;
        _trap3Amount = trap3StartAmount;
        _trap4Amount = trap4StartAmount;

        ButtonControl();
    }

    private void PlaceObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            obstacles.Add(placeableObject.gameObject);
            DecreaseAmount();
            placeableObject = null;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(placeableObject.gameObject);
            placeableObject = null;
        }
    }

    private void ButtonControl()
    {
        if (_trap1Amount == 0)
        {
            trap1.interactable = false;
            b1L.SetActive(true);
        }
        else
        {
            trap1.interactable = true;
            b1L.SetActive(false);
        }
        if (_trap2Amount == 0)
        {
            trap2.interactable = false;
            b2L.SetActive(true);
        }
        else
        {
            trap2.interactable = true;
            b2L.SetActive(false);
        }
        if (_trap3Amount == 0)
        {
            trap3.interactable = false;
            b3L.SetActive(true);
        }
        else
        {
            trap3.interactable = true;
            b3L.SetActive(false);
        }
        if (_trap4Amount == 0)
        {
            trap4.interactable = false;
            b4L.SetActive(true);
        }
        else
        {
            trap4.interactable = true;
            b4L.SetActive(false);
        }

        trap1Miktar.SetText(_trap1Amount.ToString());
        trap2Miktar.SetText(_trap2Amount.ToString());
        trap3Miktar.SetText(_trap3Amount.ToString());
        trap4Miktar.SetText(_trap4Amount.ToString());
    }

    private void DecreaseAmount()
    {
        if (selecetedObjIndex == 0)
            _trap1Amount--;

        if (selecetedObjIndex == 1)
            _trap2Amount--;

        if (selecetedObjIndex == 2)
            _trap3Amount--;

        if (selecetedObjIndex == 3)
            _trap4Amount--;

        ButtonControl();
    }

    private void RotateObject()
    {
        if (placeableObject == null)
            return;

        if (selecetedObjIndex != 3)
        {
            placeableObject.transform.Rotate(Vector3.up, rotateAmount);
        }
        else
        {
            placeableObject.transform.Rotate(Vector3.up, 180);
        }
    }

    private void FixedUpdate()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Ground")
            {
                canPlace = true;
                pos = hit.point;
            }
            else
            {
                canPlace = false;
            }
        }
    }

    public void SelectObject(int index)
    {
        selecetedObjIndex = index;
        placeableObject = Instantiate(objects[index], pos, Quaternion.identity);
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }

    public void OnClickReset()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            GameObject _obj = obstacles[i].gameObject;
            Destroy(_obj.gameObject);
        }

        obstacles.Clear();

        _trap1Amount = trap1StartAmount;
        _trap2Amount = trap2StartAmount;
        _trap3Amount = trap3StartAmount;
        _trap4Amount = trap4StartAmount;

        ButtonControl();
    }




}
