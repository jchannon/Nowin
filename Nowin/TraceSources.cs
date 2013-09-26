using System.Diagnostics;

namespace Nowin
{
    internal static class TraceSources
    {
        public static readonly DebugTraceSource Main = new DebugTraceSource("Nowin.Main");
    }

    internal class DebugTraceSource : TraceSource
    {
        public DebugTraceSource(string name) : base(name) { }
        public DebugTraceSource(string name, SourceLevels defaultLevel) : base(name, defaultLevel) { }

        /// <summary>
        /// Writes an informational message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="message">The informative message to write.</param>
        [Conditional("DEBUG")]
        public new void TraceInformation(string message) { TraceEvent(TraceEventType.Information, 0, message, null); }

        /// <summary>
        /// Writes an informational message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks) that contains text intermixed with zero or more format items, which correspond to objects in the args array.</param>
        /// <param name="args">An array containing zero or more objects to format.</param>
        [Conditional("DEBUG")]
        public new void TraceInformation(string format, params object[] args) { TraceEvent(TraceEventType.Information, 0, format, args); }

        /// <summary>
        /// Writes a warning message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="message">The informative message to write.</param>
        [Conditional("DEBUG")]
        public void TraceWarning(string message) { TraceEvent(TraceEventType.Warning, 0, message, null); }

        /// <summary>
        /// Writes a warning message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks) that contains text intermixed with zero or more format items, which correspond to objects in the args array.</param>
        /// <param name="args">An array containing zero or more objects to format.</param>
        [Conditional("DEBUG")]
        public void TraceWarning(string format, params object[] args) { TraceEvent(TraceEventType.Warning, 0, format, args); }

        /// <summary>
        /// Writes an error message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="message">The informative message to write.</param>
        [Conditional("DEBUG")]
        public void TraceError(string message) { TraceEvent(TraceEventType.Error, 0, message, null); }

        /// <summary>
        /// Writes an error message to the trace listeners in the System.Diagnostics.TraceSource.Listeners collection using the specified object array and formatting information.
        /// </summary>
        /// <param name="format">A composite format string (see Remarks) that contains text intermixed with zero or more format items, which correspond to objects in the args array.</param>
        /// <param name="args">An array containing zero or more objects to format.</param>
        [Conditional("DEBUG")]
        public void TraceError(string format, params object[] args) { TraceEvent(TraceEventType.Error, 0, format, args); }
    }
}



/*********************
SAMPLE APP.CONFIG FILE
*********************/

/*
<?xml version="1.0" encoding="utf-8" ?>
<configuration>

  <system.diagnostics>

    <trace autoflush="true" indentsize="0">
      <listeners>
        <remove name="Default"/>
        <add name="Global"
             type="System.Diagnostics.TextWriterTraceListener" 
             initializeData="Global.log" />
          <!-- Critical, Error, Warning, Information, Verbose -->
          <filter type="System.Diagnostics.EventTypeFilter" initializeData="Warning"/>
        </add>
      </listeners>
    </trace>

    <sources>
      <source name="SignalR.SqlMessageBus">
        <listeners>
          <add name="SignalR.Bus" />
        </listeners>
      </source>
      <source name="SignalR.ServiceBusMessageBus">
        <listeners>
          <add name="SignalR.Bus" />
        </listeners>
      </source>
      <source name="SignalR.ScaleoutMessageBus">
        <listeners>
          <add name="SignalR.Bus" />
        </listeners>
      </source>

      <source name="SignalR.Transports.WebSocketTransport">
        <listeners>
          <add name="SignalR.Transports" />
        </listeners>
      </source>
      <source name="SignalR.Transports.ServerSentEventsTransport">
        <listeners>
          <add name="SignalR.Transports" />
        </listeners>
      </source>
      <source name="SignalR.Transports.ForeverFrameTransport">
        <listeners>
          <add name="SignalR.Transports" />
        </listeners>
      </source>
      <source name="SignalR.Transports.LongPollingTransport">
        <listeners>
          <add name="SignalR.Transports" />
        </listeners>
      </source>
      <source name="SignalR.Transports.TransportHeartBeat">
        <listeners>
          <add name="SignalR.Transports" />
        </listeners>
      </source>

      <source name="SignalR.HubDispatcher">
        <listeners>
          <add name="SignalR.HubDispatcher" />
        </listeners>
      </source>
      <source name="SignalR.Connection">
        <listeners>
          <add name="SignalR.Connection" />
        </listeners>
      </source>
      <source name="SignalR.PerformanceCounterManager">
        <listeners>
          <add name="SignalR.PerformanceCounterManager" />
        </listeners>
      </source>
      <source name="SignalR.PersistentConnection">
        <listeners>
          <add name="SignalR.PersistentConnection" />
        </listeners>
      </source>

      <source name="Nowin.Main">
        <listeners>
          <add name="Nowin.Main" />
        </listeners>
      </source>
    </sources>

    <switches>
      <add name="SignalRSwitch" value="Verbose" />
      <add name="Nowin.Main" value="Verbose" />
    </switches>

    <sharedListeners>
      <add name="SignalR.Bus"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.Bus.log" />

      <add name="SignalR.Transports"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.Transports.log" />

      <add name="SignalR.HubDispatcher"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.HubDispatcher.log" />
      <add name="SignalR.Connection"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.Connection.log" />
      <add name="SignalR.PerformanceCounterManager"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.PerformanceCounterManager.log" />
      <add name="SignalR.PersistentConnection"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="SignalR.PersistentConnection.log" />

      <add name="Nowin.Main"
           type="System.Diagnostics.TextWriterTraceListener" 
           initializeData="Nowin.Main.log" />
    </sharedListeners>

  </system.diagnostics>

</configuration>
*/
