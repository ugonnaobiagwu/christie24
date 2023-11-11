
# SPRINT 4: 

WHAT WE ACCOMPLISHED:
* Enemies: Enemies and Boss (Aquamentus) is in and near completion
* Collision Code is tested and working (though keep reading for Bugs and Issues)
* Sound Systems: Music and Sound Effects
* Link: Can walk around and shoot all his items out. (though keep reading for Bugs and Issues)
* Level Loader /  XML Parsing: Can be used to place items in the game
* GameObjectManager: Object Management is working and can speak to Level Loader and Collsion Systems. (though keep reading for Bugs and Issues)
* Game States foundation has been built.
* HUD: Can be displayed and updated hard-coded-ly through Game 1... (see controls below) 
* Inventory: Data file that keeps track of what Link's got.
* Room Scrolling: We have camera movement that will act as a PoC for Room Scrolling in the next sprint
* SpriteFactory: Completed factory that all GameObjects now respond to
* IGameObject: Shiny new interface that all GameObjects speak to which allows Collision, Level loading and Game Object Management to work.
* Utilization of Test Plan: Blocks, Collision and Level Loading were tested "off-repo" and the changes were brought back to our main one with "Cache Coherency" issues being the utmost concern.
* Camera: Follows Link and Moves Up Down Left and Right, so the foundation for  the camera code is in.
  
WHAT WE DID NOT ACCOMPLISH:
* Collision needs to be expanded to include events sent to the Inventory System / Link Picking Up items.
* LinkItems (Weapons) need further Collision testing, as well as integrating with inventory and the HUD.
* Different Game State screens: Pause Screen etc
* Completed Room Scrolling.
* Complete first level.
* HUD: Locator doesn't currently have logic behind it, but the design is done.
* ScrollState: Scroll Transition code is in, but the integration is not in with Scroll State / Door Collisions
* Other tasks not mentioned from our Sprint 4 planning doc.
  
Please see the Sprint 4 Reflection / Planning Document for more details.

----

CONTROLS:

* Move with W, A, S, D
* Shoot Items by pressing numbers 1-7 and the letter N.
* Change HUD display via adding / removing Count/Gain/Lose methods at the top of Game1. Doing this shows that you can change the number of hearts, inventory items, and more.
* Collision sort of works on the top right "pyramid block" at the moment. (Also a known bug)



KNOWN BUGS AND ISSUES:
* Link and Item Animations: Really wonky right now. Item Sprite switches don't work, and Link's "UseItem" pose remains once the item is no longer in play.
* Item Locations: Bows and Swords come from special directions and are oriented to meet that criteria, but their rotations are out of wack currently.
* Wonky Enemy and Enemy Projectile sprite issues.
* SpriteFactory is causing really weird scaling issues at the moment with the room and blocks, links and items, which is affecting the working Collision rectangles.
* Level Loader places things in the game, but further fixes are ahead of us due to the ^^ issue.
* Link can walk on the HUD
* Inventory quantities / life quantity is in an island right now... the only thing talking to that system is the HUD currently.
* Link Map Locator is static.
* 


Please visit the issues for additional bugs that may not have been addressed here. This, by no means, is an exhaustive list.
