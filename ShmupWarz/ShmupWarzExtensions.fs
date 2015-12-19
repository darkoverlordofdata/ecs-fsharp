module ShmupWarzExtensions

(**
 * Entitas Generated Extensions for ShmupWarz
 *
 * do not edit this file
 *)

open Entitas
open ShmupWarz
open System
open System.Collections.Generic

let isNull x = match x with null -> true | _ -> false

type Component with 
    static member Bounds with get() = 1
    static member Bullet with get() = 2
    static member ColorAnimation with get() = 3
    static member Enemy with get() = 4
    static member Expires with get() = 5
    static member Firing with get() = 6
    static member Health with get() = 7
    static member ParallaxStar with get() = 8
    static member Player with get() = 9
    static member Position with get() = 10
    static member ScaleAnimation with get() = 11
    static member SoundEffect with get() = 12
    static member Sprite with get() = 13
    static member Velocity with get() = 14
    static member Score with get() = 15
    static member Destroy with get() = 16
    static member Mouse with get() = 17
    static member Scale with get() = 18
    static member Resource with get() = 19
    static member Layer with get() = 20
    static member Background with get() = 21
    static member Mine with get() = 22
    static member Status with get() = 23
    static member Life with get() = 24
    static member TotalComponents  with get() = 25

type ComponentId = 
  | Bounds = 1
  | Bullet = 2
  | ColorAnimation = 3
  | Enemy = 4
  | Expires = 5
  | Firing = 6
  | Health = 7
  | ParallaxStar = 8
  | Player = 9
  | Position = 10
  | ScaleAnimation = 11
  | SoundEffect = 12
  | Sprite = 13
  | Velocity = 14
  | Score = 15
  | Destroy = 16
  | Mouse = 17
  | Scale = 18
  | Resource = 19
  | Layer = 20
  | Background = 21
  | Mine = 22
  | Status = 23
  | Life = 24
  | TotalComponents = 25

type Entity with
    member this.bounds
        with get() = this.GetComponent(Component.Bounds):?>BoundsComponent

    member this.hasBounds
        with get() = this.HasComponent(Component.Bounds)

    member this._boundsComponentPool
         with get() = new Stack<BoundsComponent>()

    member this.ClearBoundsComponentPool() =
        this._boundsComponentPool.Clear()

    member this.AddBounds(radius) =
        let mutable c = 
          match this._boundsComponentPool.Count with
          | 0 -> new BoundsComponent()
          | _ -> this._boundsComponentPool.Pop()
        c.radius <- radius;
        this.AddComponent(Component.Bounds, c)

    member this.ReplaceBounds(radius) =
        let previousComponent = if this.hasBounds then this.bounds else null
        let mutable c = 
          match this._boundsComponentPool.Count with
          | 0 -> new BoundsComponent()
          | _ -> this._boundsComponentPool.Pop()
        c.radius <- radius;
        this.ReplaceComponent(Component.Bounds, c) |> ignore
        if not(isNull(previousComponent)) then
            this._boundsComponentPool.Push(previousComponent)
        this

    member this.RemoveBounds() =
        let c = this.bounds
        this.RemoveComponent(Component.Bounds) |> ignore
        this._boundsComponentPool.Push(c)

type Matcher with 
    static member Bounds with get() = Matcher.AllOf(Component.Bounds) 

type Entity with

    static member bulletComponent= new BulletComponent()

    member this.isBullet
        with get() =
            this.HasComponent(Component.Bullet)
        and  set(value) =
            if value <> this.isBullet then
                this.AddComponent(Component.Bullet, Entity.bulletComponent) |> ignore
            else
                this.RemoveComponent(Component.Bullet) |> ignore

    member this.IsBullet(value) =
        this.isBullet <- value
        this

type Matcher with 
    static member Bullet with get() = Matcher.AllOf(Component.Bullet) 

