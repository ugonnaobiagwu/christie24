# SPRINT 5: 

WHAT WE ACCOMPLISHED:

--Our Sprint 4 Backlog is Complete!
* Collision: Collision works with All Game Objects and Handles the Collision Events (where they're specified to do so for gameplay/performance issues)
* GameStates: Scrolling, Inventory, Pause, Win, Title and Death States are In
* Level Loader: Completely functional. The complete first level is in as well.
* Inventory: Improved and fleshed out HUD that is also dynamic and reacts to Link's Inventory and States.
* Enemies: Improved Enemy Behavior
* GameObjectManager: Improved Game Object Management
* SpriteFactory: Fixed Abnormal Scaling Issues
* Sound: More Sound Effects and Music Are In. Music Now Pauses in the Pause State 

--Sprint 5 Feature is Complete (Almost)
* Elemental Link, Link Sword, and Enemies
* Elemental Type Advantages (Critical Hits, Weak Hits)
* XP Boosts when Link Kills an Enemy or Picks up certain item
* Link Will wear a Specific Tunic based on the Element he chooses to equip.
* Tunics can be equipped from the Inventory as Link unlocks them (indicated by a SFX)
* When Link is at a HIGH Level, enemies will start to gun him down!
  
WHAT WE DID NOT ACCOMPLISH:
* Enemy AI Scaling for Level Medium isn't in. (Enemies dodging bows 40% of the time)
  
Please see the Sprint 5 Reflection / Planning Document for more details.

----

CONTROLS:
* Use W, A, S, D to walk around.
* Press I to open the Inventory and from there, use the ARROW keys to select an item, then equip to an item slot by pressing A or B
* Attack Using Item A with N
* Attack Using Item B with M
* Pause the game with P.
* Reset the game with R

KNOWN BUGS AND ISSUES:
* Fun Fact: Collision Rectangles are slightly off because the images use a float for scaling, but the width and height gets the decimal value truncated. White space in the SpriteSheets don't help either.
* Certain Song files fade out and start again purely because that's how the file was ripped.
* Some animations don't animate / animate quickly / have row/sheet problems
* Link won't start wearing his new tunic until he starts walking in a different direction after he equips it
* Collision / Level Loader: Potential for there being a gap between some walls and some doors. (Mostly fixed)
* Enemies Exploit the abovee Gaps and can get to other rooms that way (Design Feature LOL?)
* Certain Enemies freak out with Collision and can be thrown out of certain rooms (Aquamentus the Dragon)
* State Change during scroll affects the draw and freezes the scroll.
* Door Collision is magnetic-like and can lead to Scroll Errors in Certain Rooms (Mostly fixed)
* Collision with Certain Blocks Are Weird and Can Soft Lock Link
* Backtracking is a little funky.
* Big Heart in Boss Room has a bug with the HUD and Link's Health
* Text in NPC/Old Man Room is not present.
* Certain Door State Changes Do not occur (Room with Pushable Block / Enemy Death Room)

Please see the reflection / issue tab for more details as this list is not exhaustive.



Please visit the issues for additional bugs that may not have been addressed here. This, by no means, is an exhaustive list.
