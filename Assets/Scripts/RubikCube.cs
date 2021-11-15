using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 algoritmo optimizado que resuelva el cubo 
 juego para que la gente resuelva el cubo
 juego glitch en el que los bloques no cambien de cara al rotar, y se overlapee todo, y el jugador tenga que resolverlo entendiendo la lógica de las cosas overlapeadas
 juego que muestre el cubo como una proyeccion del cubo en consola
 */
public class RubikCube : MonoBehaviour
{
    public Block [] blocks = new Block[26];
    Transform rotationParent;
    List<Face> faces;
    
    private void Start()
    {
        rotationParent = transform.Find("RotationParent");
        IniFaces();
    }

    public void Rotate(FaceType t, bool clockwise)
    {
        Debug.Log(t.ToString() + " " + ((clockwise) ? "clockwise" : "anticlockwise"));

        Face f = null;
        for (int i = 0; i < faces.Count; ++i)
        {
            if (faces[i].GetFaceType == t)
            {
                f = faces[i];
                break;
            }
        }
        if (f == null)
        {
            Debug.LogError("face not found");
            return;
        }
        //todo finish corrutine
        foreach(Block b in rotationParent.GetComponentsInChildren<Block>())
        {
            b.transform.SetParent(transform);
        }
        foreach (Block b in f.GetBlocks)
        {
            b.transform.SetParent(rotationParent);
        }

        //todo corrutine
        rotationParent.Rotate(GetVector3Rotation(t, clockwise));
        //todo cambiar la lista de blocks de una cara
        //todo cambiar la lista de caras de cada block implicado en el giro
    }
    
    static Vector3 GetVector3Rotation(FaceType t, bool clockwise)
    {
        int x = (t == FaceType.L) ? 90 : (t == FaceType.R) ? -90 : 0;
        int y = (t == FaceType.U) ? 90 : (t == FaceType.D) ? -90 : 0;
        int z = (t == FaceType.F) ? 90 : (t == FaceType.B) ? -90 : 0;
        return new Vector3(x, y, z) * ((clockwise)? 1: -1);
    }

    void IniFaces()
    {
        faces = new List<Face>();
        for(int i = 0; i < FaceType.GetNames(typeof(FaceType)).Length; ++i)
        {
            //Debug.Log(FaceType.GetNames(typeof(FaceType)).Length + " " + i + " " + (FaceType)i);
            Face f = new Face((FaceType)i);
            IniBlocks(f);
            faces.Add(f);
        }
    }

    void IniBlocks(Face f)
    {
        for (int i = 0; i < blocks.Length; ++i)
        {
            //añadir a cada face la lista de blocks
            if (blocks[i].FaceIsParent(f.GetFaceType))
                f.AddBlock(blocks[i]);
        }
    }
}