type Entity with
    member this.colorAnimation
        with get() = this.GetComponent(Component.ColorAnimation):?>ColorAnimationComponent

    member this.hasColorAnimation
        with get() = this.HasComponent(Component.ColorAnimation)

    member this._colorAnimationComponentPool
         with get() = new Stack<ColorAnimationComponent>()

    member this.ClearColorAnimationComponentPool() =
        this._colorAnimationComponentPool.Clear()

    member this.AddColorAnimation(redMin, redMax, redSpeed, greenMin, greenMax, greenSpeed, blueMin, blueMax, blueSpeed, alphaMin, alphaMax, alphaSpeed, redAnimate, greenAnimate, blueAnimate, alphaAnimate, repeat) =
        let mutable c = 
          match this._colorAnimationComponentPool.Count with
          | 0 -> new ColorAnimationComponent()
          | _ -> this._colorAnimationComponentPool.Pop()
        c.redMin <- redMin;
        c.redMax <- redMax;
        c.redSpeed <- redSpeed;
        c.greenMin <- greenMin;
        c.greenMax <- greenMax;
        c.greenSpeed <- greenSpeed;
        c.blueMin <- blueMin;
        c.blueMax <- blueMax;
        c.blueSpeed <- blueSpeed;
        c.alphaMin <- alphaMin;
        c.alphaMax <- alphaMax;
        c.alphaSpeed <- alphaSpeed;
        c.redAnimate <- redAnimate;
        c.greenAnimate <- greenAnimate;
        c.blueAnimate <- blueAnimate;
        c.alphaAnimate <- alphaAnimate;
        c.repeat <- repeat;
        this.AddComponent(Component.ColorAnimation, c)

    member this.ReplaceColorAnimation(redMin, redMax, redSpeed, greenMin, greenMax, greenSpeed, blueMin, blueMax, blueSpeed, alphaMin, alphaMax, alphaSpeed, redAnimate, greenAnimate, blueAnimate, alphaAnimate, repeat) =
        let previousComponent = if this.hasColorAnimation then this.colorAnimation else null
        let mutable c = 
          match this._colorAnimationComponentPool.Count with
          | 0 -> new ColorAnimationComponent()
          | _ -> this._colorAnimationComponentPool.Pop()
        c.redMin <- redMin;
        c.redMax <- redMax;
        c.redSpeed <- redSpeed;
        c.greenMin <- greenMin;
        c.greenMax <- greenMax;
        c.greenSpeed <- greenSpeed;
        c.blueMin <- blueMin;
        c.blueMax <- blueMax;
        c.blueSpeed <- blueSpeed;
        c.alphaMin <- alphaMin;
        c.alphaMax <- alphaMax;
        c.alphaSpeed <- alphaSpeed;
        c.redAnimate <- redAnimate;
        c.greenAnimate <- greenAnimate;
        c.blueAnimate <- blueAnimate;
        c.alphaAnimate <- alphaAnimate;
        c.repeat <- repeat;
        this.ReplaceComponent(Component.ColorAnimation, c) |> ignore
        if not(isNull(previousComponent)) then
            this._colorAnimationComponentPool.Push(previousComponent)
        this

    member this.RemoveColorAnimation() =
        let c = this.colorAnimation
        this.RemoveComponent(Component.ColorAnimation) |> ignore
        this._colorAnimationComponentPool.Push(c)

type Matcher with 
    static member ColorAnimation with get() = Matcher.AllOf(Component.ColorAnimation) 

type Entity with

    static member enemyComponent= new EnemyComponent()

    member this.isEnemy
        with get() =
            this.HasComponent(Component.Enemy)
        and  set(value) =
            if value <> this.isEnemy then
                this.AddComponent(Component.Enemy, Entity.enemyComponent) |> ignore
            else
                this.RemoveComponent(Component.Enemy) |> ignore

    member this.IsEnemy(value) =
        this.isEnemy <- value
        this

type Matcher with 
    static member Enemy with get() = Matcher.AllOf(Component.Enemy) 

