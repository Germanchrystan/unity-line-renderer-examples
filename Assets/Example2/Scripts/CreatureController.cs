using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    private Vector2 goal;
    [SerializeField] private Sprite normalSprite, hitSprite;
    [SerializeField] private float moveSpeed, speedWhenHit;
    [SerializeField] private float speed;
    [SerializeField] private float moveRange;
    private SpriteRenderer spriteRenderer;
    private bool isGettingShocked = false;


    private void Awake()
    {
        moveSpeed = speed;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goal, moveSpeed * Time.deltaTime);
        if((Vector2)transform.position == goal)
        {
            goal = ChooseNewGoal();
        }
        if(isGettingShocked)
        {

        }
    }

    private Vector2 ChooseNewGoal()
    {
        Vector2 newGoal = Random.insideUnitCircle * moveRange;
        return newGoal;
    }
    
    public void StartElectricShock()
    {
        spriteRenderer.sprite = hitSprite;
        moveSpeed = speedWhenHit;
        isGettingShocked = true;
    }

    public void StopElectricShock()
    {
        spriteRenderer.sprite = normalSprite;
        moveSpeed = speed;
        isGettingShocked = true;
    }
}
