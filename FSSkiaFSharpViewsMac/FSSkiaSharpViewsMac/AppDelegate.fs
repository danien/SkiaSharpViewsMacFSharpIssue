namespace FSSkiaSharpViewsMac

open System
open Foundation
open AppKit
open SkiaSharp
open SkiaSharp.Views.Mac

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit NSApplicationDelegate()

    do
        System.Console.WriteLine((new CoreGraphics.CGPoint(float 0, float 0)).ToSKPoint())