type Entity with
    member this.expires
        with get() = this.GetComponent(Component.Expires):?>ExpiresComponent

    member this.hasExpires
        with get() = this.HasComponent(Component.Expires)

    member this._expiresComponentPool
         with get() = new Stack<ExpiresComponent>()

    member this.ClearExpiresComponentPool() =
        this._expiresComponentPool.Clear()

    member this.AddExpires(delay) =
        let mutable c = 
          match this._expiresComponentPool.Count with
          | 0 -> new ExpiresComponent()
          | _ -> this._expiresComponentPool.Pop()
        c.delay <- delay;
        this.AddComponent(Component.Expires, c)

    member this.ReplaceExpires(delay) =
        let previousComponent = if this.hasExpires then this.expires else null
        let mutable c = 
          match this._expiresComponentPool.Count with
          | 0 -> new ExpiresComponent()
          | _ -> this._expiresComponentPool.Pop()
        c.delay <- delay;
        this.ReplaceComponent(Component.Expires, c) |> ignore
        if not(isNull(previousComponent)) then
            this._expiresComponentPool.Push(previousComponent)
        this

    member this.RemoveExpires() =
        let c = this.expires
        this.RemoveComponent(Component.Expires) |> ignore
        this._expiresComponentPool.Push(c)

type Matcher with 
    static member Expires with get() = Matcher.AllOf(Component.Expires) 

type Entity with

    static member firingComponent= new FiringComponent()

    member this.isFiring
        with get() =
            this.HasComponent(Component.Firing)
        and  set(value) =
            if value <> this.isFiring then
                this.AddComponent(Component.Firing, Entity.firingComponent) |> ignore
            else
                this.RemoveComponent(Component.Firing) |> ignore

    member this.IsFiring(value) =
        this.isFiring <- value
        this

type Matcher with 
    static member Firing with get() = Matcher.AllOf(Component.Firing) 

type Entity with
    member this.health
        with get() = this.GetComponent(Component.Health):?>HealthComponent

    member this.hasHealth
        with get() = this.HasComponent(Component.Health)

    member this._healthComponentPool
         with get() = new Stack<HealthComponent>()

    member this.ClearHealthComponentPool() =
        this._healthComponentPool.Clear()

    member this.AddHealth(health, maximumHealth) =
        let mutable c = 
          match this._healthComponentPool.Count with
          | 0 -> new HealthComponent()
          | _ -> this._healthComponentPool.Pop()
        c.health <- health;
        c.maximumHealth <- maximumHealth;
        this.AddComponent(Component.Health, c)

    member this.ReplaceHealth(health, maximumHealth) =
        let previousComponent = if this.hasHealth then this.health else null
        let mutable c = 
          match this._healthComponentPool.Count with
          | 0 -> new HealthComponent()
          | _ -> this._healthComponentPool.Pop()
        c.health <- health;
        c.maximumHealth <- maximumHealth;
        this.ReplaceComponent(Component.Health, c) |> ignore
        if not(isNull(previousComponent)) then
            this._healthComponentPool.Push(previousComponent)
        this

    member this.RemoveHealth() =
        let c = this.health
        this.RemoveComponent(Component.Health) |> ignore
        this._healthComponentPool.Push(c)

type Matcher with 
    static member Health with get() = Matcher.AllOf(Component.Health) 

type Entity with

    static member parallaxStarComponent= new ParallaxStarComponent()

    member this.isParallaxStar
        with get() =
            this.HasComponent(Component.ParallaxStar)
        and  set(value) =
            if value <> this.isParallaxStar then
                this.AddComponent(Component.ParallaxStar, Entity.parallaxStarComponent) |> ignore
            else
                this.RemoveComponent(Component.ParallaxStar) |> ignore

    member this.IsParallaxStar(value) =
        this.isParallaxStar <- value
        this

type Matcher with 
    static member ParallaxStar with get() = Matcher.AllOf(Component.ParallaxStar) 

