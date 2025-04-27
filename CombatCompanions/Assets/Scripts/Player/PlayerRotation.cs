using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        //Mouse Position
        RaycastHit hit;
        Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit);

        if (hit.transform != null)
        {
            Vector3 lookPosition = new Vector3(hit.point.x, 0.5f, hit.point.z);
            transform.LookAt(lookPosition);
        }
    }
}
