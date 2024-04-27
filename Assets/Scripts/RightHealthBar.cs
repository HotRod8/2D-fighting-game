using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RightHealthBar : MonoBehaviour
{
    private Transform bar;
    public const int MaxHealth = 100;

    // Start is called before the first frame update
    private void Awake()
    {
        bar = transform.Find("RightBarOverlay");
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized/100, 1f);
    }

    public float GetSize()
    {
        return bar.localScale.magnitude;
    }
}
