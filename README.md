# Photon Multiplayer Game Codebase

This repository contains the codebase for a multiplayer game using Photon Unity Networking (PUN). The game features various classes for items, guns, a game manager, and more. Below is an overview of key classes and their functionalities.

## Image of gameplay
![image](https://github.com/hyeonukim/Zombie/assets/48634064/76529838-f22c-4328-8567-34ef1dd7581c)

## Table of Contents

- [AmmoPack](#ammopack)
- [CameraSetup](#camerasetup)
- [Coin](#coin)
- [ColorSerialization](#colorserialization)
- [GameManager](#gamemanager)
- [Gun](#gun)
- [GunData](#gundata)
- [HealthPack](#healthpack)
- [IDamageable Interface](#idamageable-interface)
- [IItem Interface](#iitem-interface)
- [ItemSpawner](#itemspawner)
- [LivingEntity](#livingentity)
- [LobbyManager](#lobbymanager)
- [PlayerHealth](#playerhealth)
- [PlayerInput](#playerinput)
- [PlayerMovement](#playermovement)
- [PlayerShooter](#playershooter)
- [Rotator](#rotator)
- [UIManager](#uimanager)
- [Zombie](#zombie)
- [ZombieData](#zombiemanager)
- [ZombieSpawner](#zombiespawner)

### AmmoPack
- **Description**: Item class that supplies ammo.
- **Usage**: Increases the ammo count of the player's gun.
- **Implementation**: Uses Photon for networking, targets PlayerShooter's gun, and destroys itself after usage.

### CameraSetup
- **Description**: For Cinemachine camera to follow the local player.
- **Usage**: Ensures the camera follows the local player in a multiplayer setting.
- **Implementation**: Checks if the view is owned by the local player and adjusts the CinemachineVirtualCamera accordingly.

### Coin
- **Description**: Item class that increases the score.
- **Usage**: Adds score points to the GameManager.
- **Implementation**: Uses Photon for networking, updates the GameManager's score, and destroys itself after adding the score.

### ColorSerialization
- **Description**: Handles color serialization for networking.
- **Usage**: Serializes and deserializes Color objects for network synchronization.
- **Implementation**: Utilizes Photon for custom color serialization and deserialization.

### GameManager
- **Description**: Manages the game state, player spawning, scoring, and network synchronization.
- **Usage**: Controls the game flow, tracks score, and handles gameover conditions.
- **Implementation**: Implements PhotonCallbacks for network events, spawns players, updates score, and transitions between scenes.
- **Additional Information**: Implements a singleton pattern to ensure only one GameManager exists. It also handles player disconnection and returns them to the lobby scene.

### Gun
- **Description**: Represents the player's gun with shooting, reloading, and ammo mechanics.
- **Usage**: Fires bullets, reloads, and syncs gun state over the network.
- **Implementation**: Uses Photon for networking, handles shooting effects, and incorporates a reload system.
- **Additional Information**: Uses raycasting for accurate shooting and visual effects. Supports reloading and displays muzzle flash and shell ejection effects.

### GunData
- **Description**: ScriptableObject containing data for the Gun class.
- **Usage**: Defines audio clips, damage, ammo capacity, and other parameters for the gun.
- **Implementation**: Allows easy customization of gun properties in the Unity editor.

### HealthPack
- **Description**: Item class that restores player health.
- **Usage**: Restores health to the LivingEntity component of the player.
- **Implementation**: Uses Photon for networking, targets LivingEntity for health restoration, and destroys itself after usage.

### IDamageable
- **Description**: Interface for damageable objects.
- **Usage**: Implemented by objects that can receive damage.
- **Implementation**: Defines a method for taking damage.

### IItem
- **Description**: Interface for every item object.
- **Usage**: Implemented by items to define their usage behavior.
- **Implementation**: Defines a method for item usage.

## ItemSpawner
- **Description**: Spawns items randomly near players.
- **Usage**: Generates items at random positions for players to collect.
- **Implementation**: Uses Photon for networking and spawns items with random intervals.
- **Additional Information**: Utilizes NavMesh to ensure items spawn on walkable surfaces. Items are destroyed after a specified duration.

## LivingEntity
- **Description**: Represents 'alive' game objects with health and damage mechanics.
- **Usage**: Handles health, damage, and death events.
- **Implementation**: Uses Photon for networking, synchronizes health over the network, and triggers death events.
- **Additional Information**: Implements health restoration and death events. The ApplyUpdatedHealth RPC ensures health updates across the network.

## LobbyManager
- **Description**: Manages player connection to the game lobby.
- **Usage**: Connects players to the master server and creates/joins rooms.
- **Implementation**: Implements PhotonCallbacks for connection events and room joining/creation.
- **Additional Information**: Handles room creation and joining, and transitions players to the main game scene upon successful room entry.

## PlayerHealth
- **Description**: Manages the health and interactions of the player character.
- **Usage**: Controls player health, damage, and respawning.
- **Implementation**: Uses Photon for networking, synchronizes health across the network, and handles player death and respawn.

## PlayerInput
- **Description**: Captures player input for movement, rotation, firing, and reloading.
- **Usage**: Retrieves and updates player input, used to control player movement and actions.
- **Implementation**: Utilizes Photon for networking, ensures input is only captured on the local player.

## PlayerMovement
- **Description**: Handles player movement based on input.
- **Usage**: Translates player input into movement and rotation.
- **Implementation**: Uses Photon for networking, synchronizes movement across the network.

## PlayerShooter
- **Description**: Manages the player's shooting mechanics and UI updates.
- **Usage**: Controls firing, reloading, and UI updates.
- **Implementation**: Uses Photon for networking, synchronizes shooting actions and UI updates.

## Rotator
- **Description**: Rotates an object over time.
- **Usage**: Provides a simple rotation effect.
- **Implementation**: Updates the object's rotation in the Update method.

## UIManager
- **Description**: Manages the game's UI elements.
- **Usage**: Updates UI elements such as ammo count, score, and wave information.
- **Implementation**: Implements a singleton pattern to access UI elements, handles UI updates.

## Zombie
- **Description**: Represents the enemy zombie character.
- **Usage**: Controls zombie AI, movement, and interactions.
- **Implementation**: Uses Photon for networking, synchronizes zombie AI across the network.

## ZombieData
- **Description**: Holds data for zombie characteristics.
- **Usage**: Defines health, damage, speed, and skin color for zombie creation.
- **Implementation**: Utilizes ScriptableObject to create reusable zombie data.

## ZombieSpawner
- **Description**: Manages the spawning and synchronization of zombies.
- **Usage**: Spawns waves of zombies, handles synchronization across the network.
- **Implementation**: Uses Photon for networking, synchronizes wave information, and spawns zombies based on predefined data.
