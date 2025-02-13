using System.Collections.Generic;
using System.Text.Json.Dynamic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace OrchardCore.ContentManagement;

/// <summary>
/// Common traits of <see cref="ContentItem"/>, <see cref="ContentPart"/>
/// and <see cref="ContentField"/>.
/// </summary>
public class ContentElement : IContent
{
    private Dictionary<string, ContentElement> _elements;
    private JsonDynamicObject _dynamicObject;

    internal ContentElement() : this([])
    {
    }

    internal ContentElement(JsonObject data) => Data = data;

    [JsonIgnore]
    protected internal Dictionary<string, ContentElement> Elements => _elements ??= [];

    [JsonIgnore]
    public dynamic Content => _dynamicObject ??= Data;

    [JsonIgnore]
    internal JsonObject Data { get; set; }

    [JsonIgnore]
    public ContentItem ContentItem { get; set; }

    /// <summary>
    /// Whether the content has a named property or not.
    /// </summary>
    /// <param name="name">The name of the property to look for.</param>
    public bool Has(string name) => Data.ContainsKey(name);
}
