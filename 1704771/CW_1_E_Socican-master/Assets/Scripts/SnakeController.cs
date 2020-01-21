using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
   public List<Transform> Tails;
    [Range(0, 6)]
    public float BonesDistance;
   public GameObject BonePrefab;

     [Range(0, 4)]
    public float Speed;

    public Text scoreText;
    private int CurrentScore = 0;
    public Text lostText;


    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);
        float angle = Input.GetAxis("Horizontal") * 4;
        transform.Rotate(0, angle, 0);
    }


    private void MoveSnake(Vector3 newPosition)
    {
        float SqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach  (var bone in Tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > SqrDistance)
            {
                var temp = bone.position;
                bone.position = previousPosition;
                previousPosition = temp;

            }
            else
            {
                break;
            }
        }

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="food")
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);
            CurrentScore++;
            scoreText.text = "" + CurrentScore;

        }

        if (collision.gameObject.tag == "wall")
        {
            lostText.text = "GAME OVER!";
        }

        if (collision.gameObject.tag == "tail")
        {
            lostText.text = "GAME OVER!";
        }
    }
}
