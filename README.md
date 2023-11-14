# OilRigDoorsFix

Oxide plugin for Rust. Fix for glitch when doors on Oil Rigs are always open.

This plugin is to fix glitch when the doors in Oil Rig are always opened. No configuration, just install and you are done.

* To reproduce the glitch:

1. Go to the Oilrig and open the door (blue or red or both) with card. Now run `debug.puzzlereset` and see if the door will be closed (it should be).
2. Now open doors with cards and restart the server while doors are still opened. After server being loaded go to doors you left openned and check if they are still opened. And if so - now try to run `debug.puzzlereset` (or wait some time until lockedhackablecrate will be spawned). In all environments I've tested those doors will stay opened until next wipe regardless of restart server/puzzlereset command/timeout or until someone will press the button inside the room.
