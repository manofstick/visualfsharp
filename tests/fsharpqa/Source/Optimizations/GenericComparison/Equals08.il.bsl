
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern FSharp.Core
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 4:7:0:0
}
.assembly Equals08
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Equals08
{
  // Offset: 0x00000000 Length: 0x00000217
}
.mresource public FSharpOptimizationData.Equals08
{
  // Offset: 0x00000220 Length: 0x000000AF
}
.module Equals08.dll
// MVID: {5EDEB166-0759-659E-A745-038366B1DE5E}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00C80000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Equals08
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public EqualsMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static bool  f8() cil managed
    {
      // Code size       73 (0x49)
      .maxstack  5
      .locals init ([0] bool x,
               [1] int32[] t1,
               [2] int32[] t2,
               [3] int32 i)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 5,5 : 8,29 'C:\\src\\fsharp\\tests\\fsharpqa\\source\\Optimizations\\GenericComparison\\Equals08.fsx'
      IL_0000:  ldc.i4.0
      IL_0001:  stloc.0
      .line 6,6 : 8,31 ''
      IL_0002:  ldc.i4.0
      IL_0003:  ldc.i4.1
      IL_0004:  ldc.i4.s   100
      IL_0006:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [FSharp.Core]Microsoft.FSharp.Core.Operators/OperatorIntrinsics::RangeInt32(int32,
                                                                                                                                                                       int32,
                                                                                                                                                                       int32)
      IL_000b:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [FSharp.Core]Microsoft.FSharp.Core.Operators::CreateSequence<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0010:  call       !!0[] [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0015:  stloc.1
      .line 7,7 : 8,31 ''
      IL_0016:  ldc.i4.0
      IL_0017:  ldc.i4.1
      IL_0018:  ldc.i4.s   100
      IL_001a:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [FSharp.Core]Microsoft.FSharp.Core.Operators/OperatorIntrinsics::RangeInt32(int32,
                                                                                                                                                                       int32,
                                                                                                                                                                       int32)
      IL_001f:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [FSharp.Core]Microsoft.FSharp.Core.Operators::CreateSequence<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0024:  call       !!0[] [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0029:  stloc.2
      .line 8,8 : 8,32 ''
      IL_002a:  ldc.i4.0
      IL_002b:  stloc.3
      IL_002c:  br.s       IL_003f

      .line 9,9 : 12,26 ''
      IL_002e:  call       class [mscorlib]System.Collections.Generic.EqualityComparer`1<!0> class [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/HashCompare/FSharpEqualityComparer_PER`1<int32[]>::get_EqualityComparer()
      IL_0033:  ldloc.1
      IL_0034:  ldloc.2
      IL_0035:  callvirt   instance bool class [mscorlib]System.Collections.Generic.EqualityComparer`1<int32[]>::Equals(!0,
                                                                                                                        !0)
      IL_003a:  stloc.0
      IL_003b:  ldloc.3
      IL_003c:  ldc.i4.1
      IL_003d:  add
      IL_003e:  stloc.3
      .line 8,8 : 8,32 ''
      IL_003f:  ldloc.3
      IL_0040:  ldc.i4     0x989681
      IL_0045:  blt.s      IL_002e

      .line 10,10 : 8,9 ''
      IL_0047:  ldloc.0
      IL_0048:  ret
    } // end of method EqualsMicroPerfAndCodeGenerationTests::f8

  } // end of class EqualsMicroPerfAndCodeGenerationTests

} // end of class Equals08

.class private abstract auto ansi sealed '<StartupCode$Equals08>'.$Equals08$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Equals08>'.$Equals08$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
