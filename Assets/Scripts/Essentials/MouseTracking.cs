using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point,0.1f);

            /*
            if (Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
            */
        }

        

    }
}
