using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager lineManager;
    public bool restart = true;
    public GameObject linePrefab;
    public FlexibleColorPicker colorPicker;
    public static bool click = false;

    private void Awake()
    {
        lineManager = this;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && restart)
        {
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.transform != null)
            //    {
            //        if (FindObjectOfType<Draw>() != null)
            //        {
            //            Destroy(FindObjectOfType<Draw>());
            //        }

            //        var line = Instantiate(linePrefab);
            //        line.GetComponent<LineRenderer>().materials[0].color = colorPicker.color;
            //        line.transform.position = hit.point;
            //        line.GetComponent<LineRenderer>().SetPosition(0, hit.point);
            //        line.AddComponent<Draw>();
            //        restart = false;
            //    }
            //}
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Debug.Log(mousePos);
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.zero);
            if (hit2D.collider != null && mousePos.x >= -1.75f && mousePos.x <= 10)
            {

                if (FindObjectOfType<Draw>() != null)
                {
                    Destroy(FindObjectOfType<Draw>());
                }

                var line = Instantiate(linePrefab);
                line.GetComponent<LineRenderer>().materials[0].color = colorPicker.color;
                line.transform.position = hit2D.point;
                line.GetComponent<LineRenderer>().SetPosition(0, mousePos);
                line.AddComponent<Draw>();
                restart = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            restart = true;
        }
    }
}
