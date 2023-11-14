# OilRigDoorsFix

Oxide plugin for Rust. Fix for glitch when doors on Oil Rigs are always open.

This plugin is designed to address the issue where the doors in the Oil Rig remain open. No configuration is required; simply install the plugin, and you're good to go.

## How to reproduce the glitch

1. Head to the Oilrig and use a card to open the door (either blue, red, or both). Now execute the command `debug.puzzlereset` and check if the door closes (it should).

2. Open the doors with cards, then **restart the server while the doors are still open**. After the server has loaded, return to the doors you left open and verify if they are still open. If they are, try running `debug.puzzlereset` (or wait until a locked hackable crate spawns). In all tested environments, these doors will remain open until the next wipe, regardless of server restart, puzzlereset command, timeout, or until someone presses the button inside the room.
