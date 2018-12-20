using System.Runtime.InteropServices;
using UnityEngine;

public class TestLibrary : MonoBehaviour
{
    [DllImport("MyUnityLibrary")]
    public static extern string MyString();

    void Start()
    {
        Debug.Log(MyUnityLibrary.MyString());
    }
}