type Entity with

    static member playerComponent= new PlayerComponent()

    member this.isPlayer
        with get() =
            this.HasComponent(Component.Player)
        and  set(value) =
            if value <> this.isPlayer then
                this.AddComponent(Component.Player, Entity.playerComponent) |> ignore
            else
                this.RemoveComponent(Component.Player) |> ignore

    member this.IsPlayer(value) =
        this.isPlayer <- value
        this

type Matcher with 
    static member Player with get() = Matcher.AllOf(Component.Player) 

type Entity with
    member this.position
        with get() = this.GetComponent(Component.Position):?>PositionComponent

    member this.hasPosition
        with get() = this.HasComponent(Component.Position)

    member this._positionComponentPool
         with get() = new Stack<PositionComponent>()

    member this.ClearPositionComponentPool() =
        this._positionComponentPool.Clear()

    member this.AddPosition(x, y) =
        let mutable c = 
          match this._positionComponentPool.Count with
          | 0 -> new PositionComponent()
          | _ -> this._positionComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.AddComponent(Component.Position, c)

    member this.ReplacePosition(x, y) =
        let previousComponent = if this.hasPosition then this.position else null
        let mutable c = 
          match this._positionComponentPool.Count with
          | 0 -> new PositionComponent()
          | _ -> this._positionComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.ReplaceComponent(Component.Position, c) |> ignore
        if not(isNull(previousComponent)) then
            this._positionComponentPool.Push(previousComponent)
        this

    member this.RemovePosition() =
        let c = this.position
        this.RemoveComponent(Component.Position) |> ignore
        this._positionComponentPool.Push(c)

type Matcher with 
    static member Position with get() = Matcher.AllOf(Component.Position) 

type Entity with
    member this.scaleAnimation
        with get() = this.GetComponent(Component.ScaleAnimation):?>ScaleAnimationComponent

    member this.hasScaleAnimation
        with get() = this.HasComponent(Component.ScaleAnimation)

    member this._scaleAnimationComponentPool
         with get() = new Stack<ScaleAnimationComponent>()

    member this.ClearScaleAnimationComponentPool() =
        this._scaleAnimationComponentPool.Clear()

    member this.AddScaleAnimation(min, max, speed, repeat, active) =
        let mutable c = 
          match this._scaleAnimationComponentPool.Count with
          | 0 -> new ScaleAnimationComponent()
          | _ -> this._scaleAnimationComponentPool.Pop()
        c.min <- min;
        c.max <- max;
        c.speed <- speed;
        c.repeat <- repeat;
        c.active <- active;
        this.AddComponent(Component.ScaleAnimation, c)

    member this.ReplaceScaleAnimation(min, max, speed, repeat, active) =
        let previousComponent = if this.hasScaleAnimation then this.scaleAnimation else null
        let mutable c = 
          match this._scaleAnimationComponentPool.Count with
          | 0 -> new ScaleAnimationComponent()
          | _ -> this._scaleAnimationComponentPool.Pop()
        c.min <- min;
        c.max <- max;
        c.speed <- speed;
        c.repeat <- repeat;
        c.active <- active;
        this.ReplaceComponent(Component.ScaleAnimation, c) |> ignore
        if not(isNull(previousComponent)) then
            this._scaleAnimationComponentPool.Push(previousComponent)
        this

    member this.RemoveScaleAnimation() =
        let c = this.scaleAnimation
        this.RemoveComponent(Component.ScaleAnimation) |> ignore
        this._scaleAnimationComponentPool.Push(c)

type Matcher with 
    static member ScaleAnimation with get() = Matcher.AllOf(Component.ScaleAnimation) 

