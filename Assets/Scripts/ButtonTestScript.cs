using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTestScript : MonoBehaviour
{
    public void ButtonWorks()
    {
        Debug.Log($"This button ({gameObject.name}) works.");
    }
}
