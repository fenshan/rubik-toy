using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    List<FaceType> parents;

    private void Start()
    {
        parents = new List<FaceType>();
        IniParents();
        UpdateName();
    }

    public List<FaceType> GetFaces()
    {
        return parents;
    }

    void IniParents()
    {
        string faces = gameObject.name.Split(' ')[1];
        foreach(char c in faces)
        {
            //Debug.Log(c);
            if (FaceType.TryParse(c.ToString().ToUpper(), out FaceType f))
            {
                parents.Add(f);
            }
        }
    }

    void AddFace(FaceType f)
    {
        if (!FaceIsParent(f))
            parents.Add(f);
        UpdateName();
    }

    void DelFace(FaceType f)
    {
        if (FaceIsParent(f))
            parents.Remove(f);
        UpdateName();
    }

    void UpdateName()
    {
        string name = "cube ";
        for (int i = 0; i < sizeof(FaceType); ++i)
        {
            if (FaceIsParent((FaceType)i))
                name += ((FaceType)i).ToString();
        }
        gameObject.name = name;
    }

    public bool FaceIsParent(FaceType f)
    {
        for (int i = 0; i < parents.Count; ++i)
        {
            if (f == parents[i]) return true;
        }
        return false;
    }
}