type Entity with
    member this.soundEffect
        with get() = this.GetComponent(Component.SoundEffect):?>SoundEffectComponent

    member this.hasSoundEffect
        with get() = this.HasComponent(Component.SoundEffect)

    member this._soundEffectComponentPool
         with get() = new Stack<SoundEffectComponent>()

    member this.ClearSoundEffectComponentPool() =
        this._soundEffectComponentPool.Clear()

    member this.AddSoundEffect(effect) =
        let mutable c = 
          match this._soundEffectComponentPool.Count with
          | 0 -> new SoundEffectComponent()
          | _ -> this._soundEffectComponentPool.Pop()
        c.effect <- effect;
        this.AddComponent(Component.SoundEffect, c)

    member this.ReplaceSoundEffect(effect) =
        let previousComponent = if this.hasSoundEffect then this.soundEffect else null
        let mutable c = 
          match this._soundEffectComponentPool.Count with
          | 0 -> new SoundEffectComponent()
          | _ -> this._soundEffectComponentPool.Pop()
        c.effect <- effect;
        this.ReplaceComponent(Component.SoundEffect, c) |> ignore
        if not(isNull(previousComponent)) then
            this._soundEffectComponentPool.Push(previousComponent)
        this

    member this.RemoveSoundEffect() =
        let c = this.soundEffect
        this.RemoveComponent(Component.SoundEffect) |> ignore
        this._soundEffectComponentPool.Push(c)

type Matcher with 
    static member SoundEffect with get() = Matcher.AllOf(Component.SoundEffect) 

type Entity with
    member this.sprite
        with get() = this.GetComponent(Component.Sprite):?>SpriteComponent

    member this.hasSprite
        with get() = this.HasComponent(Component.Sprite)

    member this._spriteComponentPool
         with get() = new Stack<SpriteComponent>()

    member this.ClearSpriteComponentPool() =
        this._spriteComponentPool.Clear()

    member this.AddSprite(layer, gameObject) =
        let mutable c = 
          match this._spriteComponentPool.Count with
          | 0 -> new SpriteComponent()
          | _ -> this._spriteComponentPool.Pop()
        c.layer <- layer;
        c.gameObject <- gameObject;
        this.AddComponent(Component.Sprite, c)

    member this.ReplaceSprite(layer, gameObject) =
        let previousComponent = if this.hasSprite then this.sprite else null
        let mutable c = 
          match this._spriteComponentPool.Count with
          | 0 -> new SpriteComponent()
          | _ -> this._spriteComponentPool.Pop()
        c.layer <- layer;
        c.gameObject <- gameObject;
        this.ReplaceComponent(Component.Sprite, c) |> ignore
        if not(isNull(previousComponent)) then
            this._spriteComponentPool.Push(previousComponent)
        this

    member this.RemoveSprite() =
        let c = this.sprite
        this.RemoveComponent(Component.Sprite) |> ignore
        this._spriteComponentPool.Push(c)

type Matcher with 
    static member Sprite with get() = Matcher.AllOf(Component.Sprite) 

type Entity with
    member this.velocity
        with get() = this.GetComponent(Component.Velocity):?>VelocityComponent

    member this.hasVelocity
        with get() = this.HasComponent(Component.Velocity)

    member this._velocityComponentPool
         with get() = new Stack<VelocityComponent>()

    member this.ClearVelocityComponentPool() =
        this._velocityComponentPool.Clear()

    member this.AddVelocity(x, y) =
        let mutable c = 
          match this._velocityComponentPool.Count with
          | 0 -> new VelocityComponent()
          | _ -> this._velocityComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.AddComponent(Component.Velocity, c)

    member this.ReplaceVelocity(x, y) =
        let previousComponent = if this.hasVelocity then this.velocity else null
        let mutable c = 
          match this._velocityComponentPool.Count with
          | 0 -> new VelocityComponent()
          | _ -> this._velocityComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.ReplaceComponent(Component.Velocity, c) |> ignore
        if not(isNull(previousComponent)) then
            this._velocityComponentPool.Push(previousComponent)
        this

    member this.RemoveVelocity() =
        let c = this.velocity
        this.RemoveComponent(Component.Velocity) |> ignore
        this._velocityComponentPool.Push(c)

