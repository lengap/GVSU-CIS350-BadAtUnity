# Bad At Unity SRS
### Members: Patrick Lenga, Hunter Chopp, Matthew Squire

# Overview
This document provides a layout of our specific features for our game. Providing a subsection of each feature containing the functional and non-functional requirements.

# Software Requirements
This section provides a list of functional and non-functional requirements included within the game. The functional requirements provide what each requirement does to its specific category. The non-functional requirements provide
how the game runs and performs a specific action.

# Functional Requirements

### Player
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| FR1 | The player shall fire her weapon when the spacebar key is pressed and their ammo will decrease by 1.| TC10,11 |
| FR2 | The player shall take damage when hit with a projectile.| TC5,15 |
| FR3 | The player shall move when the W,A,S,D keys are pressed. (W for up, A for left, S for down, D for right). | TC1,2,3,4 |
| FR4 | The player shall retain health when changing scenes. | TBD |
| FR5 | A shooting sound shall play when the player fires her weapon. | TBD |

### Level Generation
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| FR6 | Upon hitting the play button a random level will be generated.| TBD |
| FR7 | Enemy spawners shall be created when the level is loaded.| TC12 |
| FR8 | Powerups shall be created when the level is loaded. | TC13 |
| FR9 | Items shall be created when the level is loaded. | TBD |
| FR10 | Ladders shall be created when the level is loaded. | TBD |

### Items
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| FR11 | The player shall pickup an item when walking over them. | TBD |
| FR12 | The player's health shall increase when picking up a healthkit item | TC9 |
| FR13 | The player's ammo shall increase when picking up a battery item. | TC8 |
| FR14 | The player's damage shall increase when picking up a damage powerup. | TC6 |
| FR15 | The player shall have a shield when picking up the shield powerup. | TC7 |

# Non-Functional Requirements

### Functionality
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| NFR1 | The game shall perform well when more than 20 enemies are on the screen at a time. | TC11 |
| NFR2 | The game shall load each level in a reasonable time. | TC18 |
| NFR3 | The game shall be stable as to avoid crashes. | TBD |
| NFR4 | The game shall have a clear and easy to understand UI. | TC20 |
| NFR5 | The game will have simple objectives while remaining challenging. | TBD |

### Level Generation
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| NFR6 | The game shall seamlessly load the level. | TBD |
| NFR7 | The game shall randomly place decorations around the level | TC17 |
| NFR8 | The game shall not let players outside the visual boundaries of the play area | TBD |
| NFR9 | The game shall generate spawners based on if the position in the level is a room. | TBD |
| NFR10 | The game shall not generate any items outside the visual boundries. | TC19 |

### Enemy
| ID | Requirement     | Test Cases |
| :-------------:| :----------: | :----------: |
| NFR11 | The game shall have multiple kinds of enemies with varying weapons. | TBD |
| NFR12 | The game shall have a boss enemy with large amounts of damage. | TBD |
| NFR13 | The game shall seamlessly move the enemies. | TBD |
| NFR14 | The game shall move enemies based on the players position. | TBD |
| NFR15 | The game shall spawn enemies after a set amount of time (10 seconds). | TBD |

# Test Specification
This section provides test cases for the game. This section contains unit tests, integration tests, and system tests.

## Unit Tests

| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC1 | Hitting the W key increases players y position | Hit W key | N/A | Y position increases | Y position increased | Pass | FR3 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC2 | Hitting the S key decreases players y position | Hit S key | N/A | Y position decreases | Y position decreased | Pass | FR3 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC3 | Hitting the D key increases players x position | Hit D key | N/A | X position increases | X position increased | Pass | FR3 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC4 | Hitting the A key decreases players x position | Hit A key | N/A | X position decreases | X position decreased | Pass | FR3 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC5 | When hit with a projectile the players health decreases. | Get hit with projectile | N/A | Player health decreases | Player's health decreased | Pass | FR2 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC6 | When picking up a damage powerup the players damage increases | Pick up damage powerup (Pink) | N/A | Damage variable increases | Damage Increases | Fail | FR14 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC7 | When picking up a shield powerup the player health will not decrease | Pick up shield powerup (Blue) | N/A | Health variable does not change | Health remained the same | Fail | FR15 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC8 | When picking up a battery the player's ammo will increase | Pick up battery | N/A | ammo variable increases | battery variable increased | Pass | FR13 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC9 | When picking up a health kit the player health will increase | Pick up health kit | N/A | Health variable increases | Health variable increased | Pass | FR12 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC10 | When pressing spacebar the player's ammo will drain | User presses spacebar | User presses Spacebar | Player's ammo will decrease by 1 | Player's ammo decreases | Pass | FR1 |

## Integration Tests
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC11 | When pressing spacebar the player will spawn a bullet | User presses spacebar | User presses Spacebar | Bullet will spawn | Bullet spawned | Pass | FR1 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC12 | Enemy Spawners will be placed in the map on load | User plays the game and locates enemy spawners | N/A | Spawners will be placed on the map | Spawners are on map | Pass | FR7 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC13 | Powerups will be placed inside the map on load | User plays the game and locates powerups | N/A | Powerups will be visible on the map | Powerups on map | Pass | FR8 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC14 | When pressing spacebar the battery UI image will drain | User presses spacebar | User presses Spacebar | Battery UI Shrinks | Battery UI Shrank | Pass | FR1 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC15 | When the player takes damage the health bar drains | Game is running, enemies on screen, and player takes damage | N/A | Health bar will drain when taking damage. | Player's Health bar drains | Pass | FR2 |

## System Tests
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC16 | Multiple Enemies on screen | Wait for enemies to spawn inside game | N/A | Game will run smoothly with multiple enemies on screen. | Game runs smoothly | Pass | NFR1 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC17 | Game will randomly place decorations around the map | Load the game and check if decorations spawn | N/A | Decorations (Painting, Items, Spawners, etc.) will appear on the map | Decorations are on the map | Pass | NFR7 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC18 | Game will load levels,items, player, etc. in a reasonable amount of time | Play the game and go between levels | N/A | Game will load levels quickly | Levels are loaded quickly | Pass | NFR2 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC19 | No elements within the game will spawn outside the game bounds | Check around game bounds for items outside the map. | N/A | No elements will spawn outside the map | No elements spawn outside the map | Pass | NFR10 |
| ID  | Description | Steps | Input Values | Expected Output | Actual Output | Pass/Fail | Requirement Link |
| :-------------: | :----------: | :----------: | :----------: | :----------: |:----------: | :----------: | :----------: |
| TC20 | UI is present within the game, and changes when appropriate. | Play the game, if the user loses show gameover screen or if the user wins show winner screen | N/A | UI will appear and change | UI Appears and changes | Pass | NFR4 |

# Software Artifacts
The purpose of this section is to provide an easy way to locate the artifacts associated with our game. Artifacts include Use Case Diagrams, Use Case Description.

* [PlayerMovementUseCase.pdf](https://github.com/lengap/GVSU-CIS350-BadAtUnity/blob/master/artifacts/use_case_diagrams/PlayerMovement.pdf)

* [PlayerShootingUseCase.pdf](https://github.com/lengap/GVSU-CIS350-BadAtUnity/blob/master/artifacts/use_case_diagrams/PlayerShootingUseCase.pdf)

* [SpawnEnemyUseCase.pdf](https://github.com/lengap/GVSU-CIS350-BadAtUnity/blob/master/artifacts/use_case_diagrams/SpawnEnemyUseCase.pdf)

* [Shooting Use Case Desc](https://github.com/lengap/GVSU-CIS350-BadAtUnity/blob/master/artifacts/use_case_diagrams/shootingDescription.md)


