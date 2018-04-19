using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	void Update ()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.C))
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
#endif
	}
}