type Matcher with 
    static member Velocity with get() = Matcher.AllOf(Component.Velocity) 

type Entity with
    member this.score
        with get() = this.GetComponent(Component.Score):?>ScoreComponent

    member this.hasScore
        with get() = this.HasComponent(Component.Score)

    member this._scoreComponentPool
         with get() = new Stack<ScoreComponent>()

    member this.ClearScoreComponentPool() =
        this._scoreComponentPool.Clear()

    member this.AddScore(value) =
        let mutable c = 
          match this._scoreComponentPool.Count with
          | 0 -> new ScoreComponent()
          | _ -> this._scoreComponentPool.Pop()
        c.value <- value;
        this.AddComponent(Component.Score, c)

    member this.ReplaceScore(value) =
        let previousComponent = if this.hasScore then this.score else null
        let mutable c = 
          match this._scoreComponentPool.Count with
          | 0 -> new ScoreComponent()
          | _ -> this._scoreComponentPool.Pop()
        c.value <- value;
        this.ReplaceComponent(Component.Score, c) |> ignore
        if not(isNull(previousComponent)) then
            this._scoreComponentPool.Push(previousComponent)
        this

    member this.RemoveScore() =
        let c = this.score
        this.RemoveComponent(Component.Score) |> ignore
        this._scoreComponentPool.Push(c)

type Matcher with 
    static member Score with get() = Matcher.AllOf(Component.Score) 

type Entity with

    static member destroyComponent= new DestroyComponent()

    member this.isDestroy
        with get() =
            this.HasComponent(Component.Destroy)
        and  set(value) =
            if value <> this.isDestroy then
                this.AddComponent(Component.Destroy, Entity.destroyComponent) |> ignore
            else
                this.RemoveComponent(Component.Destroy) |> ignore

    member this.IsDestroy(value) =
        this.isDestroy <- value
        this

type Matcher with 
    static member Destroy with get() = Matcher.AllOf(Component.Destroy) 

type Entity with
    member this.mouse
        with get() = this.GetComponent(Component.Mouse):?>MouseComponent

    member this.hasMouse
        with get() = this.HasComponent(Component.Mouse)

    member this._mouseComponentPool
         with get() = new Stack<MouseComponent>()

    member this.ClearMouseComponentPool() =
        this._mouseComponentPool.Clear()

    member this.AddMouse(x, y) =
        let mutable c = 
          match this._mouseComponentPool.Count with
          | 0 -> new MouseComponent()
          | _ -> this._mouseComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.AddComponent(Component.Mouse, c)

    member this.ReplaceMouse(x, y) =
        let previousComponent = if this.hasMouse then this.mouse else null
        let mutable c = 
          match this._mouseComponentPool.Count with
          | 0 -> new MouseComponent()
          | _ -> this._mouseComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.ReplaceComponent(Component.Mouse, c) |> ignore
        if not(isNull(previousComponent)) then
            this._mouseComponentPool.Push(previousComponent)
        this

    member this.RemoveMouse() =
        let c = this.mouse
        this.RemoveComponent(Component.Mouse) |> ignore
        this._mouseComponentPool.Push(c)

type Matcher with 
    static member Mouse with get() = Matcher.AllOf(Component.Mouse) 

type Entity with
    member this.scale
        with get() = this.GetComponent(Component.Scale):?>ScaleComponent

    member this.hasScale
        with get() = this.HasComponent(Component.Scale)

    member this._scaleComponentPool
         with get() = new Stack<ScaleComponent>()

    member this.ClearScaleComponentPool() =
        this._scaleComponentPool.Clear()

    member this.AddScale(x, y) =
        let mutable c = 
          match this._scaleComponentPool.Count with
          | 0 -> new ScaleComponent()
          | _ -> this._scaleComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.AddComponent(Component.Scale, c)

    member this.ReplaceScale(x, y) =
        let previousComponent = if this.hasScale then this.scale else null
        let mutable c = 
          match this._scaleComponentPool.Count with
          | 0 -> new ScaleComponent()
          | _ -> this._scaleComponentPool.Pop()
        c.x <- x;
        c.y <- y;
        this.ReplaceComponent(Component.Scale, c) |> ignore
        if not(isNull(previousComponent)) then
            this._scaleComponentPool.Push(previousComponent)
        this

    member this.RemoveScale() =
        let c = this.scale
        this.RemoveComponent(Component.Scale) |> ignore
        this._scaleComponentPool.Push(c)

