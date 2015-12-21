namespace ShmupWarz
(**
 * Entitas Generated World Extensions for ShmupWarz
 *
 * do not edit this file
 *)
[<AutoOpen>]
module WorldExtensions =

    open Entitas
    open System
    open System.Collections.Generic

    type World with

        (** World: Score methods*)

        member this.scoreEntity
            with get() = this.GetGroup(Matcher.Score).GetSingleEntity()

        member this.score
            with get() = this.scoreEntity.score

        member this.hasScore
            with get() = notNull(this.scoreEntity)

        member this.SetScore(newValue) =
            if this.hasScore then
                failwith "Single Entity Exception: Score"
            let entity = this.CreateEntity("Score")
            entity.AddScore(newValue) |> ignore
            entity

        member this.ReplaceScore(newValue) =
            let entity = this.scoreEntity
            if isNull(entity) then
                entity = this.SetScore(newValue) |> ignore
            else
                entity.ReplaceScore(newValue) |> ignore
            entity

        member this.RemoveScore() =
            this.DestroyEntity(this.scoreEntity)

        (** World: Mouse methods*)

        member this.mouseEntity
            with get() = this.GetGroup(Matcher.Mouse).GetSingleEntity()

        member this.mouse
            with get() = this.mouseEntity.mouse

        member this.hasMouse
            with get() = notNull(this.mouseEntity)

        member this.SetMouse(newValue) =
            if this.hasMouse then
                failwith "Single Entity Exception: Mouse"
            let entity = this.CreateEntity("Mouse")
            entity.AddMouse(newValue) |> ignore
            entity

        member this.ReplaceMouse(newValue) =
            let entity = this.mouseEntity
            if isNull(entity) then
                entity = this.SetMouse(newValue) |> ignore
            else
                entity.ReplaceMouse(newValue) |> ignore
            entity

        member this.RemoveMouse() =
            this.DestroyEntity(this.mouseEntity)

        (** World: Firing methods*)

        member this.firingEntity
            with get() = this.GetGroup(Matcher.Firing).GetSingleEntity()

        member this.isFiring
            with get() =
                notNull(this.firingEntity)
            and  set(value) =
                let entity = this.firingEntity
                if value <> notNull(entity) then
                    if value then
                        this.CreateEntity("Firing").isFiring <- true
                    else
                        this.DestroyEntity(entity)

        (** World: Status methods*)

        member this.statusEntity
            with get() = this.GetGroup(Matcher.Status).GetSingleEntity()

        member this.status
            with get() = this.statusEntity.status

        member this.hasStatus
            with get() = notNull(this.statusEntity)

        member this.SetStatus(newValue) =
            if this.hasStatus then
                failwith "Single Entity Exception: Status"
            let entity = this.CreateEntity("Status")
            entity.AddStatus(newValue) |> ignore
            entity

        member this.ReplaceStatus(newValue) =
            let entity = this.statusEntity
            if isNull(entity) then
                entity = this.SetStatus(newValue) |> ignore
            else
                entity.ReplaceStatus(newValue) |> ignore
            entity

        member this.RemoveStatus() =
            this.DestroyEntity(this.statusEntity)

        (** World: Player methods*)

        member this.playerEntity
            with get() = this.GetGroup(Matcher.Player).GetSingleEntity()

        member this.isPlayer
            with get() =
                notNull(this.playerEntity)
            and  set(value) =
                let entity = this.playerEntity
                if value <> notNull(entity) then
                    if value then
                        this.CreateEntity("Player").isPlayer <- true
                    else
                        this.DestroyEntity(entity)
