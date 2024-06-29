namespace Stride.Rendering.Lights;

using System.Collections.Generic;
using Stride.Core;


/// <summary> 一个指定的 <see cref="RenderGroupMask"/> 的 <see cref="RenderLight"/> 列表. </summary>
public class RenderLightCollection : List<RenderLight>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RenderLightCollection"/> class.
    /// </summary>
    public RenderLightCollection() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="RenderLightCollection"/> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    public RenderLightCollection(int capacity) : base(capacity) { }

    /// <summary>
    /// Gets or sets the culling mask.
    /// </summary>
    /// <value>The culling mask.</value>
    public RenderGroupMask CullingMask { get; internal set; }

    /// <summary>
    /// Tags attached.
    /// </summary>
    public PropertyContainer Tags;
}
