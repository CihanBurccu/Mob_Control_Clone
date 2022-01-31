using System.Collections;
using UnityEngine;

public class MultiplierMovement : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float movementTime;

    private void Start()
    {
        StartCoroutine(MoveMultiplier(pos1.position,pos2.position));
    }

    IEnumerator MoveMultiplier(Vector3 targetPos, Vector3 startPos)
    {
        float time = 0;
        transform.position = startPos;

        while (time < movementTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time/movementTime);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pos1"))
        {
            StopAllCoroutines();
            StartCoroutine(MoveMultiplier(pos2.position,pos1.position));
        }
        else if (other.gameObject.CompareTag("Pos2"))
        {
            StopAllCoroutines();
            StartCoroutine(MoveMultiplier(pos1.position,pos2.position));
        }
    }
}
