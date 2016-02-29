﻿namespace ShmupWarz
(**
 * Entitas Generated World Extensions for ShmupWarz
 *
 * do not edit this file
 *)
[<AutoOpen>]
module CoreExtensions =

    open Bosco.ECS
    open System
    open System.Collections.Generic

    let isNull x = match x with null -> true | _ -> false
    let notNull x = match x with null -> false | _ -> true

    type Entity with
      (** 
       * RemoveComponent 
       *
       * @param index
       * @returns this entity
       *)
      member this.RemoveComponent(index:int) =
        if not this.IsEnabled then 
          failwith "Entity is disabled, cannot remove component"
        if not(this.HasComponent(index)) then 
          failwithf "Entity does not have component, cannot remove at index %d, %s" index (this.ToString())

        this.replaceComponent(index, null)
        this

      (** 
       * ReplaceComponent 
       *
       * @param index
       * @param component
       * @returns this entity
       *)
      member this.ReplaceComponent(index:int, c:Component) =
        if not this.IsEnabled then 
          failwith "Entity is disabled, cannot replace at index %d, %s" index (this.ToString())

        if this.HasComponent(index) then
          this.replaceComponent(index, c)
        elif notNull(c) then
          this.AddComponent(index, c) |> ignore
        this


      (** 
       * Retain (reference count)
       *
       *)
      member this.Retain() =
        this.refCount <- this.refCount + 1

