namespace Stride.Games;

using System;
using Stride.Core;
using Stride.Core.Serialization.Contents;
using Stride.Graphics;


/// <summary> interface：游戏接口 </summary>
public interface IGame
{
    /// <summary> Occurs when [activated](激活时) </summary>
    event EventHandler<EventArgs> Activated;

    /// <summary> Occurs when [deactivated](失活时) </summary>
    event EventHandler<EventArgs> Deactivated;

    /// <summary> Occurs when [exiting](退出时) </summary>
    event EventHandler<EventArgs> Exiting;

    /// <summary> Occurs when [window created](窗体创建时) </summary>
    event EventHandler<EventArgs> WindowCreated;

    /// <summary> 获取当前游戏时间 </summary>
    GameTime UpdateTime { get; }

    /// <summary> 获取当前绘制时间 </summary>
    GameTime DrawTime { get; }

    /// <summary> 获取绘制插值因子，即（<see cref="UpdateTime"/> - <see cref="DrawTime"/>）/ <see cref="TargetElapsedTime"/> </summary>
    /// <remarks> 如果 <see cref="IsFixedTimeStep"/> 为 false，则为 0，因为 <see cref="UpdateTime"/> 和 <see cref="DrawTime"/> 将相等 </remarks>
    float DrawInterpolationFactor { get; }

    /// <summary> 获取或设置 <see cref="ContentManager"/> </summary>
    ContentManager Content { get; }

    /// <summary> 获取由此游戏注册的游戏组件 </summary>
    GameSystemCollection GameSystems { get; }

    /// <summary> 获取游戏上下文 </summary>
    GameContext Context { get; }

    /// <summary> 获取图形设备 </summary>
    GraphicsDevice GraphicsDevice { get; }

    /// <summary> 获取图形上下文 </summary>
    GraphicsContext GraphicsContext { get; }

    /// <summary> 获取或设置非活动睡眠时间 </summary>
    TimeSpan InactiveSleepTime { get; set; }

    /// <summary> 获取或设置是否激活 </summary>
    /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
    bool IsActive { get; }

    /// <summary> 获取或设置一个值，该值指示此实例是否为固定时间步长 </summary>
    /// <remarks> 如果为 true，则游戏将以固定时间步长运行，否则将以变量时间步长运行 </remarks>
    bool IsFixedTimeStep { get; set; }

    /// <summary> 获取或设置是否允许绘制尽可能快地发生，即使 <see cref="IsFixedTimeStep"/> 已设置 </summary>
    /// <remarks> 如果为 true，则游戏将尽可能快地绘制，即使 <see cref="IsFixedTimeStep"/> 已设置 </remarks>
    bool IsDrawDesynchronized { get; set; }

    /// <summary> 获取或设置鼠标是否可见 </summary>
    /// <remarks> 如果为 true，则鼠标可见；否则，不可见 </remarks>
    bool IsMouseVisible { get; set; }

    /// <summary> 获取启动参数 </summary>
    LaunchParameters LaunchParameters { get; }

    /// <summary> 获取一个值，指示是否正在运行 </summary>
    bool IsRunning { get; }

    /// <summary> 获取服务容器 </summary>
    ServiceRegistry Services { get; }

    /// <summary> 获取或设置目标经过时间 </summary>
    TimeSpan TargetElapsedTime { get; set; }

    /// <summary> 获取抽象窗口 </summary>
    GameWindow Window { get; }
}
