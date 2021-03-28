using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    public LayerMask SolidObjectLayer;
    public LayerMask InteractableLayer;
    public LayerMask LongGrassLayer;

    private bool IsMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                }
            }
        }
        animator.SetBool("IsMoving", IsMoving);

        if (Input.GetKeyDown(KeyCode.X))
            Interact();
    }

    void Interact() 
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, InteractableLayer);
        if (collider != null) 
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetpos)
    {
        IsMoving = true;

        while ((targetpos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, MoveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;
        IsMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetpos)
    {
        if(Physics2D.OverlapCircle(targetpos, 0.3f, SolidObjectLayer | InteractableLayer ) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, LongGrassLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("encountered a wild meme");
            }
        }
    }
}
