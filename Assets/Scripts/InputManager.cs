using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo rotacion de camara
//todo input con mando?
//rotar las dos caras de en medio? M
public class InputManager : MonoBehaviour
{
    public RubikCube cube;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            cube.Rotate(FaceType.U, true);
        else if (Input.GetKeyDown(KeyCode.Q))
            cube.Rotate(FaceType.U, false);
        else if (Input.GetKeyDown(KeyCode.S))
            cube.Rotate(FaceType.D, true);
        else if (Input.GetKeyDown(KeyCode.W))
            cube.Rotate(FaceType.D, false);
        else if (Input.GetKeyDown(KeyCode.D))
            cube.Rotate(FaceType.L, true);
        else if (Input.GetKeyDown(KeyCode.E))
            cube.Rotate(FaceType.L, false);
        else if (Input.GetKeyDown(KeyCode.F))
            cube.Rotate(FaceType.R, true);
        else if (Input.GetKeyDown(KeyCode.R))
            cube.Rotate(FaceType.R, false);
        else if (Input.GetKeyDown(KeyCode.G))
            cube.Rotate(FaceType.F, true);
        else if (Input.GetKeyDown(KeyCode.T))
            cube.Rotate(FaceType.F, false);
        else if (Input.GetKeyDown(KeyCode.H))
            cube.Rotate(FaceType.B, true);
        else if (Input.GetKeyDown(KeyCode.Y))
            cube.Rotate(FaceType.B, false);
    }
}
