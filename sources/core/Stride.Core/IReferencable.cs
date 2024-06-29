namespace Stride.Core;

/// <summary> Base interface，所有可引用对象的基接口</summary>
public interface IReferencable
{
    /// <summary> 获取此实例的引用计数。</summary>
    int ReferenceCount { get; }

    /// <summary> 增加此实例的引用计数。</summary>
    int AddReference();

    /// <summary> 减少此实例的引用计数 </summary>
    /// <returns> 方法返回新的引用计数 </returns>
    /// <remarks> 当引用计数为0时，组件应释放/处理依赖对象。</remarks>
    int Release();
}
