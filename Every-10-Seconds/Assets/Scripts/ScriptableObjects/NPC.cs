using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPC : ScriptableObject
{
    [SerializeField]
    private float _value;

    [SerializeField]
    private Sprite _image;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Sprite Image
    {
        get { return _image; }
        set { _image = value; }
    }
}
