using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : BaseGimmickBehaviour
{
    public bool isOpen;
    public Sprite DoorOpened;
    public Sprite DoorClosed;
    public string transitionStageKey;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isOpen) TurnOn(true);
    }

    public override void Toggle()
    {
    }

    protected override void EndOperation()
    {
        isOpen = false;
        spriteRenderer.sprite = DoorClosed;
    }

    protected override void StartOperation()
    {
        isOpen = true;
        spriteRenderer.sprite = DoorOpened;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (isOpen)
            {
                StageController.Instance.isTimeStop = true;
                GameManager.Instance.LoadPuzzleScene(transitionStageKey);
            }
        }
    }
}
