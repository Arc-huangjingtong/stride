namespace Stride.Core;

/// <summary> 指定在必须序列化数组/列表或字典/映射时用于文本序列化的样式 </summary>
public enum DataStyle
{
    /// <summary> 让发射器选择样式 </summary>
    Any,

    /// <summary> 正常样式（每个项目一行，由空格结构化） </summary>
    Normal,

    /// <summary> 紧凑样式（由[]或{}括起来的样式） </summary>
    Compact,
}