type Matcher with 
    static member Scale with get() = Matcher.AllOf(Component.Scale) 

type Entity with
    member this.resource
        with get() = this.GetComponent(Component.Resource):?>ResourceComponent

    member this.hasResource
        with get() = this.HasComponent(Component.Resource)

    member this._resourceComponentPool
         with get() = new Stack<ResourceComponent>()

    member this.ClearResourceComponentPool() =
        this._resourceComponentPool.Clear()

    member this.AddResource(name) =
        let mutable c = 
          match this._resourceComponentPool.Count with
          | 0 -> new ResourceComponent()
          | _ -> this._resourceComponentPool.Pop()
        c.name <- name;
        this.AddComponent(Component.Resource, c)

    member this.ReplaceResource(name) =
        let previousComponent = if this.hasResource then this.resource else null
        let mutable c = 
          match this._resourceComponentPool.Count with
          | 0 -> new ResourceComponent()
          | _ -> this._resourceComponentPool.Pop()
        c.name <- name;
        this.ReplaceComponent(Component.Resource, c) |> ignore
        if not(isNull(previousComponent)) then
            this._resourceComponentPool.Push(previousComponent)
        this

    member this.RemoveResource() =
        let c = this.resource
        this.RemoveComponent(Component.Resource) |> ignore
        this._resourceComponentPool.Push(c)

type Matcher with 
    static member Resource with get() = Matcher.AllOf(Component.Resource) 

type Entity with
    member this.layer
        with get() = this.GetComponent(Component.Layer):?>LayerComponent

    member this.hasLayer
        with get() = this.HasComponent(Component.Layer)

    member this._layerComponentPool
         with get() = new Stack<LayerComponent>()

    member this.ClearLayerComponentPool() =
        this._layerComponentPool.Clear()

    member this.AddLayer(ordinal) =
        let mutable c = 
          match this._layerComponentPool.Count with
          | 0 -> new LayerComponent()
          | _ -> this._layerComponentPool.Pop()
        c.ordinal <- ordinal;
        this.AddComponent(Component.Layer, c)

    member this.ReplaceLayer(ordinal) =
        let previousComponent = if this.hasLayer then this.layer else null
        let mutable c = 
          match this._layerComponentPool.Count with
          | 0 -> new LayerComponent()
          | _ -> this._layerComponentPool.Pop()
        c.ordinal <- ordinal;
        this.ReplaceComponent(Component.Layer, c) |> ignore
        if not(isNull(previousComponent)) then
            this._layerComponentPool.Push(previousComponent)
        this

    member this.RemoveLayer() =
        let c = this.layer
        this.RemoveComponent(Component.Layer) |> ignore
        this._layerComponentPool.Push(c)

type Matcher with 
    static member Layer with get() = Matcher.AllOf(Component.Layer) 

