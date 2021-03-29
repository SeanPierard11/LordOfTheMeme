using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Mouv : MonoBehaviour
{
    public float MoveSpeed;
    public LayerMask SolidObjectLayer;
    public LayerMask InteractableLayer;
    private bool IsMoving;
    private Vector2 input;

   
    void Update()
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
                


                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                }
            }
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

       
    }

    private bool IsWalkable(Vector3 targetpos)
    {
        if (Physics2D.OverlapCircle(targetpos, 0.2f, SolidObjectLayer | InteractableLayer) != null)
        {
            return false;
        }
        return true;
    }
}
