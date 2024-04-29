﻿namespace Boundless.OmniAdapter.Models;

public class ChatResponse
{
  /// <summary>
  /// 
  /// </summary>
  public string Id { get; set; } = Guid.NewGuid().ToString();

  /// <summary>
  /// 
  /// </summary>
  public DateTime CreatedAt { get; set; }

  /// <summary>
  /// 
  /// </summary>
  public Usage? Usage { get; set; }

  /// <summary>
  /// 
  /// </summary>
  public RateLimits? RateLimits { get; set; }

  /// <summary>
  /// This will be:
  /// <see cref="FinishReason.Stop"/>
  /// <see cref="FinishReason.Length"/>
  /// <see cref="FinishReason.ContentFilter"/>
  /// <see cref="FinishReason.ToolCalls"/>
  /// </summary>
  public FinishReason FinishReason { get; set; }

  /// <summary>
  /// The <see cref="Role"/> of the author of this message.
  /// </summary>
  public Role Role { get; set; }

  /// <summary>
  /// The contents of the message.
  /// </summary>
  public string? Content { get; set; }

  /// <summary>
  /// The tool calls generated by the model, such as function calls.
  /// </summary>
  public IEnumerable<Tool> Tools { get; set; } = new List<Tool>();
}