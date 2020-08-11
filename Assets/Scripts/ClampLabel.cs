using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClampLabel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameLabel;

    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = transform.position;
    }
}
