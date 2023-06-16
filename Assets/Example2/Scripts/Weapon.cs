using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private List<Creature> allCreatures;
    private List <LineController> allLines;

    private bool weaponIsOn;

    private void Awake()
    {
        allLines = new List<LineController>();
        for(int i = 0; i < allCreatures.Count; i++)
        {
            LineController newLine = Instantiate(linePrefab);
            allLines.Add(newLine);

            newLine.AssignTarget(transform.position, allCreatures[i]);
            newLine.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        ToggleWeapon();
    }

    private void ToggleWeapon()
    {
        if(weaponIsOn)
        {
            foreach( var line in allLines)
            {
                line.gameObject.SetActive(false);
            }
            foreach(var creature in allCreatures)
            {
                creature.StopElectricShock();
            }
            weaponIsOne = false;
        }
        else 
        {
            foreach( var line in allLines)
            {
                line.gameObject.SetActive(true);
            }
            foreach(var creature in allCreatures)
            {
                creature.StartElectricShock();
            }
            weaponIsOne = true;
        }

    }
}
