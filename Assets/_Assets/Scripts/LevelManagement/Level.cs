using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    UTAH,
    CA,
    ARIZONA
}
public class Level : MonoBehaviour
{
    [SerializeField]
    SceneName scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
