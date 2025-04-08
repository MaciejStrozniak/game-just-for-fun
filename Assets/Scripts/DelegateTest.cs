using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{

    public delegate void TestDelegateFunction();

    private TestDelegateFunction testDelegateFunction;

    // Start is called before the first frame update
    void Start()
    {
        testDelegateFunction = TestingDelegate;
        testDelegateFunction += TestingSecondDelegate;
        testDelegateFunction();
    }

    private void TestingDelegate() {
        Debug.Log("Pierwszy delegata");
    }

    private void TestingSecondDelegate() {
        Debug.Log("Drugi delegata");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
