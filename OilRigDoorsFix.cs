using Facepunch;
using System.Collections.Generic;
using System;

namespace Oxide.Plugins
{
    [Info("Oil Rig Doors Fix", "MON@H", "1.0.1")]
    [Description("Fix for always open doors on Oil Rigs")]
    public class OilRigDoorsFix : RustPlugin
    {

        private uint _cratePrefabID;
        private readonly List<uint> _doorHingedSecurityIDs = new List<uint>();

        #region Initialization

        private void Init()
        {
            Unsubscribe(nameof(OnEntitySpawned));
        }

        private void OnServerInitialized()
        {
            _cratePrefabID = StringPool.Get("assets/prefabs/deployable/chinooklockedcrate/codelockedhackablecrate_oilrig.prefab");
            _doorHingedSecurityIDs.Add(StringPool.Get("assets/bundled/prefabs/static/door.hinged.security.green.prefab"));
            _doorHingedSecurityIDs.Add(StringPool.Get("assets/bundled/prefabs/static/door.hinged.security.blue.prefab"));
            _doorHingedSecurityIDs.Add(StringPool.Get("assets/bundled/prefabs/static/door.hinged.security.red.prefab"));
            Subscribe(nameof(OnEntitySpawned));
        }

        #endregion Initialization

        #region Oxide Hooks

        private void OnEntitySpawned(HackableLockedCrate crate)
        {
            if (crate.prefabID == _cratePrefabID)
            {
                List<PressButton> pressButtons = Pool.GetList<PressButton>();
                List<Door> doors = Pool.GetList<Door>();
                Vis.Entities(crate.transform.position, 5f, doors);

                foreach (Door door in doors)
                {
                    if (door.IsOpen() && _doorHingedSecurityIDs.Contains(door.prefabID))
                    {
                        pressButtons = Pool.GetList<PressButton>();
                        Vis.Entities(door.transform.position, 2f, pressButtons);
                        foreach (PressButton pressButton in pressButtons)
                        {
                            pressButton.SetFlag(BaseEntity.Flags.On, true, false, true);
                            pressButton.Invoke(new Action(pressButton.UnpowerTime), pressButton.pressPowerTime);
                            pressButton.SetFlag(BaseEntity.Flags.Reserved3, true, false, true);
                            pressButton.SendNetworkUpdateImmediate(false);
                            pressButton.MarkDirty();
                            pressButton.Invoke(new Action(pressButton.Unpress), pressButton.pressDuration);
                        }
                    }
                }

                Pool.FreeList(ref doors);
                Pool.FreeList(ref pressButtons);
            }
        }

        #endregion Oxide Hooks
    }
}