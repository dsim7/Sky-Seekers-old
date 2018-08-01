using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {

    public TeamController teamController;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            teamController.DoLightAttack();
        }
    }
}
