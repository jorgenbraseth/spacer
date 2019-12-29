using System;
using ShipComponents;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class EnergyUI : MonoBehaviour
{
    [SerializeField]
    private Spaceship ship;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Energy: " + Math.Round(ship.storedPower);
    }
}
