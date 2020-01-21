##4: Scoring

We'll want the player to be able to collect pickups in the game, and achieve a score for doing so.
Firstly, go to your scene in Unity and add a 2D sprite of any shape, size, and colour you like. I'm going with a hexagon. This will be our collectible. Add 4 to the scene for now. Make sure to add a 2D box collider, and tick all of their trigger boxes!

To make a score appear, we'll need to add some UI. Do this by clicking Create in the inspector, scrolling down to UI and selecting "text". Rename it to "scoreText" and in the text box, write "Score: 0"
In the box above Anchors in the Inspector, hold shift and alt and select where on the screen you want the text to show. I'm selecting the top left corner. After this, we can make our text a bit bigger. Increase the font size, and the size of the text box itself in order to see it better. I've increased mine to 50.

Now we're going to add a script in order to handle the scoring of the hexagons. Create a script and call it "scoringSystem".

Inside the script, we need to add a line of code that enables us to use UI elements. in the "using" section, simply add "using UnityEngine.UI;" and that's all sorted.

Get rid of the start function, and add a public GameObject called scoreText.
underneath that, make a public integer called theScore. Phrase it as such: "public static int theScore;"

Inside the Update function, we will include how much one hexagon is worth. Here's how it should look:

 void Update()
    {
        theScore += 50;
        scoreText.GetComponent<scoreText>().text = "SCORE: " + theScore;

    }




The top line shows that each hexagon will be worth 50 of itself.
The line below simply states that when we get the component that has a score, the game will display "SCORE: " with a number after the colon, and will continue to add the score after the fact.

This script will be combined with another that we'll write after this, so just bear that in mind!
Let's make that script now.
Create a script and call it "CollectItem"

In this script, delete the start and update function, and simply add an "void OnTriggerEnter2D" followed by a reference to our ScoringSystem script. It should look like this:

void OnTriggerEnter2D(Collider other)
    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
}

This script tells Unity that each time the player gets a score, it's worth 50. It also tells Unity to destroy the object once it's been collected. Save this, and go back to Unity.

In Unity, create an empty game object and rename this as the game events handler. We'll attach the scoringSystem script to this object. Next, attach the collectItem script to the all the hexagons in your scene.

the script should look like this:

void OnTriggerEnter2D(Collider2D other)
    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
    
}

This basically tells Unity that whenever the player hits the trigger box of the hexagon, our "ScoringSystem" script is referenced; which gives the player +50. It also destroys the hexagon.

Back in Unity, make sure that the "ScoringSystem" script is added to the game events handler, and the collect Item scripts are added to every hexagon you place. Hit play and test it!

That's how we add scoring to the game!
