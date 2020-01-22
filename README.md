# SkiaSharpViewsMacFSharpIssue

Filed as https://github.com/mono/SkiaSharp/issues/1104#issue-550671554

[EDIT: This issue is now resolved by removing the reference to mscorlib in the project. See https://github.com/mono/SkiaSharp/issues/1104#issuecomment-577113087]

Temporary repo to illustrate an issue with F# projects using SkiaSharp.Views.Mac.

When I try to open the SkiaSharp.Views.Mac namespace in an F# project targeting Xamarin.Mac Modern, I get a bunch of errors for a few System.Drawing types:

Error: A reference to the type 'System.Drawing.PointF' in assembly Xamarin.Mac was found,
but the type could not be found in the assembly.

including for Point, Size, SizeF, Rectangle, RectangleF.

* These types seem to coincide with this type forwarding in xamarin.macios:
https://github.com/xamarin/xamarin-macios/blob/7f717f01ae9af6490866369b101f57baa0afb50a/src/System.Drawing/PointSizeRectangleTypeForwarders.cs

According to this doc https://docs.microsoft.com/en-us/xamarin/cross-platform/internals/available-assemblies, System.Drawing is not supportedfor Xamarin.Mac Modern.

But it seems that there are extension methods in SkiaSharp.Views.Mac that use System.Drawing classes.
https://github.com/mono/SkiaSharp/blob/5e8dc3e2c9e72f2ad0d9feecefbef503ca9fcc15/source/SkiaSharp.Views/SkiaSharp.Views.Shared/Extensions.cs#L45

The preprocessor directives wrapping the System.Drawing extension methods indicate that they will be included for Mac.
    #if !WINDOWS_UWP && !__TIZEN__

However, a similar project in C# seems to work fine.
Could this be due to something that the F# project system does differently for the assemblies or can/should these System.Drawing extensions not be necessary for Mac (Modern target) since they aren't supported?
