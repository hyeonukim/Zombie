# Photon Multiplayer Game Codebase

This repository contains the codebase for a multiplayer game using Photon Unity Networking (PUN). The game features various classes for items, guns, a game manager, and more. Below is an overview of key classes and their functionalities.

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

## AmmoPack

Supplies ammo to the player when used. Destroys itself after providing ammo.

## CameraSetup

Sets up the Cinemachine camera to follow the local player.

## Coin

Increases the player's score when used. Destroys itself after updating the score.

## ColorSerialization

Serializes and deserializes Color objects for network communication.

## GameManager

Manages the overall game state, player instantiation, scoring, and game over conditions.

## Gun

Represents a gun, handles firing, reloading, and network synchronization.

## GunData

Scriptable object containing data for a specific gun, including audio clips, damage, ammo capacity, etc.

## HealthPack

Restores health to the player when used. Destroys itself after healing.

## IDamageable Interface

Interface for objects that can take damage.

## IItem Interface

Interface for every item object. Defines the Use method.

## ItemSpawner

Spawns items randomly near players at regular intervals.

## LivingEntity

Represents 'alive' game objects with health, damage, and death functionality.

## LobbyManager

Handles player connection, room creation, and joining in the lobby screen.


### PlayerHealth

Handles health and damage logic for the player character.

## PlayerInput

Manages player input, including movement, rotation, shooting, and reloading.

## PlayerMovement

Controls the player's movement based on input.

## PlayerShooter

Handles shooting mechanics and updates the UI accordingly.

## Rotator

A simple script to rotate an object.

## UIManager

Manages the game UI, displaying ammo, score, and wave information.

## Zombie

Represents the behavior of the zombie character, including AI, attacking, and dying.

## ZombieData

A ScriptableObject containing data for different types of zombies.

## ZombieSpawner

Handles the spawning of zombies based on waves.
