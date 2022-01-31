using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpawnPos;
    public Transform playerParent;

    private Vector2 swipeDelta, startTouch;
    private Vector3 difference;
    private Touch touch;

    public float moveSpeed;
    public int playerSpawnerHealth;

    private bool tap = false;

    void Update()
    {
        TouchControll();
        Move();
    }

    private void Move()
    {
        float xPos = Mathf.Clamp(transform.position.x + difference.x * moveSpeed * Time.deltaTime, -6, 6);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }


    private void TouchControll()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = touch.position;
                StartCoroutine(SpawnPlayer());

            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                swipeDelta = touch.position;
                difference = (swipeDelta - startTouch) / Screen.width;

            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                tap = false;
            }
        }
    }

    IEnumerator SpawnPlayer()
    {
        while (tap == true)
        {
            Instantiate(player, playerSpawnPos.transform.position, Quaternion.identity, playerParent);
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
}
