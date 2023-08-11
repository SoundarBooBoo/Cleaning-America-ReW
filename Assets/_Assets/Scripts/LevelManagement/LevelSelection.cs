using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    
    
    
        void Update()
        {

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Cast a ray and check for hits
            {
                // Check if the ray hit an object
                GameObject hitObject = hit.collider.gameObject;

                // Do something with the hit object, like logging its name
                Level level = hitObject.GetComponent<Level>();
                if (level != null)
                {
                    level.LoadScene();
                }
            }
        }
#endif
        // Check for touches
        if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // Get the first touch

                if (touch.phase == TouchPhase.Began) // Check if touch began
                {
                    // Create a ray from the touch position
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit)) // Cast a ray and check for hits
                    {
                        // Check if the ray hit an object
                        GameObject hitObject = hit.collider.gameObject;

                        // Do something with the hit object, like logging its name
                        Level level = hitObject.GetComponent<Level>();
                    if (level != null)
                    {
                        level.LoadScene();
                    }
                    }
                }
            }
        }
    
}
