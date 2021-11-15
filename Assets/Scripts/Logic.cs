using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//up down right left front back
public enum FaceType { U, D, R, L, F, B };

public class Face 
{
    private FaceType type;
    public FaceType GetFaceType
    {
        get { return type; }
    }

    List<Block> children;
    public List<Block> GetBlocks
    {
        get { return children; }
    }

    public Face(FaceType t)
    {
        type = t;
        children = new List<Block>();
    }    

    public void AddBlock(Block b)
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //parts.Find(x => x.PartName.Contains("seat")));
        if (!children.Find(x => x == b))
            children.Add(b);
    }

    public void DelBlock(Block b)
    {
        if (children.Find(x => x == b))
            children.Remove(b);
    }
}
