// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace Microsoft.FSharp.Collections

  open System
  open System.Collections
  open System.Collections.Generic
  open Microsoft.FSharp.Core
  open Microsoft.FSharp.Collections
  open Microsoft.FSharp.Collections.SeqComposition

  [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
  module ISeq =
    module Core =
        /// Values is a mutable struct. It can be embedded within the folder type
        /// if two values are required for the calculation.
        [<Struct; NoComparison; NoEquality>]
        type internal Value<'a> =
            new : a:'a -> Value<'a>
            val mutable _1: 'a

        /// Values is a mutable struct. It can be embedded within the folder type
        /// if two values are required for the calculation.
        [<Struct; NoComparison; NoEquality>]
        type Values<'a,'b> =
            new : a:'a * b:'b -> Values<'a,'b>
            val mutable _1: 'a
            val mutable _2: 'b

        /// Values is a mutable struct. It can be embedded within the folder type
        /// if three values are required for the calculation.
        [<Struct; NoComparison; NoEquality>]
        type internal Values<'a,'b,'c> =
            new : a:'a * b:'b * c:'c -> Values<'a,'b,'c>
            val mutable _1: 'a
            val mutable _2: 'b
            val mutable _3: 'c


        /// An activity that transforms the input from 'T to 'U, using 'State. It's intended usage
        /// is as a base class for an object expression that will be created 
        /// in the ITransformFactory's Compose function.
        [<AbstractClass>]
        type internal Transform<'T,'U,'State> =
            inherit Activity<'T,'U>
            new : next:Activity * 'State -> Transform<'T,'U,'State>
            val mutable State : 'State
            val private Next : Activity

        /// An activity that transforms the input from 'T to 'U, using 'State
        /// and performs some post processing on the pipeline, either in the case of the stream
        /// ending sucessfully or when disposed. It's intended usage
        /// is as a base class for an object expression that will be created 
        /// in the ITransformFactory's Compose function.
        [<AbstractClass>]
        type internal TransformWithPostProcessing<'T,'U,'State> =
            inherit Transform<'T,'U,'State>
            new : next:Activity * 'State -> TransformWithPostProcessing<'T,'U,'State>
            abstract OnComplete : PipeIdx -> unit
            abstract OnDispose  : unit -> unit


        /// Folder is a base class to assist with fold-like operations. It's intended usage
        /// is as a base class for an object expression that will be used from within
        /// the Fold function.
        [<AbstractClass>]
        type FolderWithState<'T,'Result,'State> =
            inherit Folder<'T,'Result>
            new : 'Result*'State -> FolderWithState<'T,'Result,'State>
            val mutable State : 'State

        /// Folder is a base class to assist with fold-like operations
        /// and performs some post processing on the pipeline, either in the case of the stream
        /// ending sucessfully or when disposed. It's intended usage
        /// is as a base class for an object expression that will be used from within
        /// the Fold function.
        [<AbstractClass>]
        type FolderWithPostProcessing<'T,'Result,'State> =
            inherit FolderWithState<'T,'Result,'State>
            new : 'Result*'State -> FolderWithPostProcessing<'T,'Result,'State>
            abstract OnDispose : unit -> unit
            abstract OnComplete : PipeIdx -> unit

    open Core

    /// ofResizeArrayUnchecked creates an ISeq over a ResizeArray that accesses the underlying
    /// structure via Index rather than via the GetEnumerator function. This provides faster access
    /// but doesn't check the version of the underlying object which means care has to be taken
    /// to ensure that it is not modified which the result ISeq exists.
    [<CompiledName "OfResizeArrayUnchecked">]
    val internal ofResizeArrayUnchecked : ResizeArray<'T> -> ISeq<'T>

    [<CompiledName "OfList">]
    val internal ofList : list<'T> -> ISeq<'T>

    [<CompiledName "OfArray">]
    val internal ofArray : array<'T> -> ISeq<'T>

    [<CompiledName "OfSeq">]
    val ofSeq : seq<'T> -> ISeq<'T>

    [<CompiledName "Average">]
    val inline average : source: ISeq< ^T> -> ^T
        when 'T:(static member Zero : ^T)
        and  'T:(static member (+) : ^T * ^T -> ^T)
        and  ^T:(static member DivideByInt : ^T * int -> ^T)

    [<CompiledName "AverageBy">]
    val inline averageBy : f:('T -> ^U) -> source:ISeq< 'T > -> ^U
        when ^U:(static member Zero : ^U)
        and  ^U:(static member (+) : ^U * ^U -> ^U)
        and  ^U:(static member DivideByInt : ^U * int -> ^U)

    [<CompiledName "Empty">]
    val internal empty<'T> : ISeq<'T>

    [<CompiledName "ExactlyOne">]
    val internal exactlyOne : ISeq<'T> -> 'T

    [<CompiledName "Fold">]
    val inline internal fold<'T,'State> : f:('State->'T->'State) -> seed:'State -> source:ISeq<'T> -> 'State

    [<CompiledName "Fold2">]
    val inline internal fold2<'T1,'T2,'State> : folder:('State->'T1->'T2->'State) -> state:'State -> source1: ISeq<'T1> -> source2: ISeq<'T2> -> 'State

    [<CompiledName "Unfold">]
    val internal unfold : generator:('State -> option<'T*'State>) -> state:'State -> ISeq<'T>

    [<CompiledName "InitializeInfinite">]
    val internal initInfinite : f:(int -> 'T) -> ISeq<'T>

    [<CompiledName "Initialize">]
    val internal init : count:int -> f:(int -> 'T) -> ISeq<'T>

    [<CompiledName "Iterate">]
    val inline internal iter : f:('T -> unit) -> source:ISeq<'T> -> unit

    [<CompiledName "Iterate2">]
    val inline internal iter2 : f:('T->'U->unit) -> source1 : ISeq<'T> -> source2 : ISeq<'U> -> unit

    [<CompiledName "IterateIndexed2">]
    val inline internal iteri2 : f:(int->'T->'U->unit) -> source1:ISeq<'T> -> source2:ISeq<'U> -> unit

    [<CompiledName "TryHead">]
    val internal tryHead : ISeq<'T> -> option<'T>

    [<CompiledName("Head")>]
    val internal head: source:ISeq<'T> -> 'T

    [<CompiledName "IterateIndexed">]
    val inline internal iteri : f:(int -> 'T -> unit) -> source:ISeq<'T> -> unit

    [<CompiledName "Except">]
    val inline internal except : itemsToExclude:seq<'T> -> source:ISeq<'T> -> ISeq<'T> when 'T:equality

    [<CompiledName "Exists">]
    val inline internal exists : f:('T -> bool) -> source:ISeq<'T> -> bool

    [<CompiledName "Exists2">]
    val inline internal exists2 : predicate:('T->'U->bool) -> source1:ISeq<'T> -> source2:ISeq<'U> -> bool

    [<CompiledName "Contains">]
    val inline contains : element:'T -> source:ISeq<'T> -> bool when 'T : equality

    [<CompiledName "ForAll">]
    val inline internal forall : predicate:('T -> bool) -> source:ISeq<'T> -> bool

    [<CompiledName "ForAll2">]
    val inline internal forall2 : predicate:('T->'U->bool) -> source1:ISeq<'T> -> source2:ISeq<'U> -> bool

    [<CompiledName "Filter">]
    val inline internal filter : f:('T -> bool) -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Map">]
    val inline internal map : f:('T -> 'U) -> source:ISeq<'T> -> ISeq<'U>

    [<CompiledName "MapIndexed">]
    val inline internal mapi : f:(int->'a->'b) -> source: ISeq<'a> -> ISeq<'b>

    [<CompiledName "Map2">]
    val inline internal map2<'T,'U,'V> : map:('T->'U->'V) -> source1:ISeq<'T> -> source2:ISeq<'U> -> ISeq<'V>

    [<CompiledName "MapIndexed2">]
    val inline internal mapi2<'T,'U,'V> : map:(int -> 'T->'U->'V) -> source1:ISeq<'T> -> source2:ISeq<'U> -> ISeq<'V>

    [<CompiledName "Map3">]
    val inline internal map3<'T,'U,'V,'W> : map:('T->'U->'V->'W) -> source1:ISeq<'T> -> source2:ISeq<'U> -> source3:ISeq<'V> -> ISeq<'W>

    [<CompiledName "CompareWith">]
    val inline internal compareWith : f:('T->'T->int) -> source1 :ISeq<'T> -> source2:ISeq<'T> -> int

    [<CompiledName "Choose">]
    val inline internal choose : f:('a->option<'b>) -> source: ISeq<'a> -> ISeq<'b>

    [<CompiledName "Distinct">]
    val inline internal distinct : source:ISeq<'T> -> ISeq<'T> when 'T:equality

    [<CompiledName "DistinctBy">]
    val inline internal distinctBy : keyf:('T->'Key) -> source:ISeq<'T> -> ISeq<'T> when 'Key:equality

    [<CompiledName "Max">]
    val inline max : source:ISeq<'T> -> 'T when 'T:comparison

    [<CompiledName "MaxBy">]
    val inline maxBy : f:('T->'U) -> source:ISeq<'T> -> 'T when 'U:comparison

    [<CompiledName "Min">]
    val inline min : source:ISeq<'T> -> 'T when 'T:comparison

    [<CompiledName "MinBy">]
    val inline minBy : f:('T->'U) -> source:ISeq<'T> -> 'T when 'U:comparison

    [<CompiledName "Pairwise">]
    val internal pairwise : source:ISeq<'T> -> ISeq<'T * 'T>

    [<CompiledName "Reduce">]
    val inline internal reduce : f:('T->'T->'T) -> source:ISeq<'T> -> 'T

    [<CompiledName "Scan">]
    val internal scan : folder:('State->'T->'State) -> initialState:'State -> source:ISeq<'T> -> ISeq<'State>

    [<CompiledName "Skip">]
    val internal skip : skipCount:int -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "SkipWhile">]
    val inline internal skipWhile : predicate:('T->bool) -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Sum">]
    val inline sum : source:ISeq<'T> -> 'T
        when 'T:(static member Zero : ^T)
        and  'T:(static member (+) : ^T * ^T -> ^T)

    [<CompiledName "SumBy">]
    val inline sumBy : f :('T -> ^U) -> source:ISeq<'T> -> ^U
        when ^U:(static member Zero : ^U)
        and  ^U:(static member (+) : ^U * ^U -> ^U)

    [<CompiledName "Take">]
    val internal take : takeCount:int -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "TakeWhile">]
    val inline internal takeWhile : predicate:('T->bool) -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Tail">]
    val internal tail : source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Truncate">]
    val internal truncate : truncateCount:int -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Indexed">]
    val internal indexed : source: ISeq<'a> -> ISeq<int * 'a>

    [<CompiledName "TryItem">]
    val internal tryItem : index:int -> source:ISeq<'T> -> option<'T>

    [<CompiledName "TryPick">]
    val inline internal tryPick : f:('T -> option<'U>) -> source:ISeq<'T> -> option<'U>

    [<CompiledName "TryFind">]
    val inline internal tryFind : f:('T -> bool) -> source:ISeq<'T> -> option<'T>

    [<CompiledName "TryFindIndex">]
    val inline internal tryFindIndex: predicate:('T->bool) -> source:ISeq<'T> -> option<int>

    [<CompiledName("Last")>]
    val internal last: source:ISeq<'T> -> 'T

    [<CompiledName "TryLast">]
    val internal tryLast : source:ISeq<'T> -> option<'T>

    [<CompiledName "Windowed">]
    val internal windowed : windowSize:int -> source:ISeq<'T> -> ISeq<array<'T>>

    [<CompiledName "Concat">]
    val internal concat : sources:ISeq<'Collection> -> ISeq<'T> when 'Collection :> ISeq<'T>

    [<CompiledName "Append">]
    val internal append: source1:ISeq<'T> -> source2:ISeq<'T> -> ISeq<'T>

    [<CompiledName "Delay">]
    val internal delay : (unit -> ISeq<'T>) -> ISeq<'T>

    [<CompiledName "GroupByVal">]
    val inline internal groupByVal : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * ISeq<'T>> when 'Key : equality and 'Key : struct

    [<CompiledName "GroupByRef">]
    val inline internal groupByRef : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * ISeq<'T>> when 'Key : equality and 'Key : not struct

    [<CompiledName("CountByVal")>]
    val inline internal countByVal : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * int> when 'Key : equality and 'Key : struct

    [<CompiledName("CountByRef")>]
    val inline internal countByRef : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * int> when 'Key : equality and 'Key : not struct

    [<CompiledName("Length")>]
    val internal length: source:ISeq<'T> -> int

    [<CompiledName("ToArray")>]
    val internal toArray: source:ISeq<'T> -> array<'T>

    [<CompiledName("SortBy")>]
    val internal sortBy : projection:('T->'Key) -> source:ISeq<'T> -> ISeq<'T> when 'Key : comparison

    [<CompiledName("Sort")>]
    val internal sort : source:ISeq<'T> -> ISeq<'T> when 'T : comparison

    [<CompiledName("SortWith")>]
    val sortWith : comparer:('T->'T->int) -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName("Reverse")>]
    val internal rev: source:ISeq<'T> -> ISeq<'T>

    [<CompiledName("Permute")>]
    val internal permute: indexMap:(int->int) -> source:ISeq<'T> -> ISeq<'T>

    [<CompiledName("ScanBack")>]
    val internal scanBack<'T,'State> : folder:('T->'State->'State) -> source:ISeq<'T> -> state:'State -> ISeq<'State>

    [<CompiledName("Zip")>]
    val internal zip: source1:ISeq<'T1> -> source2:ISeq<'T2> -> ISeq<'T1 * 'T2>

    [<CompiledName("ReduceBack")>]
    val inline internal reduceBack: reduction:('T->'T->'T) -> source:ISeq<'T> -> 'T

    [<CompiledName("FoldBack")>]
    val inline internal foldBack<'T,'State> : folder:('T->'State->'State) -> source:ISeq<'T> -> state:'State -> 'State

    [<CompiledName("FoldBack2")>]
    val inline internal foldBack2<'T1,'T2,'State> : folder:('T1->'T2->'State->'State) -> source1:ISeq<'T1> -> source2:ISeq<'T2> -> state:'State -> 'State

    module internal GroupBy =
        val inline byVal : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * ISeq<'T>> when 'Key : equality
        val inline byRef : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * ISeq<'T>> when 'Key : equality

    module internal CountBy =
        val inline byVal : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * int> when 'Key : equality
        val inline byRef : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'Key * int> when 'Key : equality

    [<CompiledName("Cache")>]
    val internal cache: source:ISeq<'T> -> ISeq<'T>

    [<CompiledName("Collect")>]
    val internal collect: mapping:('T -> 'Collection) -> source:ISeq<'T> -> ISeq<'U>  when 'Collection :> ISeq<'U>

    [<CompiledName("AllPairs")>]
    val internal allPairs: source1:ISeq<'T1> -> source2:ISeq<'T2> -> ISeq<'T1 * 'T2>

    [<CompiledName("ToList")>]
    val internal toList: source:ISeq<'T> -> 'T list

    [<CompiledName("Replicate")>]
    val internal replicate: count:int -> initial:'T -> ISeq<'T>

    [<CompiledName("IsEmpty")>]
    val internal isEmpty: source:ISeq<'T> -> bool

    [<CompiledName("Cast")>]
    val internal cast: source:IEnumerable -> ISeq<'T>

    [<CompiledName("ChunkBySize")>]
    val internal chunkBySize: chunkSize:int -> source:ISeq<'T> -> ISeq<'T[]>

    [<CompiledName("SplitInto")>]
    val internal splitInto: count:int -> source:ISeq<'T> -> ISeq<'T[]>

    [<CompiledName("Find")>]
    val internal find: predicate:('T -> bool) -> source:ISeq<'T> -> 'T

    [<CompiledName("FindBack")>]
    val internal findBack: predicate:('T -> bool) -> source:ISeq<'T> -> 'T

    [<CompiledName("FindIndex")>]
    val internal findIndex: predicate:('T -> bool) -> source:ISeq<'T> -> int

    [<CompiledName("FindIndexBack")>]
    val internal findIndexBack: predicate:('T -> bool) -> source:ISeq<'T> -> int

    [<CompiledName("Pick")>]
    val internal pick: chooser:('T -> 'U option) -> source:ISeq<'T> -> 'U 

    [<CompiledName("MapFold")>]
    val internal mapFold<'T,'State,'Result> : mapping:('State -> 'T -> 'Result * 'State) -> state:'State -> source:ISeq<'T> -> ISeq<'Result> * 'State

    [<CompiledName("MapFoldBack")>]
    val internal mapFoldBack<'T,'State,'Result> : mapping:('T -> 'State -> 'Result * 'State) -> source:ISeq<'T> -> state:'State -> ISeq<'Result> * 'State

    [<CompiledName("Item")>]
    val internal item: index:int -> source:ISeq<'T> -> 'T

    [<CompiledName("Singleton")>]
    val internal singleton: value:'T -> ISeq<'T>

    [<CompiledName("SortDescending")>]
    val inline sortDescending : source:ISeq<'T> -> ISeq<'T> when 'T : comparison

    [<CompiledName("SortByDescending")>]
    val inline sortByDescending : projection:('T -> 'Key) -> source:ISeq<'T> -> ISeq<'T> when 'Key : comparison

    [<CompiledName("TryFindBack")>]
    val internal tryFindBack: predicate:('T -> bool) -> source:ISeq<'T> -> 'T option

    [<CompiledName("TryFindIndexBack")>]
    val internal tryFindIndexBack : predicate:('T -> bool) -> source:ISeq<'T> -> int option

    [<CompiledName("Zip3")>]
    val internal zip3: source1:ISeq<'T1> -> source2:ISeq<'T2> -> source3:ISeq<'T3> -> ISeq<'T1 * 'T2 * 'T3>
