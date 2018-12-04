/*
 * Chapter 7.6 Base Classes: Another Look
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
/*
 * Section 7.6.1 Generalization -- Base Classes
 */
public abstract class BaseClass
{
    #region BaseProperties
    private float mSpeed;
    protected float Speed
    {
        get{return mSpeed;}
        set{mSpeed = value;}
    }
    private float mTurn;
    protected float Turn
    {
        get{return mTurn;}
        set{mTurn = value;}
    }
    private Vector3 mPosition;
    protected Vector3 Position
    {
        get{return mPosition;}
        set{mPosition = value;}
    }
    private MeshFilter mMeshFilter;
    protected MeshFilter MeshFilter
    {
        get{return mMeshFilter;}
        set{mMeshFilter = value;}
    }
    private Material mMaterial;
    protected Material Material
    {
        get{return mMaterial;}
        set{mMaterial = value;}
    }
    #endregion
    #region BaseFunctions
    public abstract void Initialize(MeshFilter mesh, Material material);
    public abstract void MoveForward(float speed, float turn);
    public abstract void UpdateChild();
    public virtual void Speak()
    {
        Debug.Log("Base Hello.");
    }
    #endregion
}

public class ChildA : BaseClass
{
    #region ChildA_Properties
    protected GameObject Me;
    protected Mesh m_Mesh;
    protected MeshRenderer m_MeshRenderer;

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    #endregion

    public override void Initialize(MeshFilter meshFilter, Material material)
    {
        MeshFilter = meshFilter;
        Material = material;
        Me = new GameObject(this.ToString());

    }

    public override void MoveForward(float speed, float turn)
    {
        throw new System.NotImplementedException();
    }

    public override void Speak()
    {
        base.Speak();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override void UpdateChild()
    {
        throw new System.NotImplementedException();
    }
}

public class BaseClassesAnotherLook : MonoBehaviour
{

}
