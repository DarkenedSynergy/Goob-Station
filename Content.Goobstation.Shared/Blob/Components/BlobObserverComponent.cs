// SPDX-FileCopyrightText: 2024 Aiden <aiden@djkraz.com>
// SPDX-FileCopyrightText: 2024 Fishbait <Fishbait@git.ml>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2024 fishbait <gnesse@gmail.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Misandry <mary@thughunt.ing>
// SPDX-FileCopyrightText: 2025 gus <august.eymann@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Shared.Actions;
using Robust.Shared.GameStates;
using Robust.Shared.Map;
using Robust.Shared.Serialization;

namespace Content.Goobstation.Shared.Blob.Components;

[RegisterComponent]
public sealed partial class BlobObserverControllerComponent : Component
{
    public Entity<BlobObserverComponent> Blob;
}

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(false)]
public sealed partial class BlobObserverComponent : Component
{
    [ViewVariables]
    public bool IsProcessingMoveEvent;

    //[AutoNetworkedField]
    [ViewVariables]
    public Entity<BlobCoreComponent>? Core = default!;

    /*[ViewVariables]
    public bool CanMove = true;*/

    [ViewVariables, AutoNetworkedField]
    public BlobChemType SelectedChemId = BlobChemType.ReactiveSpines;

    public override bool SendOnlyToOwner => true;

    [ViewVariables, AutoNetworkedField]
    public EntityUid VirtualItem = EntityUid.Invalid;
}

[Serializable, NetSerializable]
public sealed class BlobChemSwapBoundUserInterfaceState(
    BlobChemColors chemList,
    BlobChemType selectedId)
    : BoundUserInterfaceState
{
    public readonly BlobChemColors ChemList = chemList;
    public readonly BlobChemType SelectedChem = selectedId;
}

[Serializable, NetSerializable]
public sealed class BlobChemSwapPrototypeSelectedMessage(BlobChemType selectedId) : BoundUserInterfaceMessage
{
    public readonly BlobChemType SelectedId = selectedId;
}

[Serializable, NetSerializable]
public enum BlobChemSwapUiKey : byte
{
    Key
}

public sealed partial class BlobTransformTileActionEvent : WorldTargetActionEvent
{
    /// <summary>
    /// Type of tile that can be transformed.
    /// Will be ignored if equals to Invalid.
    /// </summary>
    [DataField]
    public BlobTileType TransformFrom = BlobTileType.Normal;

    /// <summary>
    /// Type of the resulting tile.
    /// </summary>
    [DataField]
    public BlobTileType TileType = BlobTileType.Invalid;

    /// <summary>
    /// Does this tile requires node nearby.
    /// </summary>
    [DataField]
    public bool RequireNode = true;

    public BlobTransformTileActionEvent(EntityUid performer, EntityCoordinates target, BlobTileType transformFrom, BlobTileType tileType, bool requireNode) : this()
    {
        Performer = performer;
        Target = target;
        TransformFrom = transformFrom;
        TileType = tileType;
        RequireNode = requireNode;
    }
}

public sealed partial class BlobCreateBlobbernautActionEvent : WorldTargetActionEvent
{

}

public sealed partial class BlobSplitCoreActionEvent : WorldTargetActionEvent
{

}

public sealed partial class BlobSwapCoreActionEvent : WorldTargetActionEvent
{

}

public sealed partial class BlobToCoreActionEvent : InstantActionEvent
{

}

public sealed partial class BlobSwapChemActionEvent : InstantActionEvent
{

}