
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
.assembly Hash11
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.FSharpInterfaceDataVersionAttribute::.ctor(int32,
                                                                                                      int32,
                                                                                                      int32) = ( 01 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 01 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.mresource public FSharpSignatureData.Hash11
{
  // Offset: 0x00000000 Length: 0x00000203
}
.mresource public FSharpOptimizationData.Hash11
{
  // Offset: 0x00000208 Length: 0x000000A9
}
.module Hash11.dll
// MVID: {5EDEB166-9661-78D3-A745-038366B1DE5E}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x07020000


// =============== CLASS MEMBERS DECLARATION ===================

.class public abstract auto ansi sealed Hash11
       extends [mscorlib]System.Object
{
  .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
  .class abstract auto ansi sealed nested public HashMicroPerfAndCodeGenerationTests
         extends [mscorlib]System.Object
  {
    .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationMappingAttribute::.ctor(valuetype [FSharp.Core]Microsoft.FSharp.Core.SourceConstructFlags) = ( 01 00 07 00 00 00 00 00 ) 
    .method public static void  f8() cil managed
    {
      // Code size       49 (0x31)
      .maxstack  5
      .locals init ([0] int32[] arr,
               [1] int32 i,
               [2] int32 V_2)
      .language '{AB4F38C9-B6E6-43BA-BE3B-58080B2CCCE3}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
      .line 6,6 : 8,32 'C:\\src\\fsharp\\tests\\fsharpqa\\source\\Optimizations\\GenericComparison\\Hash11.fsx'
      IL_0000:  ldc.i4.0
      IL_0001:  ldc.i4.1
      IL_0002:  ldc.i4.s   100
      IL_0004:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [FSharp.Core]Microsoft.FSharp.Core.Operators/OperatorIntrinsics::RangeInt32(int32,
                                                                                                                                                                       int32,
                                                                                                                                                                       int32)
      IL_0009:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [FSharp.Core]Microsoft.FSharp.Core.Operators::CreateSequence<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_000e:  call       !!0[] [FSharp.Core]Microsoft.FSharp.Collections.SeqModule::ToArray<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_0013:  stloc.0
      .line 7,7 : 8,32 ''
      IL_0014:  ldc.i4.0
      IL_0015:  stloc.1
      IL_0016:  br.s       IL_0028

      .line 8,8 : 12,30 ''
      IL_0018:  call       class [mscorlib]System.Collections.Generic.EqualityComparer`1<!0> class [FSharp.Core]Microsoft.FSharp.Core.LanguagePrimitives/HashCompare/FSharpEqualityComparer_PER`1<int32[]>::get_EqualityComparer()
      IL_001d:  ldloc.0
      IL_001e:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.EqualityComparer`1<int32[]>::GetHashCode(!0)
      IL_0023:  stloc.2
      IL_0024:  ldloc.1
      IL_0025:  ldc.i4.1
      IL_0026:  add
      IL_0027:  stloc.1
      .line 7,7 : 8,32 ''
      IL_0028:  ldloc.1
      IL_0029:  ldc.i4     0x989681
      IL_002e:  blt.s      IL_0018

      IL_0030:  ret
    } // end of method HashMicroPerfAndCodeGenerationTests::f8

  } // end of class HashMicroPerfAndCodeGenerationTests

} // end of class Hash11

.class private abstract auto ansi sealed '<StartupCode$Hash11>'.$Hash11$fsx
       extends [mscorlib]System.Object
{
} // end of class '<StartupCode$Hash11>'.$Hash11$fsx


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