type Entity with
    member this.background
        with get() = this.GetComponent(Component.Background):?>BackgroundComponent

    member this.hasBackground
        with get() = this.HasComponent(Component.Background)

    member this._backgroundComponentPool
         with get() = new Stack<BackgroundComponent>()

    member this.ClearBackgroundComponentPool() =
        this._backgroundComponentPool.Clear()

    member this.AddBackground(filter) =
        let mutable c = 
          match this._backgroundComponentPool.Count with
          | 0 -> new BackgroundComponent()
          | _ -> this._backgroundComponentPool.Pop()
        c.filter <- filter;
        this.AddComponent(Component.Background, c)

    member this.ReplaceBackground(filter) =
        let previousComponent = if this.hasBackground then this.background else null
        let mutable c = 
          match this._backgroundComponentPool.Count with
          | 0 -> new BackgroundComponent()
          | _ -> this._backgroundComponentPool.Pop()
        c.filter <- filter;
        this.ReplaceComponent(Component.Background, c) |> ignore
        if not(isNull(previousComponent)) then
            this._backgroundComponentPool.Push(previousComponent)
        this

    member this.RemoveBackground() =
        let c = this.background
        this.RemoveComponent(Component.Background) |> ignore
        this._backgroundComponentPool.Push(c)

type Matcher with 
    static member Background with get() = Matcher.AllOf(Component.Background) 

type Entity with

    static member mineComponent= new MineComponent()

    member this.isMine
        with get() =
            this.HasComponent(Component.Mine)
        and  set(value) =
            if value <> this.isMine then
                this.AddComponent(Component.Mine, Entity.mineComponent) |> ignore
            else
                this.RemoveComponent(Component.Mine) |> ignore

    member this.IsMine(value) =
        this.isMine <- value
        this

type Matcher with 
    static member Mine with get() = Matcher.AllOf(Component.Mine) 

type Entity with
    member this.status
        with get() = this.GetComponent(Component.Status):?>StatusComponent

    member this.hasStatus
        with get() = this.HasComponent(Component.Status)

    member this._statusComponentPool
         with get() = new Stack<StatusComponent>()

    member this.ClearStatusComponentPool() =
        this._statusComponentPool.Clear()

    member this.AddStatus(percent, immunity) =
        let mutable c = 
          match this._statusComponentPool.Count with
          | 0 -> new StatusComponent()
          | _ -> this._statusComponentPool.Pop()
        c.percent <- percent;
        c.immunity <- immunity;
        this.AddComponent(Component.Status, c)

    member this.ReplaceStatus(percent, immunity) =
        let previousComponent = if this.hasStatus then this.status else null
        let mutable c = 
          match this._statusComponentPool.Count with
          | 0 -> new StatusComponent()
          | _ -> this._statusComponentPool.Pop()
        c.percent <- percent;
        c.immunity <- immunity;
        this.ReplaceComponent(Component.Status, c) |> ignore
        if not(isNull(previousComponent)) then
            this._statusComponentPool.Push(previousComponent)
        this

    member this.RemoveStatus() =
        let c = this.status
        this.RemoveComponent(Component.Status) |> ignore
        this._statusComponentPool.Push(c)

type Matcher with 
    static member Status with get() = Matcher.AllOf(Component.Status) 

type Entity with
    member this.life
        with get() = this.GetComponent(Component.Life):?>LifeComponent

    member this.hasLife
        with get() = this.HasComponent(Component.Life)

    member this._lifeComponentPool
         with get() = new Stack<LifeComponent>()

    member this.ClearLifeComponentPool() =
        this._lifeComponentPool.Clear()

    member this.AddLife(count) =
        let mutable c = 
          match this._lifeComponentPool.Count with
          | 0 -> new LifeComponent()
          | _ -> this._lifeComponentPool.Pop()
        c.count <- count;
        this.AddComponent(Component.Life, c)

    member this.ReplaceLife(count) =
        let previousComponent = if this.hasLife then this.life else null
        let mutable c = 
          match this._lifeComponentPool.Count with
          | 0 -> new LifeComponent()
          | _ -> this._lifeComponentPool.Pop()
        c.count <- count;
        this.ReplaceComponent(Component.Life, c) |> ignore
        if not(isNull(previousComponent)) then
            this._lifeComponentPool.Push(previousComponent)
        this

    member this.RemoveLife() =
        let c = this.life
        this.RemoveComponent(Component.Life) |> ignore
        this._lifeComponentPool.Push(c)

type Matcher with 
    static member Life with get() = Matcher.AllOf(Component.Life) 
