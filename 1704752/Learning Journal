15/10/2019
- I encountered a problem in fully understanding the "FixedUpdate" function. I hadn't ever encountered this previously. 
If “update” runs once per frame, and then that frame is rendered, FixedUpdate runs as many times as needed to catch the physics 
simulation up. A degree of confusion was also had at "Time.fixedDeltaTime", however this simply describes the interval in seconds at
which physics and other fixed frame rate updates. I put this line in the FixedUpdate function isntead of the void Update function as
this tutorial scene is using some physics based related functions; such as the enemy shooting in sight, and the following and retreating.



5/11/2019
- I initially encountered problems with the enemy AI's projectile not chasing the player, and could not understand why. 
Eventually, I realised it required the simplest fix, and I’d forgotten to change the player’s tag to “Player”. 
This is a simple, yet common mistake and one that I am thankful to have encountered, simply because I will now remember to 
always check tags.


12/11/2019
- I initially wanted the player to be able to fire projectiles at the enemy, but decided aginst this as it made for confusing gameplay.
Instead I stuck with the mechanic of the enemy firing at the player, and implemented a scoring system for the player to get.
I achieved a better scoring system by streamlining the script. 

The ScoringSystems script takes care of the UI side, updating the score, whilst the CollectItem script handles the collision of picking up the items.
ir references the ScoringSystem script and tells it to +50 on to the score each time a collision is detected. 

Before this, the ScoringSystem script also handled destroying the gameObject, whereas now this function si handled by the CollectItem script.


