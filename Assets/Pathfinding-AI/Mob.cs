using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    Vector2 moveDirection;
    public Vector2Int goalLocation;
    float moveSpeed = 0.07f;
    float randomnessMove = 0.6f;

    public void UpdateMoveDirection(Vector2Int newDir)
    {
        // Called when Mob comes into contact with centerpoint of new cell
        // AND every path update
        moveDirection = newDir;
        var currentPos = new Vector2Int((int)transform.position.x, (int)transform.position.z);
        goalLocation = currentPos + newDir;
    }
    public void AddRandomnessToMovement()
    {
        var randomDirection = new Vector2(
            Random.Range(-randomnessMove, randomnessMove)
            , Random.Range(-randomnessMove, randomnessMove));
        moveDirection += randomDirection;
    }
    void Update()
    {
        transform.position += new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }




    private void Start()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        StartCoroutine(DelayedCapsuleEnable());
    }
    IEnumerator DelayedCapsuleEnable()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
