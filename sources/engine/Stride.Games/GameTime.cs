namespace Stride.Games;

using System;


/// <summary> 当前用于变量步长（实时）或固定步长（游戏时间）游戏的时间 </summary>
public class GameTime
{
    /// <summary> 初始化 <see cref="GameTime" /> 类的新实例。 </summary>
    /// <param name="totalTime"> 自游戏开始以来的总游戏时间 </param>
    /// <param name="elapsedTime"> 自上次更新以来的经过的游戏时间 </param>
    public GameTime(TimeSpan totalTime = default, TimeSpan elapsedTime = default)
    {
        Total                  = totalTime;
        Elapsed                = elapsedTime;
        accumulatedElapsedTime = TimeSpan.Zero;
        factor                 = 1;
    }



    /// <summary> 获取自上次更新以来的经过的游戏时间 </summary>
    public TimeSpan Elapsed { get; private set; }

    /// <summary> 获取自游戏开始以来的总游戏时间 </summary>
    /// <value> 自游戏开始以来的总游戏时间 </value>
    public TimeSpan Total { get; private set; }

    /// <summary> 获取当前帧数，自游戏开始以来 </summary>
    public int FrameCount { get; private set; }

    /// <summary> 获取当前运行游戏的每秒帧数（FPS） </summary>
    /// <value> 每秒帧数 </value>
    public float FramePerSecond { get; private set; }

    /// <summary> 获取每帧的时间 </summary>
    /// <value> 每帧的时间 </value>
    public TimeSpan TimePerFrame { get; private set; }

    /// <summary> 获取一个值，该值指示是否为此帧更新了 <see cref="FramePerSecond" /> 和 <see cref="TimePerFrame" /> </summary>
    /// <value> 如果为此帧更新了 <see cref="FramePerSecond" /> 和 <see cref="TimePerFrame" /> ，则为 <c>true</c> ；否则为 <c>false</c> </value>
    public bool FramePerSecondUpdated { get; private set; }


    /// <summary> 获取经过的时间乘以时间因子 </summary>
    /// <value> 经过的时间 </value>
    public TimeSpan WarpElapsed { get; private set; }


    /// <summary> <br/>获取或设置时间因子
    /// <br/>这个值控制扭曲时间的流动，包括物理、动画和粒子
    /// <br/>0到1之间的值会减慢时间，大于1的值会加快时间 </summary>
    /// <value> 乘数因子，一个大于或等于0的双精度值 </value>
    public double Factor
    {
        get => factor;
        set => factor = Math.Max(0, value);
    }

    private double factor;

    /// <summary> 积累的经过的时间 </summary>
    private TimeSpan accumulatedElapsedTime;

    /// <summary> 每秒累积的帧数 </summary>
    private int accumulatedFrameCountPerSecond;


    /// <summary> 更新游戏时间 </summary>
    internal void Update(TimeSpan totalGameTime, TimeSpan elapsedGameTime, bool incrementFrameCount)
    {
        Total       = totalGameTime;   // 从游戏开始到现在的总时间
        Elapsed     = elapsedGameTime; // 从上次更新到现在的时间
        WarpElapsed = TimeSpan.FromTicks((long)(Elapsed.Ticks * Factor));

        FramePerSecondUpdated = false; // 重置帧率更新标志

        if (!incrementFrameCount) // 如果需要增加帧数
        {
            return;
        }

        accumulatedElapsedTime += elapsedGameTime; // 累加经过的时间

        var accumulatedElapsedGameTimeInSecond = accumulatedElapsedTime.TotalSeconds;


        // 如果累积的帧数大于0且累积的每秒游戏时间大于1.0
        if (accumulatedFrameCountPerSecond > 0 && accumulatedElapsedGameTimeInSecond > 1.0)
        {
            // 计算每帧的时间
            TimePerFrame = TimeSpan.FromTicks(accumulatedElapsedTime.Ticks / accumulatedFrameCountPerSecond);
            // 计算FPS
            FramePerSecond = (float)(accumulatedFrameCountPerSecond / accumulatedElapsedGameTimeInSecond);
            // 重置累积的帧数和时间
            accumulatedFrameCountPerSecond = 0;
            accumulatedElapsedTime         = TimeSpan.Zero;
            FramePerSecondUpdated          = true;
        }

        accumulatedFrameCountPerSecond++; // 累加每秒帧数
        FrameCount++;                     // 累加帧数
    }

    /// <summary> 重置游戏时间 </summary>
    internal void Reset(TimeSpan totalGameTime)
    {
        Update(totalGameTime, TimeSpan.Zero, false);
        accumulatedElapsedTime         = TimeSpan.Zero;
        accumulatedFrameCountPerSecond = 0;
        FrameCount                     = 0;
    }

    public void ResetTimeFactor() => factor = 1;
}
