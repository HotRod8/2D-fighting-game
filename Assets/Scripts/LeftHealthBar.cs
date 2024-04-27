using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LeftHealthBar : MonoBehaviour
{
    private Transform bar;
    public const int MaxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("LeftBarOverlay");
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized/100, 1f);
    }

    public float GetSize() { return bar.localScale.magnitude; }
}
