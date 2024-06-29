using System.Runtime.CompilerServices;

#pragma warning disable 436 // Stride.PublicKeys is defined in multiple assemblies

[assembly : InternalsVisibleTo("Stride.Games.Serializers"   + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.Input"               + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.Engine"              + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.UI"                  + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.Debugger"            + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.Graphics.Regression" + Stride.PublicKeys.Default)]
[assembly : InternalsVisibleTo("Stride.VirtualReality"      + Stride.PublicKeys.Default)]
