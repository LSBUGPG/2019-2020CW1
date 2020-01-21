# Tutorial 2 Snake’s Tail Following

##### Step 1 ##### 

Open the script Snake Controller from the previous tutorial. 

Start by adding the public List for the tail element and a float for the distance between those elements. 
Also, create the public GameObject for the tail element prefabs. 

Add a range of the distance between the tails, which will create a smooth slider. 
In this example, the range is 0-5, but you can add any variable, depending on the size of your object.  

In this code, we will name the tail elements as the “bones”. 

```
public class SnakeController : MonoBehaviour
    {
   public List<Transform> Tails;
   [Range(0, 5)]
   public float BonesDistance;
   public GameObject BonePrefab; 
    private Transform _transform;
    public float Speed;
    [Range (0, 4)]
```

To make tail elements follow the Snake (head), we have to move all the parts to the previous position of the head.

We will have to find the squared Distance of the Snake Movement. 
The easiest way to do that is to compare the distance between the bones. 
We also have to add another line which will save the previous position of each previous tail element. 

Go to method MoveSnake and add the code.
```
private void MoveSnake(Vector3 newPosition)
{ 
        float SqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position; 
```

Now we have to create a code for the tail elements.
Create the foreach cycle for the tail element list in the MoveSnake method.
```
  private void MoveSnake(Vector3 newPosition)
    {
        float SqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach  (var bone in Tails) 
    
```    
We will create a variable distance Vector *(bone.position-previousPosition).sqrMagnitude* and will compare this vector with the SquareDistance, that we created earlier. 

*If the Vector will be bigger than the Square distance – the each tail element position will change by moving to previous position of the tail element in front.*

*If the Vector will be smaller than the Distance (which means that the tail elements didn’t reached the distance as well) – we will pause the loop.* 

```
 foreach (var bone in Tails)
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
```
Save the script and go back to the project.


##### Step 2 Setting up the elements. #####


Choose the player cube and duplicate it. Name it as Bone1.
Select the new duplicated cube and move it next to the player. 
Delete the script and the collider in the Bone’s Inspector Window. 

In the project window create a new folder named “Prefabs”.
Click and drag the Bone to the prefabs folder. This action will automatically make the prefab – the specific reusable asset, complete with all the components and property values. 

Now select again the Bone1 and dublicate it. 
Name it Bone2 and move it next to the Bone1. 
Repeat this action again and create in total 3 tail elements, all placed next to each other. 

  



Now choose the player and lock its inspector window. 

Choose all three tail elements and drag them to the player’s Inspector Window -> Script -> Tails. 
This will create a list of all the tail elements. 

Move the Bones Distance Slider to a middle and click the play button. 
Now the tail elements follow the snake’s head. You can increase or reduce the speed and the distance of the elements during the play until it’s perfect for you.


