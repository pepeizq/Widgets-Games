﻿using System;
using System.Runtime.InteropServices;

namespace COMServer;

internal static class MetodosNativos
{
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    public static extern int GetCurrentThreadId();

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    public static extern int GetCurrentProcessId();

    [DllImport("ole32.dll")]
    public static extern int CoWaitForMultipleObjects(CWMO_FLAGS dwFlags, uint dwTimeout, int cHandles, IntPtr[] pHandles, out uint lpdwindex);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr CreateEvent(IntPtr eventAttributes, [MarshalAs(UnmanagedType.Bool)] bool manualReset, [MarshalAs(UnmanagedType.Bool)] bool initialState, IntPtr name);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetMessage(
        out NativeMessage lpMsg,
        IntPtr hWnd,
        [MarshalAs(UnmanagedType.U4)] int wMsgFilterMin,
        [MarshalAs(UnmanagedType.U4)] int wMsgFilterMax);

    /// <summary>
    /// The TranslateMessage function translates virtual-key messages into 
    /// character messages. The character messages are posted to the calling 
    /// thread's message queue, to be read the next time the thread calls the 
    /// GetMessage or PeekMessage function.
    /// </summary>
    /// <param name="lpMsg"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool TranslateMessage(
        [In] ref NativeMessage lpMsg);

    /// <summary>
    /// The DispatchMessage function dispatches a message to a window 
    /// procedure. It is typically used to dispatch a message retrieved by 
    /// the GetMessage function.
    /// </summary>
    /// <param name="lpMsg"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage(
        [In] ref NativeMessage lpMsg);

    /// <summary>
    /// The PostThreadMessage function posts a message to the message queue 
    /// of the specified thread. It returns without waiting for the thread to 
    /// process the message.
    /// </summary>
    /// <param name="idThread">
    /// Identifier of the thread to which the message is to be posted.
    /// </param>
    /// <param name="Msg">Specifies the type of message to be posted.</param>
    /// <param name="wParam">
    /// Specifies additional message-specific information.
    /// </param>
    /// <param name="lParam">
    /// Specifies additional message-specific information.
    /// </param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PostThreadMessage(
        [MarshalAs(UnmanagedType.U4)] int idThread,
        [MarshalAs(UnmanagedType.U4)] int Msg,
        IntPtr wParam,
        IntPtr lParam);

    /// <summary>
    /// CoInitializeEx() can be used to set the apartment model of individual 
    /// threads.
    /// </summary>
    /// <param name="pvReserved">Must be NULL</param>
    /// <param name="dwCoInit">
    /// The concurrency model and initialization options for the thread
    /// </param>
    /// <returns></returns>
    [DllImport("ole32.dll")]
    public static extern int CoInitializeEx(
        IntPtr pvReserved,
        [MarshalAs(UnmanagedType.U4)] int dwCoInit);

    /// <summary>
    /// CoUninitialize() is used to uninitialize a COM thread.
    /// </summary>
    [DllImport("ole32.dll")]
    public static extern void CoUninitialize();

    /// <summary>
    /// Registers an EXE class object with OLE so other applications can 
    /// connect to it. EXE object applications should call 
    /// CoRegisterClassObject on startup. It can also be used to register 
    /// internal objects for use by the same EXE or other code (such as DLLs)
    /// that the EXE uses.
    /// </summary>
    /// <param name="rclsid">CLSID to be registered</param>
    /// <param name="pUnk">
    /// Pointer to the IUnknown interface on the class object whose 
    /// availability is being published.
    /// </param>
    /// <param name="dwClsContext">
    /// Context in which the executable code is to be run.
    /// </param>
    /// <param name="flags">
    /// How connections are made to the class object.
    /// </param>
    /// <param name="lpdwRegister">
    /// Pointer to a value that identifies the class object registered; 
    /// </param>
    /// <returns></returns>
    /// <remarks>
    /// PInvoking CoRegisterClassObject to register COM objects is not 
    /// supported.
    /// </remarks>
    [DllImport("ole32.dll")]
    public static extern int CoRegisterClassObject(
        ref Guid rclsid,
        [MarshalAs(UnmanagedType.Interface)] IClassFactory pUnk,
        [MarshalAs(UnmanagedType.U4)] CLSCTX dwClsContext,
        [MarshalAs(UnmanagedType.U4)] REGCLS flags,
        [Out, MarshalAs(UnmanagedType.U4)] out int lpdwRegister);

    /// <summary>
    /// Informs OLE that a class object, previously registered with the 
    /// CoRegisterClassObject function, is no longer available for use.
    /// </summary>
    /// <param name="dwRegister">
    /// Token previously returned from the CoRegisterClassObject function
    /// </param>
    /// <returns></returns>
    [DllImport("ole32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    public static extern int CoRevokeClassObject(
        [MarshalAs(UnmanagedType.U4)] int dwRegister);

    /// <summary>
    /// Called by a server that can register multiple class objects to inform 
    /// the SCM about all registered classes, and permits activation requests 
    /// for those class objects.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Servers that can register multiple class objects call 
    /// CoResumeClassObjects once, after having first called 
    /// CoRegisterClassObject, specifying REGCLS_LOCAL_SERVER | 
    /// REGCLS_SUSPENDED for each CLSID the server supports. This function 
    /// causes OLE to inform the SCM about all the registered classes, and 
    /// begins letting activation requests into the server process.
    /// 
    /// This reduces the overall registration time, and thus the server 
    /// application startup time, by making a single call to the SCM, no 
    /// matter how many CLSIDs are registered for the server. Another 
    /// advantage is that if the server has multiple apartments with 
    /// different CLSIDs registered in different apartments, or is a free-
    /// threaded server, no activation requests will come in until the server 
    /// calls CoResumeClassObjects. This gives the server a chance to 
    /// register all of its CLSIDs and get properly set up before having to 
    /// deal with activation requests, and possibly shutdown requests. 
    /// </remarks>
    [DllImport("ole32.dll")]
    public static extern int CoResumeClassObjects();

    public const int WM_QUIT = 0x0012;

    /// <summary>
    /// Interface Id of IClassFactory
    /// </summary>
    public const string IID_IClassFactory = "00000001-0000-0000-C000-000000000046";

    /// <summary>
    /// Interface Id of IUnknown
    /// </summary>
    public const string IID_IUnknown = "00000000-0000-0000-C000-000000000046";

    /// <summary>
    /// Interface Id of IDispatch
    /// </summary>
    public const string IID_IDispatch = "00020400-0000-0000-C000-000000000046";

    /// <summary>
    /// Class does not support aggregation (or class object is remote)
    /// </summary>
    public const int CLASS_E_NOAGGREGATION = unchecked((int)0x80040110);

    /// <summary>
    /// No such interface supported
    /// </summary>
    public const int E_NOINTERFACE = unchecked((int)0x80004002);

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMessage
    {
        public IntPtr hWnd;

        [MarshalAs(UnmanagedType.U4)]
        public int message;

        public IntPtr wParam;
        public IntPtr lParam;

        [MarshalAs(UnmanagedType.U4)]
        public int time;

        public NativePoint pt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativePoint
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// Values from the CLSCTX enumeration are used in activation calls to 
    /// indicate the execution contexts in which an object is to be run. These
    /// values are also used in calls to CoRegisterClassObject to indicate the
    /// set of execution contexts in which a class object is to be made available
    /// for requests to construct instances.
    /// </summary>
    [Flags]
    public enum CLSCTX : int
    {
        INPROC_SERVER = 0x1,
        INPROC_HANDLER = 0x2,
        LOCAL_SERVER = 0x4,
        INPROC_SERVER16 = 0x8,
        REMOTE_SERVER = 0x10,
        INPROC_HANDLER16 = 0x20,
        RESERVED1 = 0x40,
        RESERVED2 = 0x80,
        RESERVED3 = 0x100,
        RESERVED4 = 0x200,
        NO_CODE_DOWNLOAD = 0x400,
        RESERVED5 = 0x800,
        NO_CUSTOM_MARSHAL = 0x1000,
        ENABLE_CODE_DOWNLOAD = 0x2000,
        NO_FAILURE_LOG = 0x4000,
        DISABLE_AAA = 0x8000,
        ENABLE_AAA = 0x10000,
        FROM_DEFAULT_CONTEXT = 0x20000,
        ACTIVATE_32_BIT_SERVER = 0x40000,
        ACTIVATE_64_BIT_SERVER = 0x80000
    }

    [Flags]
    public enum CWMO_FLAGS : int
    {
        CWMO_DEFAULT = 0,
        CWMO_DISPATCH_CALLS = 1,
        CWMO_DISPATCH_WINDOW_MESSAGES = 2
    };

    /// <summary>
    /// The REGCLS enumeration defines values used in CoRegisterClassObject to 
    /// control the type of connections to a class object.
    /// </summary>
    [Flags]
    public enum REGCLS : int
    {
        SINGLEUSE = 0,
        MULTIPLEUSE = 1,
        MULTI_SEPARATE = 2,
        SUSPENDED = 4,
        SURROGATE = 8,
    }
}
