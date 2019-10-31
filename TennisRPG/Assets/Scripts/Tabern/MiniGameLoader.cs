using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetButtonDown("Fire2"))
            return;

        switch (gameObject.name)
        {
            case "PongScene":
                SceneManager.LoadScene("TennisPong1_1");
                break;

            case "TennisEssenceScene":
                SceneManager.LoadScene("TennisEssence");
                break;

            case "TennisBreakerScene":
                SceneManager.LoadScene("TennisBreaker");
                break;
        }
    }
}
