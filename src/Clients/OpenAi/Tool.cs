﻿using System.Text.Json.Serialization;

namespace Boundless.OmniAdapter.OpenAi;

public sealed class Tool
{
  public static Tool Retrieval { get; } = new() { Type = "retrieval" };

  public static Tool CodeInterpreter { get; } = new() { Type = "code_interpreter" };

  public Tool() { }

    public Tool(Tool other) => CopyFrom(other);

    public Tool(Function function)
    {
        Function = function;
        Type = nameof(function);
    }

    public static implicit operator Tool(Function function) => new(function);


    [JsonInclude]
    [JsonPropertyName("id")]
    public string? Id { get; private set; }

    [JsonInclude]
    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Index { get; private set; }

    [JsonInclude]
    [JsonPropertyName("type")]
    public string? Type { get; private set; }

    [JsonInclude]
    [JsonPropertyName("function")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Function? Function { get; private set; }

    internal void CopyFrom(Tool other)
    {
        if (!string.IsNullOrWhiteSpace(other?.Id))
        {
            Id = other.Id;
        }

        if (other is { Index: not null })
        {
            Index = other.Index.Value;
        }

        if (!string.IsNullOrWhiteSpace(other?.Type))
        {
            Type = other.Type;
        }

        if (other?.Function != null)
        {
            if (Function == null)
            {
                Function = new Function(other.Function);
            }
            else
            {
                Function.CopyFrom(other.Function);
            }
        }
    }

}