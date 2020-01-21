# Tutorial #4   Game Over screen and Counting Score.



##### Step 1. Setting up the Scene

*In this tutorial we are going to work with the text. We will create a Game Over text, that will appear if the snake collides with the walls or with the tail. And we will count the Score for the eaten food.* 

* Create a new Game Object -> UI- > Text.
* Name it “Game Over”
* Select it. 
* In Inspector window click on the Anchor Presets ( Square and Red Plus in the Rect Transform menu). Choose the centre position. 
* Increase the text’s size and change the colour, if required. Using the Play Mode, locate the text in the perfect position for yourself. 
* Delete the Text in the Text Box (New Text). 

Create another Text Object. Name it “Score”. This time select the upper left location for the text. 
Adjust the location, size and colour of the text. 
Delete the Text from the Text Box.


In the project manager find the folder “Prefabs”. 
Double click on the Tail Element prefab. 
Add the new tag for this prefab and name it “tail”.

Now select the walls/borders, which we created in tutorial One. 
Add the new tag for them and name it “wall”.


##### Step 2. Open the Snake Controller Script.


The first thing that we have to do – is to add another UI Engine to the script. This will allow us to work with the UI elements.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
```
Create two public Texts in the Scene Management, name one “lostText” and another “scoreText”.  Also, add the private Integer for the score, which will allow to count the score.  

    public Text ScoreText;
    private int CurrentScore = 0;
    public Text lostText; 
  

To create the Score text, we have to add another command to the Collision script, we created earlier. If the Snake’s head will collide with the food  (element with the tag “food”), the score will increase by 1. 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="food")
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);

            CurrentScore++;
            scoreText.text = "" + CurrentScore;



To create the Game Over text, we have to add another command to the Collision.
If the snake’s head will collide with the wall (element with the tag “wall”) or with the tail elements (“element with the tag “tail”) – the game will be over. 
Add the new collision rule.
```
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
```

Save the script and go back to project. Click on the player and lock it’s inspector windows. 

You can see that in the script component appeared two new empty Game Object. Select the Game Over text and drag it to the Lost Text. Select the score text in the Hierarchy and drag it to Score Text in the Player’s Inspector. 

*THE END!*