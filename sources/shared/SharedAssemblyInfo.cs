#pragma warning disable 436    // The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly' (due to StrideVersion being duplicated)
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1649 // File name must match first type name

using System.Reflection;
using Stride;

[assembly : AssemblyVersion(StrideVersion.PublicVersion)]                             // 程序集版本
[assembly : AssemblyFileVersion(StrideVersion.PublicVersion)]                         // 文件版本
[assembly : AssemblyInformationalVersion(StrideVersion.AssemblyInformationalVersion)] // 信息性版本


namespace Stride
{

    /// <summary> 用于标识Stride版本的内部类 </summary>
    /// <remarks> 在包构建过程中，PackageUpdateVersionTask正在更新该文件，并期待一些特定的文本正则表达式，因此如果您更改了这些内容，请务必小心 </remarks>
    internal class StrideVersion
    {
        /// <summary> 编辑器为显示目的而使用的版本号,使用Stride.Build构建包时，第4位将自动被git高位替换 </summary>
        public const string PublicVersion = "4.2.0.1";

        /// <summary> 当前程序集版本作为文本，当前与<see cref="PublicVersion"/>相同 </summary>
        public const string AssemblyVersion = PublicVersion;

        /// <summary> NuGet包版本不包含特殊标签 </summary>
        public const string NuGetVersionSimple = PublicVersion;

        /// <summary> NuGet包版本 </summary>
        public const string NuGetVersion = NuGetVersionSimple + NuGetVersionSuffix;

        /// <summary> NuGet包后缀（例如-beta） </summary>
        public const string NuGetVersionSuffix = "";

        /// <summary> 构建元数据，通常在打包期间为+g[git_hash]。由Stride.GitVersioning.GenerateVersionFile自动设置 </summary>
        public const string BuildMetadata = "";

        /// <summary> 包含-beta01或+g[git_hash]的信息性程序集版本 </summary>
        public const string AssemblyInformationalVersion = PublicVersion + NuGetVersionSuffix + BuildMetadata;
    }


    /// <summary> 程序集签名信息 </summary> 
    internal partial class PublicKeys
    {
        /// <summary> 包含签名信息的程序集名称后缀 </summary>
#if STRIDE_SIGNED
        public const string Default = ", PublicKey=0024000004800000940000000602000000240000525341310004000001000100f5ddb3ad5749f108242f29cfaa2205e4a6b87c7444314975dc0fbed53b7d638c17f9540763e7355be932481737cd97a4104aecda872c4805ed9473c70c239d8798b22aefc351bb2cc387eb4391f31c53aeb0452b89433562b06754af8e460384656cd388fb9bbfef348292f9fb4ee6d07b74a8490923079865a60238df259cd2";
#else
        public const string Default = "";
#endif
    }

}
