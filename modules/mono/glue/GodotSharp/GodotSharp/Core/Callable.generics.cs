using System;
using System.Runtime.CompilerServices;
using Godot.NativeInterop;

namespace Godot;

#nullable enable

public readonly partial struct Callable
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfArgCountMismatch(NativeVariantPtrArgs args, int countExpected,
         IntPtr? trampolinePtr = null, [CallerArgumentExpression("args")] string? paramName = null)
    {
        if (countExpected != args.Count)
            ThrowArgCountMismatch(countExpected, args.Count, paramName, trampolinePtr);

        static unsafe void ThrowArgCountMismatch(int exp, int got, string? paramName, IntPtr? trampolinePtr)
        {
            var message = $"Arg count  {exp} != {got}";

            var hasDebugInfo = Callable.s_debugInfo.TryGetValue(trampolinePtr.Value, out CallableDebugInfo di);

            if (hasDebugInfo)
            {
                message = $"Arg count  {exp} != {got}. In {di.Method}; Exp was {di.Exp}. File: {di.Path}({di.Line})";
            }

            throw new ArgumentException(
                message,
                paramName);
        }
    }

    /// <summary>
    /// Constructs a new <see cref="Callable"/> for the given <paramref name="action"/>.
    /// </summary>
    /// <param name="action">Action method that will be called.</param>
    public static unsafe Callable From(
        Action action,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static unsafe void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 0, trampolineIntPtr);

            ((Action)delegateObj)();

            ret = default;
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0>(
        Action<T0> action,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {

        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 1, trampolineIntPtr );

            ((Action<T0>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0])
            );

            ret = default;
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }



    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1>(
        Action<T0, T1> action,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 2, trampolineIntPtr );

            ((Action<T0, T1>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1])
            );

            ret = default;
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2>(
        Action<T0, T1, T2> action,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 3, trampolineIntPtr );

            ((Action<T0, T1, T2>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2])
            );

            ret = default;
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3>(
        Action<T0, T1, T2, T3> action,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 4, trampolineIntPtr );

            ((Action<T0, T1, T2, T3>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3])
            );

            ret = default;
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4>(
        Action<T0, T1, T2, T3, T4> action
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 5, trampolineIntPtr );

            ((Action<T0, T1, T2, T3, T4>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4])
            );

            ret = default;
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5>(
        Action<T0, T1, T2, T3, T4, T5> action
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 6, trampolineIntPtr );

            ((Action<T0, T1, T2, T3, T4, T5>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5])
            );

            ret = default;
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6>(
        Action<T0, T1, T2, T3, T4, T5, T6> action
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 7, trampolineIntPtr );

            ((Action<T0, T1, T2, T3, T4, T5, T6>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6])
            );

            ret = default;
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6, [MustBeVariant] T7>(
        Action<T0, T1, T2, T3, T4, T5, T6, T7> action
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 8, trampolineIntPtr );

            ((Action<T0, T1, T2, T3, T4, T5, T6, T7>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6]),
                VariantUtils.ConvertTo<T7>(args[7])
            );

            ret = default;
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

    /// <inheritdoc cref="From(Action)"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6, [MustBeVariant] T7, [MustBeVariant] T8>(
        Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> action
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 9, trampolineIntPtr );
index: 
            ((Action<T0, T1, T2, T3, T4, T5, T6, T7, T8>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6]),
                VariantUtils.ConvertTo<T7>(args[7]),
                VariantUtils.ConvertTo<T8>(args[8])
            );

            ret = default;
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(action, &Trampoline, di );
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Constructs a new <see cref="Callable"/> for the given <paramref name="func"/>.
    /// </summary>
    /// <param name="func">Action method that will be called.</param>
    public static unsafe Callable From<[MustBeVariant] TResult>(
        Func<TResult> func,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 0, trampolineIntPtr );

            TResult res = ((Func<TResult>)delegateObj)();

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] TResult>(
        Func<T0, TResult> func,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {

            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 1, trampolineIntPtr );

            TResult res = ((Func<T0, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] TResult>(
        Func<T0, T1, TResult> func,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 2, trampolineIntPtr );

            TResult res = ((Func<T0, T1, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] TResult>(
        Func<T0, T1, T2, TResult> func,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 3, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, TResult> func,
        [CallerFilePath] string dbgPath = "", [CallerLineNumber] int dbgLine = -1, [CallerMemberName] string dbgMethod = "", [CallerArgumentExpression( "action" )] string dbgExp = ""
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 4, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, T4, TResult> func
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 5, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, T4, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, T4, T5, TResult> func
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 6, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, T4, T5, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, T4, T5, T6, TResult> func
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 7, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, T4, T5, T6, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6, [MustBeVariant] T7, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult> func
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 8, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, T4, T5, T6, T7, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6]),
                VariantUtils.ConvertTo<T7>(args[7])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }

    /// <inheritdoc cref="From{TResult}(Func{TResult})"/>
    public static unsafe Callable From<[MustBeVariant] T0, [MustBeVariant] T1, [MustBeVariant] T2, [MustBeVariant] T3, [MustBeVariant] T4, [MustBeVariant] T5, [MustBeVariant] T6, [MustBeVariant] T7, [MustBeVariant] T8, [MustBeVariant] TResult>(
        Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult> func
    )
    {
        static void Trampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret )
        {
            delegate* managed<object, NativeVariantPtrArgs, out godot_variant, void> trampolinePtr = &Trampoline;

            IntPtr trampolineIntPtr = new IntPtr( trampolinePtr );

            ThrowIfArgCountMismatch(args, 9, trampolineIntPtr );

            TResult res = ((Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TResult>)delegateObj)(
                VariantUtils.ConvertTo<T0>(args[0]),
                VariantUtils.ConvertTo<T1>(args[1]),
                VariantUtils.ConvertTo<T2>(args[2]),
                VariantUtils.ConvertTo<T3>(args[3]),
                VariantUtils.ConvertTo<T4>(args[4]),
                VariantUtils.ConvertTo<T5>(args[5]),
                VariantUtils.ConvertTo<T6>(args[6]),
                VariantUtils.ConvertTo<T7>(args[7]),
                VariantUtils.ConvertTo<T8>(args[8])
            );

            ret = VariantUtils.CreateFrom(res);
        }

        CallableDebugInfo di = new();  //( dbgExp, dbgPath, dbgLine, dbgMethod );

        return CreateWithUnsafeTrampoline(func, &Trampoline, di );
    }
}
