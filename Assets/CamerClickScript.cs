using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerClickScript : MonoBehaviour
{
    public Camera camera;
    private GameObject obj;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ra, out hit))
            {
                obj = hit.collider.gameObject;
                Vector3 targertScreenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
                offset = obj.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targertScreenPos.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            obj = null;
            offset = new Vector3();
        }

        if (obj)
        {
            Vector3 targertScreenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
            Vector3 mousPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targertScreenPos.z);
            obj.transform.position = Camera.main.ScreenToWorldPoint(mousPos) + offset;
        }
    }
}
