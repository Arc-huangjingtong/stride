// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using Stride.Core;
using Stride.Core.Diagnostics;
using Stride.Rendering.Compositing;

namespace Stride.Rendering
{
    /// <summary>
    /// Base implementation of <see cref="IGraphicsRenderer"/>
    /// </summary>
    [DataContract]
    public abstract class RendererBase : RendererCoreBase, IGraphicsRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RendererBase"/> class.
        /// </summary>
        protected RendererBase() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentBase" /> class.
        /// </summary>
        /// <param name="name">The name attached to this component</param>
        protected RendererBase(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Main drawing method for this renderer that must be implemented. 
        /// </summary>
        /// <param name="context">The context.</param>
        protected abstract void DrawCore(RenderDrawContext context);

        /// <summary>
        /// Draws this renderer with the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="System.InvalidOperationException">Cannot use a different context between Load and Draw</exception>
        public void Draw(RenderDrawContext context)
        {
            if (Enabled)
            {
                using var _ = Profiler.Begin(CPUProfilingKey);
                PreDrawCoreInternal(context);
                DrawCore(context);
                PostDrawCoreInternal(context);
            }
        }
    }
}
