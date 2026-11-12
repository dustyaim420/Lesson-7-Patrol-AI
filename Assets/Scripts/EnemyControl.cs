using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemy;
    public float moveSpeed = 5f;
    public Transform[] pathfinding; //array taht contains the point objects

    private int _waypointIndex = 0;
    private bool _isReversing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //turn the enemy towards the target wayopoint and move it forward
        enemy.transform.LookAt(pathfinding[_waypointIndex]);
        enemy.transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);


        float dist = Vector3.Distance(enemy.transform.position, pathfinding[_waypointIndex].position);

        if (dist < 0.2f)
        {
            //move on if it isnt the last waypoint

            if (_isReversing == true)
            {
                _waypointIndex--;
                if(_waypointIndex <= 0)
                {
                    _waypointIndex = 0;
                    _isReversing = false;
                }
            }
            else
            {
                _waypointIndex++;
                if(_waypointIndex >= pathfinding.Length - 1)
                {
                    _waypointIndex = pathfinding.Length - 1; // this is to ensure it doesnt overshot since it sets the index to the current positiion of the pathfinding length
                    _isReversing=true;
                }
            }
        }
    }
}
