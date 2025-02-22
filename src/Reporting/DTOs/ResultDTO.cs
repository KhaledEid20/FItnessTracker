using System;

namespace Reporting.DTOs;

public class ResultDTO<T>
{
    public string Message { get; set; }
    public bool Success { get; set; } = false;
    public T Data { get; set; }
}
