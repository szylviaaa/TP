﻿//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Diagnostics;
using TP.Introduction;

namespace TP.DependencyInjection.ConsoleApplication
{
  /// <summary>
  /// Class ConsoleTraceSource - an example implementation of <see cref="ITraceSource"/> using <see cref="Console"/> to trace code behavior.
  /// </summary>
  /// <seealso cref="TP.DependencyInjection.ITraceSource" />
  internal class ConsoleTraceSource : ITraceSource
  {
    /// <summary>
    /// Writes trace data to the trace listeners in the <see cref="P:System.Diagnostics.TraceSource.Listeners" /> collection using the specified <paramref name="eventType" />,
    /// event identifier <paramref name="id" />, and trace <paramref name="data" />.
    /// </summary>
    /// <param name="eventType">One of the enumeration values that specifies the event type of the trace data.</param>
    /// <param name="id">A numeric identifier for the event.</param>
    /// <param name="data">The trace data.</param>
    public void TraceData(TraceEventType eventType, int id, object data)
    {
      Console.WriteLine($"Event type: {eventType}, id: {id}, message: {data}");
    }
  }
}